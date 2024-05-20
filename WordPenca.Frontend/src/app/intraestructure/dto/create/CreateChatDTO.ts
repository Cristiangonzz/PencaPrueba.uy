export interface CreateChatDto {
  usuarioCreadorId: string;
  usuarioInvitadoId?: string;
  privado: boolean;
  nombre?: string;
  Description?: string;
}
