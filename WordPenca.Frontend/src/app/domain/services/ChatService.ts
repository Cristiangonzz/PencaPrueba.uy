import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from './BaseService';
import { ResponseDomainEntity } from '../entity/ResponseEntity';
import { ChatDomainEntity } from '../entity/ChatEntity';
import { CreateChatDto } from '../../intraestructure/dto/create/CreateChatDTO';
import { UpdateChatDto } from '../../intraestructure/dto/update/updateChatDTO';
import { ChatHistorialDomainEntity } from '../entity/ChatHistorialEntity';
import { ChatUsuarioDomainEntity } from '../entity/ChatUsuarioEntity';

@Injectable({
  providedIn: 'root',
})
export abstract class ChatService extends BaseService<ChatDomainEntity> {
  abstract create(
    data: CreateChatDto
  ): Observable<ResponseDomainEntity<ChatDomainEntity>>;
  abstract update(
    id: string,
    entity: UpdateChatDto
  ): Observable<ResponseDomainEntity<ChatDomainEntity>>;

  abstract getChatHistorial(
    idChat: string
  ): Observable<ResponseDomainEntity<ChatHistorialDomainEntity>>;

  abstract getAllChatUsuarios(): Observable<
    ResponseDomainEntity<ChatUsuarioDomainEntity[]>
  >;
  abstract getOneChatUsuario(
    id: string
  ): Observable<ResponseDomainEntity<ChatUsuarioDomainEntity>>;
}
