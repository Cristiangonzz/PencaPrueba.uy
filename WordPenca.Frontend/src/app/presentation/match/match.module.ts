import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatchComponent } from './match.component';
import { RoutingMatchModule } from './routing-match.module';



@NgModule({
  declarations: [MatchComponent],
  imports: [
    CommonModule,
    RoutingMatchModule
  ],
  exports: [MatchComponent]
})
export class MatchModule { }
