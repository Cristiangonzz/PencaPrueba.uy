import { BehaviorSubject, asyncScheduler } from 'rxjs';
import { Injectable } from '@angular/core';
import { ChatDomainEntity } from '../../../domain/entity/ChatEntity';
import { ChatService } from '../../../domain/services/ChatService';
import { ResponseDomainEntity } from '../../../domain/entity/ResponseEntity';
import { ChatUsuarioDomainEntity } from '../../../domain/entity/ChatUsuarioEntity';
import { IChatUsuarioDomain } from '../../../domain/interfaces/chat/IChatUsuarioDomain';

@Injectable({
  providedIn: 'root',
})
export class GetAllChatUsuariosUseCase {
  private status: ChatUsuarioDomainEntity[] = [];

  public statusEmmit: BehaviorSubject<ChatUsuarioDomainEntity[]> =
    new BehaviorSubject<ChatUsuarioDomainEntity[]>(this.status);

  constructor(private chatService: ChatService) {}

  execute = () => {
    if (this.statusEmmit.observed && !this.statusEmmit.closed) {
      this.chatService.getAllChatUsuarios().subscribe({
        next: (value: ResponseDomainEntity<ChatUsuarioDomainEntity[]>) => {
          this.status = value.value!;
          console.
            log('status : ' + value);
        },
        complete: () => {
          this.statusEmmit.next(this.status);
        },
      });
    } else {
      asyncScheduler.schedule(this.execute, 100);
    }
  };
}
