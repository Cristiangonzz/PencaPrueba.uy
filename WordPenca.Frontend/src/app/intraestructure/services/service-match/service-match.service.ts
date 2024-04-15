import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { EquipoDomainEntity } from '../../../domain/entity/EquipoEntity';
import { CreateEquipoDto } from '../../dto/create/CreateEquipoDTO';
import { UpdateEquipoDto } from '../../dto/create/UpdateEquipoDTO';
import { ResponseDomainEntity } from '../../../domain/entity/ResponseEntity';
import { MatchService } from '../../../domain/services/MatchService ';
import { IMatcheDomain } from '../../../domain/interfaces/ApiMatches/IMatcheDomain';
import { IAllMatchesDomain } from '../../../domain/interfaces/ApiMatches/IAllMatches';

@Injectable({
  providedIn: 'root'
})
export class MatchImplentationService extends MatchService {
 
  URL = 'http://localhost:5151/Equipo/matches';
  
  constructor(private http: HttpClient) {
    super();
  }

  //getAll(): Observable<IMatcheDomain[]> {

  //  return this.http.get<IAllMatchesDomain>(
  //    `${this.URL}/Equipo`
  //  );
//}

  override create(data: CreateEquipoDto): Observable < ResponseDomainEntity < IMatcheDomain >> {
  throw new Error('Method not implemented.');
}
  override update(id: string, entity: UpdateEquipoDto): Observable < ResponseDomainEntity < IMatcheDomain >> {
  throw new Error('Method not implemented.');
}
  override delete (id: string): Observable < boolean > {
  throw new Error('Method not implemented.');
}
  override get(id: string): Observable < ResponseDomainEntity < IMatcheDomain >> {
  throw new Error('Method not implemented.');
  }


  override  getAll(): Observable<ResponseDomainEntity<IMatcheDomain[]>> {
    throw new Error('Method not implemented.');
   /* return this.http.get<ResponseDomainEntity<IMatcheDomain[]>(this.URL);*/
}

  override getByName(titulo: string): Observable<ResponseDomainEntity<IMatcheDomain>> {
    throw new Error('Method not implemented.');
  }

}
