import { IChatMensajeDomain } from '../interfaces/chat/IChatMensajeDomain';

export class ChatMensajeDomainEntity implements IChatMensajeDomain {
  id?: string | undefined;
  mensaje: string;
  activo: boolean;
  respuestaMensaje?: string | undefined;
  description?: string | undefined;
  usuario: string;
  creationDate?: string | Date | null | undefined;

  constructor(
    activo: boolean,
    mensaje: string,
    usuario: string,
    respuestaMensaje?: string,
    id?: string,
    description?: string,
    creationDate?: string | Date | null
  ) {
    this.id = id as string;
    this.mensaje = mensaje as string;
    this.description = description as string;
    this.activo = activo as boolean;
    this.respuestaMensaje = respuestaMensaje as string;
    this.usuario = usuario as string;
    this.creationDate = creationDate as string | Date | null;
  }
}
