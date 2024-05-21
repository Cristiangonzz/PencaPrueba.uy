import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { ResponseDomainEntity } from '../../../domain/entity/ResponseEntity';
import { ChatService } from '../../../domain/services/ChatService';
import { CreateChatDto } from '../../dto/create/CreateChatDTO';
import { UpdateChatDto } from '../../dto/update/updateChatDTO';
import { ChatHistorialDomainEntity } from '../../../domain/entity/ChatHistorialEntity';
import { IChatDomain } from '../../../domain/interfaces/chat/IChatDomain';
import { IChatUsuarioDomain } from '../../../domain/interfaces/chat/IChatUsuarioDomain';

@Injectable({
  providedIn: 'root',
})
export class chatImplentationService extends ChatService {
  URL = 'http://localhost:5118';

  constructor(private http: HttpClient) {
    super();
  }

  getAll(): Observable<ResponseDomainEntity<IChatDomain[]>> {
    return this.http.get<ResponseDomainEntity<IChatDomain[]>>(
      `${this.URL}/chat/getAllChats`
    );
  }

  create(data: CreateChatDto): Observable<ResponseDomainEntity<IChatDomain>> {
    return this.http.post<ResponseDomainEntity<IChatDomain>>(
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
  ): Observable<ResponseDomainEntity<IChatDomain>> {
    throw new Error('Method not implemented.');
  }
  delete(id: string): Observable<boolean> {
    throw new Error('Method not implemented.');
  }
  get(id: string): Observable<ResponseDomainEntity<IChatDomain>> {
    return this.http.get<ResponseDomainEntity<IChatDomain>>(
      `${this.URL}/chat/obtenerChat/${id}`
    );
  }

  getAllChatUsuarios(): Observable<ResponseDomainEntity<IChatUsuarioDomain[]>> {
    return this.http.get<ResponseDomainEntity<IChatUsuarioDomain[]>>(
      `${this.URL}/chat/getAllChatUsuarios`
    );
  }
  getOneChatUsuario(
    id: string
  ): Observable<ResponseDomainEntity<IChatUsuarioDomain>> {
    return this.http.get<ResponseDomainEntity<IChatUsuarioDomain>>(
      `${this.URL}/chat/obtenerUsuario/${id}`
    );
  }

  getByName(titulo: string): Observable<ResponseDomainEntity<IChatDomain>> {
    throw new Error('Method not implemented.');
  }
}
