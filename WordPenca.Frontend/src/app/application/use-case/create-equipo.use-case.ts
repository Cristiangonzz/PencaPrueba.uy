import { BehaviorSubject, Observable, asyncScheduler } from 'rxjs';
import { Injectable } from '@angular/core';
import { EquipoDomainEntity } from '../../domain/entity/EquipoEntity';
import { EquipoService } from '../../domain/services/EquipoService';
import { ResponseDomainEntity } from '../../domain/entity/ResponseEntity';
import { CreateEquipoDto } from '../../intraestructure/dto/create/CreateEquipoDTO';


@Injectable({
  providedIn: 'root',
})
export class CreateEquipoUseCase {
  constructor(private equipoService: EquipoService) { }

  execute(param: CreateEquipoDto): Observable<ResponseDomainEntity<EquipoDomainEntity>> {
    return this.equipoService.create(param);
  }
}
