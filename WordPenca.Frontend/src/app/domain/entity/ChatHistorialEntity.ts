import { IChatDomain } from '../interfaces/chat/IChatDomain';
import { IChatHistorialDomain } from '../interfaces/chat/IChatHistorialDomain';
import { IChatMensajeDomain } from '../interfaces/chat/IChatMensajeDomain';

export class ChatHistorialDomainEntity implements IChatHistorialDomain {
  id?: string | undefined;
  chat: IChatDomain;
  chatMensaje: IChatMensajeDomain[];
  creationDate?: string | Date | null | undefined;

  constructor(
    chat: IChatDomain,
    chatMensaje: IChatMensajeDomain[],
    id?: string,
    creationDate?: string | Date | null
  ) {
    this.id = id as string;
    this.chat = chat as IChatDomain;
    this.chatMensaje = chatMensaje as IChatMensajeDomain[];
    this.creationDate = creationDate as string | Date | null;
  }
}
