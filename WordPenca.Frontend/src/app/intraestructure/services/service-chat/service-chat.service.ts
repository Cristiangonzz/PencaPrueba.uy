import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { ResponseDomainEntity } from '../../../domain/entity/ResponseEntity';
import { ChatService } from '../../../domain/services/ChatService';
import { ChatDomainEntity } from '../../../domain/entity/ChatEntity';
import { CreateChatDto } from '../../dto/create/CreateChatDTO';
import { UpdateChatDto } from '../../dto/update/updateChatDTO';
import { ChatHistorialDomainEntity } from '../../../domain/entity/ChatHistorialEntity';
import { ChatUsuarioDomainEntity } from '../../../domain/entity/ChatUsuarioEntity';

@Injectable({
  providedIn: 'root',
})
export class chatImplentationService extends ChatService {
  URL = 'http://localhost:5118';

  constructor(private http: HttpClient) {
    super();
  }

  getAll(): Observable<ResponseDomainEntity<ChatDomainEntity[]>> {
    return this.http.get<ResponseDomainEntity<ChatDomainEntity[]>>(
      `${this.URL}/chat/getAllChats`
    );
  }

  create(
    data: CreateChatDto
  ): Observable<ResponseDomainEntity<ChatDomainEntity>> {
    return this.http.post<ResponseDomainEntity<ChatDomainEntity>>(
      `${this.URL}/chat/CrearChat`,
      data
    );
  }

  getChatHistorial(
    idChat: string
  ): Observable<ResponseDomainEntity<ChatHistorialDomainEntity>> {
    return this.http.get<ResponseDomainEntity<ChatHistorialDomainEntity>>(
      `${this.URL}/chat/obtenerHistorialChat/${idChat}`
    );
  }

  update(
    id: string,
    entity: UpdateChatDto
  ): Observable<ResponseDomainEntity<ChatDomainEntity>> {
    throw new Error('Method not implemented.');
  }
  delete(id: string): Observable<boolean> {
    throw new Error('Method not implemented.');
  }
  get(id: string): Observable<ResponseDomainEntity<ChatDomainEntity>> {
    return this.http.get<ResponseDomainEntity<ChatDomainEntity>>(
      `${this.URL}/chat/obtenerChat/${id}`
    );
  }

  getAllChatUsuarios(): Observable<
    ResponseDomainEntity<ChatUsuarioDomainEntity[]>
  > {
    return this.http.get<ResponseDomainEntity<ChatUsuarioDomainEntity[]>>(
      `${this.URL}/chat/getAllChatUsuarios`
    );
  }
  getOneChatUsuario(
    id: string
  ): Observable<ResponseDomainEntity<ChatUsuarioDomainEntity>> {
    return this.http.get<ResponseDomainEntity<ChatUsuarioDomainEntity>>(
      `${this.URL}/chat/obtenerUsuario/${id}`
    );
  }

  getByName(
    titulo: string
  ): Observable<ResponseDomainEntity<ChatDomainEntity>> {
    throw new Error('Method not implemented.');
  }
}
