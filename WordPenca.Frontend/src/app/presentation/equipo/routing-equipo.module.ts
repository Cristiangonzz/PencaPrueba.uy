import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListAllComponent } from './list-all/list-all.component';

const routes: Routes = [
  {
    path: '',
    children: [
      { path: ``, component: ListAllComponent },
      { path: `**`, redirectTo: '' },
    ]
  }
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoutingEquipoModule { }
