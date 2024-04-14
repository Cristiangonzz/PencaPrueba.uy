import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [

   {
    path: '',
    redirectTo: 'index',
    pathMatch: 'full',
  },
  {
  path: 'index',
  //canActivate: [BackGuard],
  loadChildren: () =>
    import('./presentation/home/home.module').then((m) => m.HomeModule),
},
  {
  path: 'List',
  //canActivate: [BackGuard],
    loadChildren: () =>
      import('./presentation/equipo/equipo.module').then((m) => m.EquipoModule),
  },

  {
    path: 'Match',
    //canActivate: [BackGuard],
    loadChildren: () =>
      import('./presentation/match/match.module').then((m) => m.MatchModule),
  },
  {
    path: '**',
    redirectTo: 'List',
    pathMatch: 'full',
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
