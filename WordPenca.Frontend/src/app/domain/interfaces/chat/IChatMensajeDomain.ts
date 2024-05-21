export interface IChatMensajeDomain {
  id: string;
  mensaje: string;
  activo: boolean;
  respuestaMensaje?: string;
  description?: string;
  usuario: string;
  usuarioName: string;
  creationDate?: Date | string | null;
}
