import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountComponent } from './account/account.component';
import {ToolkitModule} from '../toolkit/toolkit.module';
import {ReactiveFormsModule} from '@angular/forms';
import {MatIconModule} from '@angular/material/icon';
import {MatTooltipModule} from '@angular/material/tooltip';


@NgModule({
  declarations: [AccountComponent],
  imports: [
    CommonModule,
    ToolkitModule,
    ReactiveFormsModule,
    MatIconModule,
    MatTooltipModule
  ]
})
export class AccountModule { }
