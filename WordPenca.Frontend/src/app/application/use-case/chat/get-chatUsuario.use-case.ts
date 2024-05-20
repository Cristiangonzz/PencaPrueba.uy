import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ChatService } from '../../../domain/services/ChatService';
import { ResponseDomainEntity } from '../../../domain/entity/ResponseEntity';
import { ChatUsuarioDomainEntity } from '../../../domain/entity/ChatUsuarioEntity';

@Injectable({
  providedIn: 'root',
})
export class GetChatUsuarioUseCase {
  constructor(private chatService: ChatService) {}

  execute(
    data: string
  ): Observable<ResponseDomainEntity<ChatUsuarioDomainEntity>> {
    return this.chatService.getOneChatUsuario(data);
  }
}
