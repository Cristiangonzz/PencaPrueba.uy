import { IChatDomain } from './IChatDomain';
import { IChatMensajeDomain } from './IChatMensajeDomain';

export interface IChatHistorialDomain {
  id: string;
  chat: IChatDomain;
  mensajes: IChatMensajeDomain[];
  creationDate?: Date | string | null;
}
