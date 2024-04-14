import { IEquipoDomain } from "../interfaces/IEquipoDomain";

export class EquipoDomainEntity implements IEquipoDomain {
  id?: string;
  name?: string;
  activo?: boolean;


  constructor(
    id?: string,

    name?: string,
    activo?: boolean,
   
  ) {
    this.id = id as string;
    this.name = name as string;
    this.activo = activo as boolean;
  }
}
