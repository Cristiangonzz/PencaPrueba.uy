import { IChatMensajeDomain } from '../interfaces/chat/IChatMensajeDomain';

export class ChatMensajeDomainEntity implements IChatMensajeDomain {
  id: string;
  mensaje: string;
  activo: boolean;
  respuestaMensaje?: string | undefined;
  description?: string | undefined;
  usuario: string;
  usuarioName: string;
  creationDate?: string | Date | null | undefined;

  constructor(
    activo: boolean,
    mensaje: string,
    usuario: string,
    usuarioName: string,

    id: string,
    respuestaMensaje?: string,
    description?: string,
    creationDate?: string | Date | null
  ) {
    this.id = id as string;
    this.mensaje = mensaje as string;
    this.description = description as string;
    this.activo = activo as boolean;
    this.respuestaMensaje = respuestaMensaje as string;
    this.usuario = usuario as string;
    this.usuarioName = usuarioName as string;

    this.creationDate = creationDate as string | Date | null;
  }
}
