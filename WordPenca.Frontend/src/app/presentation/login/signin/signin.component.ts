import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

type CurrencyType = '₹' | '$' | '€'

export const currency: CurrencyType = '$'

export const currentYear = new Date().getFullYear()

export const developedByLink = 'https://coderthemes.com/'

export const createdBy = 'Coderthemes'

export const buyLink = ""

export const basePath: string = ""

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrl: './signin.component.css'
})
export class SigninComponent {
  loginForm!: FormGroup
  formSubmitted: boolean = false
  showPassword: boolean = false
  author = createdBy
  developBy = developedByLink

  constructor(
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['user@domain.com', [Validators.required, Validators.email]],
      password: ['password', Validators.required],
    })
  }

  /**
   * convenience getter for easy access to form fields
   */
  get formValues() {
    return this.loginForm.controls
  }

  /**
   * On submit form
   */
  onSubmit(): void {
    this.formSubmitted = true

    if (this.loginForm.valid) {
      const email = this.formValues['email'].value // Get the username from the form
      const password = this.formValues['password'].value // Get the password from the form

      // Login Api
     // this.store.dispatch(login({ email: email, password: password }))
    }
  }
}
