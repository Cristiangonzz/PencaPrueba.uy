import { BehaviorSubject, Observable, asyncScheduler } from 'rxjs';
import { Injectable } from '@angular/core';
import { EquipoDomainEntity } from '../../domain/entity/EquipoEntity';
import { EquipoService } from '../../domain/services/EquipoService';
import { ResponseDomainEntity } from '../../domain/entity/ResponseEntity';


@Injectable({
  providedIn: 'root',
})
export class GetAllEquipoUseCase {
  private status!: ResponseDomainEntity<EquipoDomainEntity[]>;
  private number: number = 0;
  private statusEmmit: BehaviorSubject<ResponseDomainEntity<EquipoDomainEntity[]>> = new BehaviorSubject<
    ResponseDomainEntity<EquipoDomainEntity[]>
  >(this.status);

  constructor(private equipoService: EquipoService) { }
   
  execute = () => {
    if (this.statusEmmit.observed && !this.statusEmmit.closed) {
      this.equipoService.getAll().subscribe({
        next: (value: ResponseDomainEntity<EquipoDomainEntity[]>) => {
          this.status = value;
        },
        complete: () => {
          this.statusEmmit.next(this.status);
        },
      });
    } else {
      asyncScheduler.schedule(this.execute, 100);
    }
  };
  getAllEquipoObservable(): Observable<ResponseDomainEntity<EquipoDomainEntity[]>>{
    return this.statusEmmit.asObservable();
  }

}
