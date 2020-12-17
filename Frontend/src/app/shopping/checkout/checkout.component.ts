import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.less']
})
export class CheckoutComponent implements OnInit {

  name: string;
  quantity: number;
  price: number;
  description: string;
  basePrice: number;

  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<CheckoutComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {

    this.name = data.dataName;
    this.quantity = data.dataQuantity;
    this.price = data.dataPrice;
    this.description = data.dataDescription;
    this.basePrice = data.dataBasePrice;
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: [this.name, []],
      quantity: [this.quantity, []],
      price: [this.price, []],
      description: [this.description, []],
      basePrice: [this.basePrice, []],
    });
  }

  close(): void {
    this.dialogRef.close({
      data: { quantity: 0 as number }
    });
  }

  buy(): void {
    this.dialogRef.close({
      data: { quantity: this.quantity as number, price: this.price as number }
    });
  }

  updatePrice(event: any) {
    this.price = this.basePrice * this.quantity;
  }
}
