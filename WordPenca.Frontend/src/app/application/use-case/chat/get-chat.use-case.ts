import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ChatService } from '../../../domain/services/ChatService';
import { ResponseDomainEntity } from '../../../domain/entity/ResponseEntity';
import { ChatDomainEntity } from '../../../domain/entity/ChatEntity';

@Injectable({
  providedIn: 'root',
})
export class GetChatUseCase {
  constructor(private chatService: ChatService) {}

  execute(data: string): Observable<ResponseDomainEntity<ChatDomainEntity>> {
    return this.chatService.get(data);
  }
}
