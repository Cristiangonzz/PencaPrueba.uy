import { IChatDomain } from './IChatDomain';
import { IChatMensajeDomain } from './IChatMensajeDomain';

export interface IChatHistorialDomain {
  id?: string;
  chat: IChatDomain;
  chatMensaje: IChatMensajeDomain[];
  creationDate?: Date | string | null;
}
