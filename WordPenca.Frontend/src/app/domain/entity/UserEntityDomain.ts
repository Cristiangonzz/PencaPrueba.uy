import { IUserDomain } from "../interfaces/IUserDomain";

export class UsuarioDomainEntity implements IUserDomain {
  id?: string;
  nombre?: string;
  apellido?: string;
  telefono?: string;
  usuario: string;
  foto?: string;
  tipo_usuario?: number;
  clave: string;
  email: string;
  vigente?: boolean;

  constructor(
    usuarioId?: string,
    nombre?: string,
    apellido?: string,
    telefono?: string,
    usuario?: string,
    foto?: string,
    tipo_usuario?: number,
    clave?: string,
    email?: string,
    vigente?: boolean,
  ) {
    this.id = usuarioId as string;
    this.nombre = nombre as string;
    this.apellido = apellido as string;
    this.telefono = telefono as string;
    this.usuario = usuario as string;
    this.foto = foto as string;
    this.clave = clave as string;
    this.email = email as string;
    this.tipo_usuario = tipo_usuario as number;
    this.vigente = vigente as boolean;

  }
}
