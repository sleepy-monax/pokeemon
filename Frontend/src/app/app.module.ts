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
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';
import { NavigationItemComponent } from './navigation/item/item.component';
import { ShopComponent } from './shop/shop.component';
import { ItemComponent } from './shop/item/item.component';
import { TitleComponent } from './common/title/title.component';

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
    NavigationItemComponent,
    ShopComponent,
    ItemComponent,
    TitleComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatIconModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
