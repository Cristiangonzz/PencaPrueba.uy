import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ChatService } from '../../../domain/services/ChatService';
import { ResponseDomainEntity } from '../../../domain/entity/ResponseEntity';
import { ChatHistorialDomainEntity } from '../../../domain/entity/ChatHistorialEntity';

@Injectable({
  providedIn: 'root',
})
export class GetChatHistorialUseCase {
  constructor(private chatService: ChatService) {}

  execute(
    data: string
  ): Observable<ResponseDomainEntity<ChatHistorialDomainEntity>> {
    return this.chatService.getChatHistorial(data);
  }
}
