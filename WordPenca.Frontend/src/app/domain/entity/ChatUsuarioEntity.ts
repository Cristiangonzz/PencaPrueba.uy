import { IChatUsuarioDomain } from '../interfaces/chat/IChatUsuarioDomain';

export class ChatUsuarioDomainEntity implements IChatUsuarioDomain {
  id: string;
  name: string;
  chats: string[];

  constructor(id: string, name: string, chats: string[]) {
    this.id = id as string;
    this.name = name as string;
    this.chats = chats as string[];
  }
}
