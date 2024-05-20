import { BehaviorSubject, asyncScheduler } from 'rxjs';
import { Injectable } from '@angular/core';
import { ChatDomainEntity } from '../../../domain/entity/ChatEntity';
import { ChatService } from '../../../domain/services/ChatService';
import { ResponseDomainEntity } from '../../../domain/entity/ResponseEntity';
import { IChatDomain } from '../../../domain/interfaces/chat/IChatDomain';

@Injectable({
  providedIn: 'root',
})
export class GetAllChatUseCase {
  private status: ChatDomainEntity[] = [];

  public statusEmmit: BehaviorSubject<ChatDomainEntity[]> = new BehaviorSubject<
    ChatDomainEntity[]
  >(this.status);

  constructor(private chatService: ChatService) {}

  execute = () => {
    if (this.statusEmmit.observed && !this.statusEmmit.closed) {
      this.chatService.getAll().subscribe({
        next: (value: ResponseDomainEntity<IChatDomain[]>) => {
          this.status = value.value!;
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
