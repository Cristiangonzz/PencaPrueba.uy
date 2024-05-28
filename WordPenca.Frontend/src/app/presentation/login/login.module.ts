import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoutingLoginModule } from './routing-login.module';
import { SigninComponent } from './signin/signin.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [SigninComponent],
  imports: [
    CommonModule,
    RoutingLoginModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [SigninComponent],
})
export class LoginModule { }
