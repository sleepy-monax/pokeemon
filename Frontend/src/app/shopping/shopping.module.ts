import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';

import { ItemComponent } from './item/item.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { ShopComponent } from './shop/shop.component';
import { ToolkitModule } from '../toolkit/toolkit.module';

@NgModule({
  declarations: [ItemComponent, CheckoutComponent, ShopComponent],
  exports: [ItemComponent, CheckoutComponent, ShopComponent],
  imports: [
    CommonModule,
    MatIconModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,

    ToolkitModule,
  ],
})
export class ShoppingModule { }
