import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MatchComponent } from './match.component';

const routes: Routes = [
  {
    path: '',
    children: [
      { path: ``, component: MatchComponent },
      { path: `**`, redirectTo: '' },
    ]
  }
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoutingMatchModule { }
