import { Observable } from 'rxjs';
import { CreateChatDto } from '../../../intraestructure/dto/create/CreateChatDTO';
import { ChatDomainEntity } from '../../../domain/entity/ChatEntity';
import { ChatService } from '../../../domain/services/ChatService';
import { ResponseDomainEntity } from '../../../domain/entity/ResponseEntity';

export class CrearChatUseCase {
  constructor(private chatService: ChatService) {}

  execute(
    param: CreateChatDto
  ): Observable<ResponseDomainEntity<ChatDomainEntity>> {
    return this.chatService.create(param);
  }
}
