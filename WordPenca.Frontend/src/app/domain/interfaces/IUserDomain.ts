export interface IUserDomain {
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
}
