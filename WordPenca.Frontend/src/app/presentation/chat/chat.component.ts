import {
  AfterViewChecked,
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { ChatService } from '../../application/use-case/chat/chat-service.use-case';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css',
})
export class ChatComponent implements OnInit, OnDestroy, AfterViewChecked {
  //delegateCategoria = chatUseCaseProviders;
  public userName = '';
  public groupName = ''; //Es solo para la vista de chat
  public chatId = '';
  public UsuarioId = '';
  public messageToSend = '';
  public joined = false;
  public conversation!: ReciboMessage[];
  private conversationSubscription: Subscription | undefined;
  @ViewChild('scrollMe') private scrollContainer!: ElementRef;
  constructor(private chatService: ChatService) {}
  ngOnDestroy(): void {
    // Asegúrate de cancelar la suscripción para evitar posibles fugas de memoria
    if (this.conversationSubscription) {
      this.conversationSubscription.unsubscribe();
    }
  }

  ngOnInit(): void {
    //this.chatService.conexionWebSocket();

    this.chatService.canalMesaggeEmmit$.subscribe(
      (conversation: ReciboMessage[]) => {
        this.conversation = conversation;
      }
    );

    // this.chatService.conexionUsuario.subscribe((estado: boolean) => {
    //   this.joined = estado;
    // });
  }

  ngAfterViewChecked(): void {
    // Verifica si scrollContainer está definido y si su propiedad nativeElement está definida
    if (this.scrollContainer && this.scrollContainer.nativeElement) {
      this.scrollContainer.nativeElement.scrollTop = this.scrollContainer.nativeElement.scrollHeight;
    }
  }

  public join() {
    this.chatService.join(this.userName, this.chatId, this.UsuarioId);
    this.joined = true;
  }

  public sendMessage() {
    const newMessage: EnvioNewMessage = {
      message: this.messageToSend,
      userName: this.userName,
      chatId: this.chatId,
      userId: this.UsuarioId,
    };
    this.chatService.sendMessage(newMessage);
    this.messageToSend = '';
  }

  public leave() {
    this.chatService
      .leave(this.userName, this.groupName)
      .then(() => {
        setTimeout(() => {
          location.reload();
        }, 0);
      })
      .catch((err) => {
        console.log(err);
      });
    this.joined = false;
  }
}
//(string? UserName, string Message, string? GroupName, Guid ChatId, Guid UserId);
interface EnvioNewMessage {
  userName: string;
  message: string;
  chatId: string;
  userId: string;
}

interface ReciboMessage {
  userName: string;
  message: string;
  activo?: boolean;
}
