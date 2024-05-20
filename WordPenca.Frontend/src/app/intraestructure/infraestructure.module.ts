import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { equipoUseCaseProviders } from './delegate/delegate-equipo/delegateEquipo';
import { EquipoService } from '../domain/services/EquipoService';
import { EquipoImplentationService } from './services/service-equipo/service-equipo.service';
import { MatchService } from '../domain/services/MatchService ';
import { matchUseCaseProviders } from './delegate/delegate-match/delegateMatch';
import { chatMensajeUseCaseProviders } from './delegate/delegate-chat-mensaje/delegateChatMensaje';
import { chatUseCaseProviders } from './delegate/delegate-chat/delegateChat';
import { ChatService } from '../domain/services/ChatService';
import { ChatMensajeService } from '../domain/services/ChatMensajeService';
import { chatImplentationService } from './services/service-chat/service-chat.service';
import { ChatMensajeImplentationService } from './services/service-chat-mensaje/service-chat-mensaje.service';

@NgModule({
  declarations: [],
  imports: [CommonModule, HttpClientModule],
  providers: [
    ...Object.values(equipoUseCaseProviders),
    ...Object.values(matchUseCaseProviders),
    ...Object.values(chatMensajeUseCaseProviders),
    ...Object.values(chatUseCaseProviders),


    { provide: EquipoService, useClass: EquipoImplentationService },
    { provide: MatchService, useClass: EquipoImplentationService },
    { provide: ChatService, useClass: chatImplentationService },
    { provide: ChatMensajeService, useClass:  ChatMensajeImplentationService},

  ],
})
export class InfraestructureModule {}
