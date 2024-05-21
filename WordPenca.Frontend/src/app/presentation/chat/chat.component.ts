import {
  AfterViewChecked,
  Component,
  ElementRef,
  Input,
  OnChanges,
  OnDestroy,
  OnInit,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { ChatHubService } from '../../application/use-case/chat/chat-hub-service.use-case';
import { Subscription } from 'rxjs';
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
export class ChatComponent implements OnInit, OnDestroy, AfterViewChecked ,OnChanges{

  @Input() chatData: { id: string, name: string } | null = null;

  chat!: ChatDomainEntity;
  chatHistorial: ChatHistorialDomainEntity = {} as ChatHistorialDomainEntity;
  chatMensajes: ChatMensajeDomainEntity[] = [];
  delegateChat = chatUseCaseProviders;
  delegateChatmensaje = chatMensajeUseCaseProviders;
  chatId = '';
  UsuarioId = '';
  UsuarioName = '';

  messageToSend = '';
  mensajeRespuesta: ChatMensajeDomainEntity | null = null;
  sweet = new SweetAlert();
  private conversationSubscription: Subscription | undefined;
  @ViewChild('scrollMe') private scrollContainer!: ElementRef;
  constructor(
    private chatHubService: ChatHubService,
    private chatServicio: ChatService
  ) {}


  ngOnChanges(changes: SimpleChanges): void {
    if (changes['chatData'] && this.chatData) {
      this.join();
    }
  }

  ngOnDestroy(): void {
    // Asegúrate de cancelar la suscripción para evitar posibles fugas de memoria
    if (this.conversationSubscription) {
      this.conversationSubscription.unsubscribe();
    }
  }

  ngOnInit(): void {
    this.join();//Se inicia la conexion con el chat

    this.getChat();
    this.chatHubService.canalMesaggeEmmit$.subscribe(
      (mensaje: IChatMensajeDomain) => {
        if (mensaje != null) {
          this.chatMensajes.push(mensaje);
          console.log('mensajes recibido' + JSON.stringify(this.chatMensajes));
        }
      }
    );
  }

  ngAfterViewChecked(): void {
    // Verifica si scrollContainer está definido y si su propiedad nativeElement está definida
    if (this.scrollContainer && this.scrollContainer.nativeElement) {
      this.scrollContainer.nativeElement.scrollTop =
        this.scrollContainer.nativeElement.scrollHeight;
    }
  }
  contestarMensaje(mensaje : ChatMensajeDomainEntity){
    this.mensajeRespuesta = mensaje;
    this.mensajeMenu(mensaje);
  }

  public mensajeMenu(message: ChatMensajeDomainEntity) {
    message.activo = !message.activo;
  }
  cancelarRespuesta(){
    this.mensajeRespuesta = null;
  }
  public editMessage(message: ChatMensajeDomainEntity) {
    // Lógica para editar el mensaje
    this.mensajeMenu(message); // Cerrar el menú después de seleccionar editar
  }

  public deleteMessage(message: ChatMensajeDomainEntity) {
    // Lógica para eliminar el mensaje
    this.mensajeMenu(message); // Cerrar el menú después de seleccionar eliminar
  }

  getHistorial() {
    this.delegateChat.getChatHistorialUseCaseProvider
      .useFactory(this.chatServicio)
      .execute(this.chatId)
      .subscribe({
        next: (value: ResponseDomainEntity<ChatHistorialDomainEntity>) => {
          this.chatHistorial = value.value!;
          this.chatMensajes = value.value!.mensajes;
          console.log('Historial' + JSON.stringify(this.chatHistorial));
          console.log('Historial' + JSON.stringify(this.chatMensajes));
        },
        error: () => {
          this.sweet.toFire(
            'Historial',
            'Error al Obtener Chat Historial',
            'error'
          );
        },
      });
  }
  getChat() {
   
    //this.activatedRoute.snapshot.paramMap.get('chatId') || ''; otra opcion
    this.delegateChat.getChatUseCaseProvider
      .useFactory(this.chatServicio)
      .execute(this.chatId)
      .subscribe({
        next: (value: ResponseDomainEntity<ChatDomainEntity>) => {
          this.chat = value.value!;
          console.log('El Chat' + JSON.stringify(this.chat));
          this.getHistorial();
        },
        error: () => {
          this.sweet.toFire('Chat', 'Error al Obtener Chat', 'error');
        },
      });
  }

  join(){
    this.chatId = '664bfb5c5d354fe624128255';
    this.UsuarioId = this.chatData?.id!;
    this.UsuarioName =  this.chatData?.name!;
    this.chatHubService.join(this.chatId, this.UsuarioId);
  }
  
  public sendMessage() {
    const newMessage: EnvioNewMessage = {
      Message: this.messageToSend,
      ChatId: this.chatId,
      UsuarioId: this.UsuarioId,
      UsuarioName: this.UsuarioName,
    };

    if (this.mensajeRespuesta) {
      newMessage['Respuesta'] = this.mensajeRespuesta.id;
    }
    this.chatHubService.sendMessage(newMessage);
    this.messageToSend = '';
    this.mensajeRespuesta = null;
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
  Message: string;
  ChatId: string;
  UsuarioId: string;
  UsuarioName: string;
  Respuesta?: string;
}
