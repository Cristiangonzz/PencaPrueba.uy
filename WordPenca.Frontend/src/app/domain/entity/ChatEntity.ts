import { IChatDomain } from '../interfaces/chat/IChatDomain';
import { IChatHistorialDomain } from '../interfaces/chat/IChatHistorialDomain';
import { IChatUsuarioDomain } from '../interfaces/chat/IChatUsuarioDomain';

export class ChatDomainEntity implements IChatDomain {
  id: string;
  nombre?: string | undefined;
  privado: boolean;
  historial: IChatHistorialDomain;
  description?: string | undefined;
  usuario: IChatUsuarioDomain[];
  creationDate?: string | Date | null | undefined;

  constructor(
    privado: boolean,
    historial: IChatHistorialDomain,
    usuario: IChatUsuarioDomain[],
    id: string,
    nombre?: string,
    description?: string,
    creationDate?: string | Date | null
  ) {
    this.id = id as string;
    this.nombre = nombre as string;
    this.description = description as string;
    this.privado = privado as boolean;
    this.historial = historial as IChatHistorialDomain;
    this.usuario = usuario as IChatUsuarioDomain[];
    this.creationDate = creationDate as string | Date | null;
  }
}
