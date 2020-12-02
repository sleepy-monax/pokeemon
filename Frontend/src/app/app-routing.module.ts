import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SigninComponent } from './authentication/signin/signin.component';
import { SignupComponent } from './authentication/signup/signup.component';
import { LandingComponent } from './navigation/landing/landing.component';
import { ErrorComponent } from './scaffolding/error/error.component';
import { ShopComponent } from './shopping/shop/shop.component';

const routes: Routes = [
  {
    path: '',
    component: LandingComponent
  },
  {
    path: 'signin',
    component: SigninComponent
  },
  {
    path: 'signup',
    component: SignupComponent
  },
  {
    path: 'landing',
    component: LandingComponent
  },
  {
    path: 'shop',
    component: ShopComponent
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
