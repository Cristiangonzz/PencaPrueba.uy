import {
  AfterViewChecked,
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { ChatHubService } from '../../application/use-case/chat/chat-hub-service.use-case';
import { map, Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { chatMensajeUseCaseProviders } from '../../intraestructure/delegate/delegate-chat-mensaje/delegateChatMensaje';
import { chatUseCaseProviders } from '../../intraestructure/delegate/delegate-chat/delegateChat';
import { ChatDomainEntity } from '../../domain/entity/ChatEntity';
import { ChatHistorialDomainEntity } from '../../domain/entity/ChatHistorialEntity';
import { ChatService } from '../../domain/services/ChatService';
import { SweetAlert } from '../share/sweetAlert/sweet-alert.presentation';
import { ResponseDomainEntity } from '../../domain/entity/ResponseEntity';
import { ChatMensajeDomainEntity } from '../../domain/entity/ChatMensajeEntity';
import { IChatMensajeDomain } from '../../domain/interfaces/chat/IChatMensajeDomain';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css',
})
export class ChatComponent implements OnInit, OnDestroy, AfterViewChecked {
  //delegateCategoria = chatUseCaseProviders;
  chat!: ChatDomainEntity;
  chatHistorial!: ChatHistorialDomainEntity;
  chatMensajes!: ChatMensajeDomainEntity[];
  delegateChat = chatUseCaseProviders;
  delegateChatmensaje = chatMensajeUseCaseProviders;
  public chatId = '';
  public UsuarioId = '';
  public messageToSend = '';
  sweet = new SweetAlert();
  public conversation!: ReciboMessage[];
  private conversationSubscription: Subscription | undefined;
  @ViewChild('scrollMe') private scrollContainer!: ElementRef;
  constructor(
    private chatHubService: ChatHubService,
    private readonly activatedRoute: ActivatedRoute,
    private chatServicio: ChatService
  ) {}

  ngOnDestroy(): void {
    // Asegúrate de cancelar la suscripción para evitar posibles fugas de memoria
    if (this.conversationSubscription) {
      this.conversationSubscription.unsubscribe();
    }
  }

  ngOnInit(): void {
    //this.chatHubService.conexionWebSocket();
    this.getChat();
    this.chatHubService.canalMesaggeEmmit$
      .pipe(
        // Usa el operador map para transformar cada ReciboMessage a IChatMensajeDomain
        map((conversation: ReciboMessage[]) => {
          return conversation.map((msg: ReciboMessage) => {
            return {
              mensaje: msg.message,
              activo: true, // o cualquier valor booleano que desees por defecto
              usuario: msg.userName,
            } as IChatMensajeDomain;
          });
        })
      )
      .subscribe((mensajesTranformado: IChatMensajeDomain[]) => {
        // Guarda la conversación transformada
        this.chatMensajes = [...this.chatMensajes, ...mensajesTranformado];
      });
  }

  ngAfterViewChecked(): void {
    // Verifica si scrollContainer está definido y si su propiedad nativeElement está definida
    if (this.scrollContainer && this.scrollContainer.nativeElement) {
      this.scrollContainer.nativeElement.scrollTop =
        this.scrollContainer.nativeElement.scrollHeight;
    }
  }

  getChat() {
    //this.activatedRoute.snapshot.paramMap.get('chatId') || ''; otra opcion
    this.delegateChat.getChatUseCaseProvider
      .useFactory(this.chatServicio)
      .execute((this.chatId = this.activatedRoute.snapshot.params['id']))
      .subscribe({
        next: (value: ResponseDomainEntity<ChatDomainEntity>) => {
          this.chat = value.value!;
          this.chatHistorial = value.value!.historial;
          this.chatMensajes = value.value!.historial.chatMensaje;
        },
        error: () => {
          this.sweet.toFire('Curso', 'Error al Obtener Chat', 'error');
        },
      });
  }

  public join() {
    this.chatHubService.join(this.chatId, this.UsuarioId);
  }

  public sendMessage() {
    const newMessage: EnvioNewMessage = {
      message: this.messageToSend,
      chatId: this.chatId,
      userId: this.UsuarioId,
    };
    this.chatHubService.sendMessage(newMessage);
    this.messageToSend = '';
  }

  public leave() {
    this.chatHubService
      .leave(this.UsuarioId, this.chatId)
      .then(() => {
        setTimeout(() => {
          location.reload();
        }, 0);
      })
      .catch((err) => {
        console.log(err);
      });
  }
}
//(string? UserName, string Message, string? GroupName, Guid ChatId, Guid UserId);
interface EnvioNewMessage {
  message: string;
  chatId: string;
  userId: string;
}

interface ReciboMessage {
  userName: string;
  message: string;
}
