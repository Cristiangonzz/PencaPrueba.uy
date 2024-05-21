import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RoutingChatModule } from './routing-chat.module';
import { ChatComponent } from './chat.component';
import { ChatHubService } from '../../application/use-case/chat/chat-hub-service.use-case';
import { BrowserModule } from '@angular/platform-browser';
import { HomeModule } from '../home/home.module';

@NgModule({
  declarations: [ChatComponent],
  imports: [
    CommonModule,
    RoutingChatModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
 
  ],
  providers: [ChatHubService],
  exports: [ChatComponent],
})
export class ChatModule {}
