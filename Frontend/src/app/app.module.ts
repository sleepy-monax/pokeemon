import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { RootComponent } from './scaffolding/root/root.component';
import { AuthenticationModule } from './authentication/authentication.module';
import { BattleModule } from './battle/battle.module';
import { NavigationModule } from './navigation/navigation.module';
import { ScaffoldingModule } from './scaffolding/scafolding.module';
import { ShoppingModule } from './shopping/shopping.module';
import { ToolkitModule } from './toolkit/toolkit.module';
import { PokeeteamModule} from './pokeeteam/pokeeteam.module';
import {AccountModule} from './account/account.module';
import {JwtInterceptor} from './helpers/jwt-interceptor';
import {ErrorInterceptor} from './helpers/error-interceptor';
import {GlobalUser} from './helpers/global-user';

@NgModule({
  declarations: [
  ],
  imports: [
    AppRoutingModule,
    AuthenticationModule,
    BattleModule,
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    MatDialogModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    NavigationModule,
    ReactiveFormsModule,
    ScaffoldingModule,
    ShoppingModule,
    ToolkitModule,
    PokeeteamModule,
    AccountModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    GlobalUser
  ],
  bootstrap: [RootComponent]
})
export class AppModule { }
