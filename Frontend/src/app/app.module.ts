import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { RootComponent } from './scaffolding/root/root.component';
import { AuthenticationModule } from './authentication/authentication.module';
import { BattleModule } from './battle/battle.module';
import { NavigationModule } from './navigation/navigation.module';
import { ScaffoldingModule } from './scaffolding/scafolding.module';
import { ShoppingModule } from './shopping/shopping.module';
import { ToolkitModule } from './toolkit/toolkit.module';

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
    ToolkitModule
  ],
  providers: [],
  bootstrap: [RootComponent]
})
export class AppModule { }
