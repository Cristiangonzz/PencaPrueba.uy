import { BehaviorSubject, Subject } from 'rxjs';
import { Injectable } from '@angular/core';
//import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import * as signalR from '@microsoft/signalr';
@Injectable({
  providedIn: 'root',
})
export class ChatHubService {
  //Subject para los mensajes que se recibe
  public userName = '';
  public groupName = '';
  public messageToSend = '';
  public joined = false;

  public conexionUsuario!: Subject<boolean>;
  public content!: NewMessage[];
  public canalMesaggeEmmit$: BehaviorSubject<NewMessage[]> =
    new BehaviorSubject<NewMessage[]>(this.content);

  public conversation: NewMessage[] = [
    {
      userName: 'Sistema',
      message: 'Bienvenido',
    },
  ];
  // private connection: HubConnection;
  public connection: signalR.HubConnection = new signalR.HubConnectionBuilder()
    .withUrl('http://localhost:5000/hubs/chat')
    .configureLogging(signalR.LogLevel.Information)
    .build();
  constructor() {
    //se puede hacer de dos maneras, esta y por atributo
    // this.connection = new HubConnectionBuilder()
    //   .withUrl('http://localhost:5118/hubs/chat')
    //   .build();

    this.conexionWebSocket();
    this.connection.on('NewUser', (message: string) => this.newUser(message));
    this.connection.on('NewMessage', (message: NewMessage) =>
      this.newMessage(message)
    );
    this.connection.on('LeftUser', (message: string) => this.leftUser(message));
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
      this.connection
        .invoke('SendMessage', newMessage)
        .then((_) => (this.messageToSend = ''));
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

  public newUser(message: string): void {
    console.log(message);
    this.conversation.push({
      userName: 'Sistema',
      message: message,
    });
    this.content = this.conversation;
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

  public newMessage(message: NewMessage): void {
    console.log(message);
    this.conversation.push(message);
    this.content = this.conversation;
    this.canalMesaggeEmmit$.next(this.content);
  }

  public leftUser(message: string): void {
    console.log(message);
    this.conversation.push({
      userName: 'Sistema',
      message: message,
    });

    this.content = this.conversation;
    this.canalMesaggeEmmit$.next(this.content);
  }
}
interface NewMessage {
  userName: string;
  message: string;
}
interface EnvioNewMessage {
  message: string;
  chatId: string;
  userId: string;
}
