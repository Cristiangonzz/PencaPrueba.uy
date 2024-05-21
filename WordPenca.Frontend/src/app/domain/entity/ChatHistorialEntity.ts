import { IChatDomain } from '../interfaces/chat/IChatDomain';
import { IChatHistorialDomain } from '../interfaces/chat/IChatHistorialDomain';
import { IChatMensajeDomain } from '../interfaces/chat/IChatMensajeDomain';

export class ChatHistorialDomainEntity implements IChatHistorialDomain {
  id: string;
  chat: IChatDomain;
  mensajes: IChatMensajeDomain[];
  creationDate?: string | Date | null | undefined;

  constructor(
    chat: IChatDomain,
    mensajes: IChatMensajeDomain[],
    id: string,
    creationDate?: string | Date | null
  ) {
    this.id = id;
    this.chat = chat as IChatDomain;
    this.mensajes = mensajes as IChatMensajeDomain[];
    this.creationDate = creationDate as string | Date | null;
  }
}
