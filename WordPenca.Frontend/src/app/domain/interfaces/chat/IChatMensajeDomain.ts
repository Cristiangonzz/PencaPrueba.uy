export interface IChatMensajeDomain {
  id?: string;
  mensaje: string;
  activo: boolean;
  respuestaMensaje?: string;
  description?: string;
  usuario: string;
  creationDate?: Date | string | null;
}
