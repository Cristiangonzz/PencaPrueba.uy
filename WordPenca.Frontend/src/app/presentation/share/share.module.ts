import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { SearchComponent } from './shearch/search.component';
import { RoutingShareModule } from './routing-share.module';


@NgModule({
  declarations: [FooterComponent, NavbarComponent, SidebarComponent, SearchComponent],
  imports: [
    CommonModule, 
    RoutingShareModule
  ],
  exports: [FooterComponent, NavbarComponent, SidebarComponent, SearchComponent]
})
export class shareModule { }
