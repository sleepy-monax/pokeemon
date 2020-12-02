import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';

import { LandingComponent } from './landing/landing.component';
import { NavBarComponent } from './navbar/navbar.component';
import { NavLinkComponent } from './navlink/navlink.component';
import { ToolkitModule } from '../toolkit/toolkit.module';
import { BattleModule } from '../battle/battle.module';

@NgModule({
  declarations: [LandingComponent, NavBarComponent, NavLinkComponent],
  exports: [LandingComponent, NavBarComponent, NavLinkComponent],
  imports: [
    CommonModule,
    MatIconModule,
    RouterModule,

    ToolkitModule,
    BattleModule
  ]
})
export class NavigationModule { }
