import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from './BaseService';
import { ResponseDomainEntity } from '../entity/ResponseEntity';
import { ChatMensajeDomainEntity } from '../entity/ChatMensajeEntity';
import { CreateChatMensajeDto } from '../../intraestructure/dto/create/CreateChatMensajeDTO';
import { UpdateChatMensajeDto } from '../../intraestructure/dto/update/updateChatMensajeDTO';

@Injectable({
  providedIn: 'root',
})
export abstract class ChatMensajeService extends BaseService<ChatMensajeDomainEntity> {
  abstract create(
    data: CreateChatMensajeDto
  ): Observable<ResponseDomainEntity<ChatMensajeDomainEntity>>;
  abstract update(
    id: string,
    entity: UpdateChatMensajeDto
  ): Observable<ResponseDomainEntity<ChatMensajeDomainEntity>>;
}
