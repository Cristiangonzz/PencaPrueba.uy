import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { RoutingHomeModule } from './routing-home.module';
import { SidebarComponent } from '../share/sidebar/sidebar.component';
import { shareModule } from '../share/share.module';



@NgModule({
  declarations: [IndexComponent],
  imports: [
    CommonModule,
    RoutingHomeModule,
    shareModule
  ],
  exports: [IndexComponent]
})
export class HomeModule { }
