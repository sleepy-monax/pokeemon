import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

import { ButtonComponent } from './button/button.component';
import { TextFieldComponent } from './text-field/text-field.component';
import { TitleComponent } from './title/title.component';
import { CenteredComponent } from './centered/centered.component';

@NgModule({
  declarations: [
    ButtonComponent,
    TextFieldComponent,
    TitleComponent,
    CenteredComponent],
  exports: [
    ButtonComponent,
    TextFieldComponent,
    TitleComponent,
    CenteredComponent],
  imports: [
    CommonModule,
    MatIconModule
  ]
})
export class ToolkitModule { }
