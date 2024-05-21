import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { RoutingHomeModule } from './routing-home.module';
import { shareModule } from '../share/share.module';
import { ChatModule } from '../chat/chat.module';

@NgModule({
  declarations: [IndexComponent],
  imports: [
    CommonModule,
    RoutingHomeModule,
    shareModule,
    ChatModule
  ],
  exports: [IndexComponent],
})
export class HomeModule {}
