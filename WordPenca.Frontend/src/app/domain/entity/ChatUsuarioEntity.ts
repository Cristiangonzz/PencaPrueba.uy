import { IChatUsuarioDomain } from '../interfaces/chat/IChatUsuarioDomain';

export class ChatUsuarioDomainEntity implements IChatUsuarioDomain {
  id: string ;
  nombre: string;
  chat: string[];

  constructor(chat: string[], id: string, nombre: string) {
    this.id = id as string;
    this.chat = chat as string[];
    this.nombre = nombre as string;
  }
}
