import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from './BaseService';
import { ResponseDomainEntity } from '../entity/ResponseEntity';
import { CreateChatDto } from '../../intraestructure/dto/create/CreateChatDTO';
import { UpdateChatDto } from '../../intraestructure/dto/update/updateChatDTO';
import { ChatHistorialDomainEntity } from '../entity/ChatHistorialEntity';
import { IChatDomain } from '../interfaces/chat/IChatDomain';
import { IChatHistorialDomain } from '../interfaces/chat/IChatHistorialDomain';
import { IChatUsuarioDomain } from '../interfaces/chat/IChatUsuarioDomain';

@Injectable({
  providedIn: 'root',
})
export abstract class ChatService extends BaseService<IChatDomain> {
  abstract create(
    data: CreateChatDto
  ): Observable<ResponseDomainEntity<IChatDomain>>;
  abstract update(
    id: string,
    entity: UpdateChatDto
  ): Observable<ResponseDomainEntity<IChatDomain>>;

  abstract getChatHistorial(
    idChat: string
  ): Observable<ResponseDomainEntity<ChatHistorialDomainEntity>>;

  abstract getAllChatUsuarios(): Observable<
    ResponseDomainEntity<IChatUsuarioDomain[]>
  >;
  abstract getOneChatUsuario(
    id: string
  ): Observable<ResponseDomainEntity<IChatUsuarioDomain>>;
}
