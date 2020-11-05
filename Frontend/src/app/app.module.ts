import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SigninComponent } from './signin/signin.component';
import { SignupComponent } from './signup/signup.component';
import { ErrorComponent } from './error/error.component';
import { LandingComponent } from './landing/landing.component';
import { ButtonComponent } from './common/button/button.component';
import { TextFieldComponent } from './common/text-field/text-field.component';
import { NavigationComponent } from './navigation/navigation.component';

@NgModule({
  declarations: [
    AppRoutingModule.components,
    SigninComponent,
    SignupComponent,
    ErrorComponent,
    LandingComponent,
    ButtonComponent,
    TextFieldComponent,
    NavigationComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
