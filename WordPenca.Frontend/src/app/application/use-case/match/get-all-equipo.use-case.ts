import { BehaviorSubject, Observable, asyncScheduler } from 'rxjs';
import { Injectable } from '@angular/core';
import { MatchService } from '../../../domain/services/MatchService ';
import { IMatcheDomain } from '../../../domain/interfaces/ApiMatches/IMatcheDomain';
import { ResponseDomainEntity } from '../../../domain/entity/ResponseEntity';


@Injectable({
  providedIn: 'root',
})
export class GetAllMatchUseCase {
  private status!: IMatcheDomain[];
  private number: number = 0;
  private statusEmmit: BehaviorSubject<IMatcheDomain[]> = new BehaviorSubject<
    IMatcheDomain[]
  >(this.status);

  constructor(private matchService: MatchService) { }
   
  execute = () => {
    if (this.statusEmmit.observed && !this.statusEmmit.closed) {
      this.matchService.getAll().subscribe({
        next: (value: ResponseDomainEntity<IMatcheDomain[]>) => {
          this.status = value.value as IMatcheDomain[];
        },
        complete: () => {
          this.statusEmmit.next(this.status);
        },
      });
    } else {
      asyncScheduler.schedule(this.execute, 100);
    }
  };

  getAllMatchObservable(): Observable<IMatcheDomain[]>{
    return this.statusEmmit.asObservable();
  }

}
