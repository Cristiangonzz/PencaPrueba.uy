import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatComponent } from './chat.component';


const routes: Routes = [
  {
    path: '',
    children: [
      { path: ``, component: ChatComponent },
      { path: `**`, redirectTo: '' },
    ]
  }
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoutingChatModule { }
