import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RootComponent } from './root/root.component';
import { ErrorComponent } from './error/error.component';
import { ToolkitModule } from '../toolkit/toolkit.module';
import { NavigationModule } from '../navigation/navigation.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [RootComponent, ErrorComponent],
  exports: [RootComponent, ErrorComponent],
  imports: [
    CommonModule,
    RouterModule,

    ToolkitModule,
    NavigationModule,
  ]
})
export class ScaffoldingModule { }
