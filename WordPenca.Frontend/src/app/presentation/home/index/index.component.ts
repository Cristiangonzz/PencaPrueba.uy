import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';
import { chatUseCaseProviders } from '../../../intraestructure/delegate/delegate-chat/delegateChat';
import { ChatUsuarioDomainEntity } from '../../../domain/entity/ChatUsuarioEntity';
import { chatMensajeUseCaseProviders } from '../../../intraestructure/delegate/delegate-chat-mensaje/delegateChatMensaje';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { SweetAlert } from '../../share/sweetAlert/sweet-alert.presentation';
import { ChatService } from '../../../domain/services/ChatService';
import { CreateChatDto } from '../../../intraestructure/dto/create/CreateChatDTO';
import { ChatDomainEntity } from '../../../domain/entity/ChatEntity';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrl: './index.component.css',
})
export class IndexComponent implements OnInit, OnDestroy, AfterViewInit {
  usuarios: ChatUsuarioDomainEntity[] = [];
  chats: ChatDomainEntity[] = [];

  delegateChat = chatUseCaseProviders;
  delegateChatmensaje = chatMensajeUseCaseProviders;

  sweet = new SweetAlert();
  private onDestroy$: Subject<void> = new Subject<void>();

  selectedChat: { id: string, name: string } | null = null;

  constructor(private router: Router, private chatServicio: ChatService) {}
  ngAfterViewInit(): void {
    window.scrollTo(0, 0); // Renderizar hacia arriba de la pantalla
  }

  ngOnInit() {
    this.getAllChatUsuarios();
    this.getAllChat();
  }
  user = '';

  getAllChatUsuarios() {
    this.delegateChat.getAllChatUsuariosUseCaseProvider
      .useFactory(this.chatServicio)
      .execute();

    this.delegateChat.getAllChatUsuariosUseCaseProvider
      .useFactory(this.chatServicio)
      .statusEmmit.subscribe({
        next: (value: ChatUsuarioDomainEntity[]) => {
          this.usuarios = value;
          console.log('usuarios : ' + JSON.stringify(this.usuarios, null, 2));
        },
        error: () => {
          this.sweet.toFire('usuarios', 'Error al Obtener Curso', 'error');
        },
      });
  }
  getAllChat() {
    this.delegateChat.getAllChatUseCaseProvider
      .useFactory(this.chatServicio)
      .execute();

    this.delegateChat.getAllChatUseCaseProvider
      .useFactory(this.chatServicio)
      .statusEmmit.subscribe({
        next: (value: ChatDomainEntity[]) => {
          this.chats = value;
          console.log('chats : ' + JSON.stringify(this.chats, null, 2));
        },
        error: () => {
          this.sweet.toFire('chats', 'Error al Obtener los Chat', 'error');
        },
      });
  }

  ngOnDestroy(): void {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }
  refresh() {
    this.delegateChat.getAllChatUsuariosUseCaseProvider
      .useFactory(this.chatServicio)
      .execute();
  }

  refreshChats() {
    this.delegateChat.getAllChatUseCaseProvider
      .useFactory(this.chatServicio)
      .execute();
  }

  chat!: CreateChatDto;
  EmpezarChat(id: string) {
    this.chat.privado = true;
    this.chat.usuarioCreadorId = 'daab3a7e-ef31-4a50-76bc-08dc783e5d0e';
    this.chat.usuarioInvitadoId = id;
    this.delegateChat.crearChatUseCaseProvider
      .useFactory(this.chatServicio)
      .execute(this.chat)
      .subscribe({
        next: (value) => {
          this.router.navigate([`chat/${value.value?.id}`]);
        },
        error: () => {
          this.sweet.toFire('Curso', 'Error al crear chat', 'error');
        },
      });
  }

  irChat(id: string, name: string) {
    this.selectedChat = { id, name };
    // this.router.navigate([`chat/${id}/${usuarioName}`]);
  }
}
