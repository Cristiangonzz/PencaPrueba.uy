import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { ResponseDomainEntity } from '../../../domain/entity/ResponseEntity';
import { ChatMensajeService } from '../../../domain/services/ChatMensajeService';
import { ChatMensajeDomainEntity } from '../../../domain/entity/ChatMensajeEntity';
import { CreateChatMensajeDto } from '../../dto/create/CreateChatMensajeDTO';
import { UpdateChatMensajeDto } from '../../dto/update/updateChatMensajeDTO';

@Injectable({
  providedIn: 'root',
})
export class ChatMensajeImplentationService extends ChatMensajeService {
  URL = 'http://localhost:5118';

  constructor(private http: HttpClient) {
    super();
  }

  getAll(): Observable<ResponseDomainEntity<ChatMensajeDomainEntity[]>> {
    return this.http.get<ResponseDomainEntity<ChatMensajeDomainEntity[]>>(
      `${this.URL}/chat/getAllChats`
    );
  }

  create(
    data: CreateChatMensajeDto
  ): Observable<ResponseDomainEntity<ChatMensajeDomainEntity>> {
    return this.http.post<ResponseDomainEntity<ChatMensajeDomainEntity>>(
      `${this.URL}/chat/CrearMensaje`,
      data
    );
  }

  update(
    id: string,
    entity: UpdateChatMensajeDto
  ): Observable<ResponseDomainEntity<ChatMensajeDomainEntity>> {
    throw new Error('Method not implemented.');
  }
  delete(id: string): Observable<boolean> {
    throw new Error('Method not implemented.');
  }
  get(id: string): Observable<ResponseDomainEntity<ChatMensajeDomainEntity>> {
    throw new Error('Method not implemented.');
  }
  getByName(
    titulo: string
  ): Observable<ResponseDomainEntity<ChatMensajeDomainEntity>> {
    throw new Error('Method not implemented.');
  }
}
