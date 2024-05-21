import { BehaviorSubject, Subject } from 'rxjs';
import { Injectable } from '@angular/core';
//import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import * as signalR from '@microsoft/signalr';
import { ChatMensajeDomainEntity } from '../../../domain/entity/ChatMensajeEntity';
@Injectable({
  providedIn: 'root',
})
export class ChatHubService {
  public conexionUsuario!: Subject<boolean>;
  public content!: ChatMensajeDomainEntity;
  public canalMesaggeEmmit$: BehaviorSubject<ChatMensajeDomainEntity> =
    new BehaviorSubject<ChatMensajeDomainEntity>(this.content);

  // private connection: HubConnection;
  public connection: signalR.HubConnection = new signalR.HubConnectionBuilder()
    .withUrl('http://localhost:5118/hubs/chat')
    .configureLogging(signalR.LogLevel.Information)
    .build();
  constructor() {
    //se puede hacer de dos maneras, esta y por atributo
    // this.connection = new HubConnectionBuilder()
    //   .withUrl('http://localhost:5118/hubs/chat')
    //   .build();

    this.conexionWebSocket();
    this.connection.on('NewUser', (message: ChatMensajeDomainEntity) =>
      this.newUser(message)
    );
    this.connection.on('NewMessage', (message: ChatMensajeDomainEntity) =>
      this.newMessage(message)
    );
    this.connection.on('LeftUser', (message: ChatMensajeDomainEntity) =>
      this.leftUser(message)
    );
  }
  public async conexionWebSocket() {
    await this.connection
      .start()
      .then((_) => {
        console.log('Connection Started');
      })
      .catch((error) => {
        return console.error(error);
      });
  }
  //(string? UserName, string Message, string? GroupName, Guid ChatId, Guid UserId);
  public sendMessage(newMessage: EnvioNewMessage): void {
    if (this.connection.state === 'Connected') {
      this.connection.invoke('SendMessage', newMessage);
    } else {
      console.error('La conexión no está en estado Connected.');
      // Puedes manejar este caso según tus necesidades, como intentar reconectar automáticamente.
    }
  }

  public async leave(usuarioId: string, chatId: string) {
    this.connection
      .invoke('LeaveGroup', usuarioId, chatId)
      .then((_) => this.conexionUsuario.next(false));
  }

  public newUser(message: ChatMensajeDomainEntity): void {
    console.log(message);
    this.content = message;
    this.canalMesaggeEmmit$.next(this.content);
  }

  public join(chatId: string, usuarioId: string) {
    if (this.connection.state === 'Connected') {
      this.connection.invoke('JoinGroup', chatId, usuarioId).then((_) => {
        this.conexionUsuario.next(true);
      });
    } else {
      console.error('La conexión no está en estado Connected.');
      // Puedes manejar este caso según tus necesidades, como intentar reconectar automáticamente.
    }
  }

  public newMessage(message: ChatMensajeDomainEntity): void {
    console.log('Mensaje del emisor : ' + message);

    this.content = message;
    this.canalMesaggeEmmit$.next(this.content);
  }

  public leftUser(message: ChatMensajeDomainEntity): void {
    console.log(message);
    this.content = message;
    this.canalMesaggeEmmit$.next(this.content);
  }
}
interface EnvioNewMessage {
  Message: string;
  ChatId: string;
  UsuarioId: string;
  UsuarioName: string;
}
