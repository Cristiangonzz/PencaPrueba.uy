import { Observable } from 'rxjs';

import { Injectable } from '@angular/core';
import { ResponseDomainEntity } from '../entity/ResponseEntity';

@Injectable({
  providedIn: 'root',
})
export abstract class BaseService<T> {
  abstract delete(id: string): Observable<boolean>;
  abstract get(id: string): Observable<ResponseDomainEntity<T>>;
  abstract getAll(): Observable<ResponseDomainEntity<T[]>>;
  abstract getByName(titulo: string): Observable<ResponseDomainEntity<T>>;

}
