import { IChatHistorialDomain } from './IChatHistorialDomain';
import { IChatUsuarioDomain } from './IChatUsuarioDomain';

export interface IChatDomain {
  id: string;
  nombre?: string;
  privado: boolean;
  historial: IChatHistorialDomain;
  description?: string;
  usuario: IChatUsuarioDomain[];
  creationDate?: Date | string | null;
}
