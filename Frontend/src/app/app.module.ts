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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NavigationItemComponent } from './navigation/item/item.component';
import { ShopComponent } from './shop/shop.component';
import { ItemComponent } from './shop/item/item.component';
import { TitleComponent } from './common/title/title.component';
import { TeamsComponent } from './main-menu/teams/teams.component';
import { ItemTeamsComponent } from './main-menu/teams/item-teams/item-teams.component';
import { BuyComponent } from './shop/buy/buy.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { HttpClientModule } from '@angular/common/http';
import { ConnectionStatusComponent } from './navigation/connection-status/connection-status.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ChatComponent } from './chat/chat.component';
import { MessageComponent } from './chat/message/message.component';

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
    TeamsComponent,
    ItemTeamsComponent,
    BuyComponent,
    ConnectionStatusComponent,
    ChatComponent,
    MessageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatIconModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    HttpClientModule,
    MatTooltipModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
