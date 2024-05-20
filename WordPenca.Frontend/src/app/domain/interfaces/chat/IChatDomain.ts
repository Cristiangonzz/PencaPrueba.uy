import { IChatHistorialDomain } from './IChatHistorialDomain';
import { IChatUsuarioDomain } from './IChatUsuarioDomain';

export interface IChatDomain {
  id: string;
  name?: string;
  imagen?: string;
  description?: string;
  historial?: IChatHistorialDomain | null;
  usuarios: IChatUsuarioDomain[];
  privado: boolean;
  creationDate?: Date | string | null;
}
