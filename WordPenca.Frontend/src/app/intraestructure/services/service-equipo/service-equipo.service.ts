import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EquipoService } from '../../../domain/services/EquipoService';
import { Observable, map } from 'rxjs';
import { EquipoDomainEntity } from '../../../domain/entity/EquipoEntity';
import { CreateEquipoDto } from '../../dto/create/CreateEquipoDTO';
import { UpdateEquipoDto } from '../../dto/create/UpdateEquipoDTO';
import { ResponseDomainEntity } from '../../../domain/entity/ResponseEntity';

@Injectable({
  providedIn: 'root'
})
export class EquipoImplentationService extends EquipoService {
 
  URL = 'http://localhost:5118';
  
  constructor(private http: HttpClient) {
    super();
  }

  getAll(): Observable<ResponseDomainEntity<EquipoDomainEntity[]>> {

    return this.http.get<ResponseDomainEntity<EquipoDomainEntity[]>>(
      `${this.URL}/Equipo`
    );
  }

  create(data: CreateEquipoDto): Observable<ResponseDomainEntity<EquipoDomainEntity>> {
    return this.http.post<ResponseDomainEntity<EquipoDomainEntity>>(
      `${this.URL}/Equipo/Crear`,data);
  }


  update(id: string, entity: UpdateEquipoDto): Observable<ResponseDomainEntity<EquipoDomainEntity>> {
    throw new Error('Method not implemented.');
  }
  delete(id: string): Observable<boolean> {
    throw new Error('Method not implemented.');
  }
  get(id: string): Observable<ResponseDomainEntity<EquipoDomainEntity>> {
    throw new Error('Method not implemented.');
  }
  getByName(titulo: string): Observable<ResponseDomainEntity<EquipoDomainEntity>> {
    throw new Error('Method not implemented.');
  }


}
