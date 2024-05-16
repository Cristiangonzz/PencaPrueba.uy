import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RoutingChatModule } from './routing-chat.module';
import { ChatComponent } from './chat.component';
import { ChatService } from '../../application/use-case/chat/chat-service.use-case';

@NgModule({
  declarations: [ChatComponent],
  imports: [
    CommonModule,
    RoutingChatModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [ChatService],
  exports: [ChatComponent],
})
export class ChatModule {}
