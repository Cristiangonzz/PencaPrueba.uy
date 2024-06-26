import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from './index/index.component';


const routes: Routes = [
  {
    path: '',
    children: [
      { path: ``, component: IndexComponent/*, canActivate: [BackGuard]*/, },
      { path: `**`, redirectTo: '' },
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class RoutingHomeModule { }
