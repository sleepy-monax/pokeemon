import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ButtonComponent } from './button/button.component';
import { TextFieldComponent } from './text-field/text-field.component';
import { TitleComponent } from './title/title.component';



@NgModule({
  declarations: [
    ButtonComponent,
    TextFieldComponent,
    TitleComponent],
  exports: [
    ButtonComponent,
    TextFieldComponent,
    TitleComponent],
  imports: [
    CommonModule
  ]
})
export class ToolkitModule { }
