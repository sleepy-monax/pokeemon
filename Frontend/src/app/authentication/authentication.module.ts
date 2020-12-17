import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';

import { SignupComponent } from './signup/signup.component';
import { SigninComponent } from './signin/signin.component';
import { ToolkitModule } from '../toolkit/toolkit.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [SignupComponent, SigninComponent],
  exports: [SignupComponent, SigninComponent],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    RouterModule,

    CommonModule,
    ToolkitModule,
  ]
})
export class AuthenticationModule { }
