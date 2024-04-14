import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { equipoUseCaseProviders } from './delegate/delegate-equipo/delegateEquipo';
import { EquipoService } from '../domain/services/EquipoService';
import { EquipoImplentationService } from './services/service-equipo/service-equipo.service';
import { MatchService } from '../domain/services/MatchService ';
import { matchUseCaseProviders } from './delegate/delegate-match/delegateMatch';



@NgModule({
  declarations: [],
  imports: [CommonModule, HttpClientModule],
  providers: [
    ...Object.values(equipoUseCaseProviders), 
    ...Object.values(matchUseCaseProviders), 
                     
    { provide: EquipoService, useClass: EquipoImplentationService },
    { provide: MatchService, useClass: EquipoImplentationService }

   ]
})
export class InfraestructureModule { }
