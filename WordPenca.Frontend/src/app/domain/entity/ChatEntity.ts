import { IChatDomain } from '../interfaces/chat/IChatDomain';
import { IChatHistorialDomain } from '../interfaces/chat/IChatHistorialDomain';
import { IChatUsuarioDomain } from '../interfaces/chat/IChatUsuarioDomain';

export class ChatDomainEntity implements IChatDomain {
  id: string;
  name?: string | undefined;
  privado: boolean;
  historial?: IChatHistorialDomain | null;
  description?: string | undefined;
  usuarios: IChatUsuarioDomain[];
  creationDate?: string | Date | null | undefined;


  constructor(
    privado: boolean,
    historial: IChatHistorialDomain,
    usuarios: IChatUsuarioDomain[],
    id: string,
    name?: string,
    description?: string,
    creationDate?: string | Date | null
  ) {
    this.id = id ;
    this.name = name ;
    this.description = description ;
    this.privado = privado;
    this.historial = historial as IChatHistorialDomain | null;
    this.usuarios = usuarios as IChatUsuarioDomain[];
    this.creationDate = creationDate as  Date | null;
  }
}
