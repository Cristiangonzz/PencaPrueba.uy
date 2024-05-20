import { IChatUsuarioDomain } from '../interfaces/chat/IChatUsuarioDomain';

export class ChatUsuarioDomainEntity implements IChatUsuarioDomain {
  id: string ;
  name: string;
  chats: string[];

  constructor(id: string, name: string, chats: string[]) {
    this.id = id ;
    this.name = name;
    this.chats = chats;
  }
}
