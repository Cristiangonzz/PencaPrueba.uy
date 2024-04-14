import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoutingLoginModule } from './routing-login.module';
import { SigninComponent } from './signin/signin.component';



@NgModule({
  declarations: [SigninComponent],
  imports: [
    CommonModule,
    RoutingLoginModule
  ],
  exports: [SigninComponent],
})
export class LoginModule { }
