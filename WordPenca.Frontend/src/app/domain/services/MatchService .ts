import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { CreateEquipoDto } from '../../intraestructure/dto/create/CreateEquipoDTO';
import { BaseService } from './BaseService';
import { UpdateEquipoDto } from '../../intraestructure/dto/create/UpdateEquipoDTO';

import { ResponseDomainEntity } from '../entity/ResponseEntity';
import { IMatcheDomain } from '../interfaces/ApiMatches/IMatcheDomain';

@Injectable({
  providedIn: 'root',
})
export abstract class MatchService extends BaseService<IMatcheDomain> {
  abstract create(data: CreateEquipoDto): Observable<ResponseDomainEntity<IMatcheDomain>>;
  abstract update(id: string, entity: UpdateEquipoDto): Observable<ResponseDomainEntity<IMatcheDomain>>;
}
