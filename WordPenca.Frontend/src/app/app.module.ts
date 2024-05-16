import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InfraestructureModule } from './intraestructure/infraestructure.module';
import { HomeModule } from './presentation/home/home.module';
import { shareModule } from './presentation/share/share.module';
import { LoginModule } from './presentation/login/login.module';
import { EquipoModule } from './presentation/equipo/equipo.module';
import { MatchModule } from './presentation/match/match.module';
import { ChatModule } from './presentation/chat/chat.module';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    InfraestructureModule,
    HomeModule,
    shareModule,
    LoginModule,
    EquipoModule,
    MatchModule,
    ChatModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
