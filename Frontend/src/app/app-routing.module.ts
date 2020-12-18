import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SigninComponent } from './authentication/signin/signin.component';
import { SignupComponent } from './authentication/signup/signup.component';
import { BattleComponent } from './battle/battle/battle.component';
import { LandingComponent } from './navigation/landing/landing.component';
import { ErrorComponent } from './scaffolding/error/error.component';
import { ShopComponent } from './shopping/shop/shop.component';
import {PokeeteamComponent} from './pokeeteam/pokeeteam/pokeeteam.component';
import {AccountComponent} from './account/account/account.component';
import {AuthGuard} from './helpers/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: LandingComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'signin',
    component: SigninComponent,
  },
  {
    path: 'signup',
    component: SignupComponent
  },
  {
    path: 'landing',
    component: LandingComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'shop',
    component: ShopComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'battle',
    component: BattleComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'team',
    component: PokeeteamComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'account',
    component: AccountComponent,
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    component: ErrorComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
