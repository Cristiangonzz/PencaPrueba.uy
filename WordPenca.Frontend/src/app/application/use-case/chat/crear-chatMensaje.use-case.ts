import { Observable } from 'rxjs';
import { ResponseDomainEntity } from '../../../domain/entity/ResponseEntity';
import { ChatMensajeService } from '../../../domain/services/ChatMensajeService';
import { CreateChatMensajeDto } from '../../../intraestructure/dto/create/CreateChatMensajeDTO';
import { ChatMensajeDomainEntity } from '../../../domain/entity/ChatMensajeEntity';

export class CrearChatMensajeUseCase {
  constructor(private chatMensajeService: ChatMensajeService) {}

  execute(
    param: CreateChatMensajeDto
  ): Observable<ResponseDomainEntity<ChatMensajeDomainEntity>> {
    return this.chatMensajeService.create(param);
  }
}
