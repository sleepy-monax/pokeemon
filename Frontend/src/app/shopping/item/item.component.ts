import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { CheckoutComponent } from '../checkout/checkout.component';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.less']
})
export class ItemComponent implements OnInit {

  @Input() name: string;
  @Input() quantity: number;
  @Input() price: number;
  @Input() description: string;
  @Input() basePrice: number;

  @Output() emitCoinsUsed = new EventEmitter<object>();

  @ViewChild(CheckoutComponent) buyDialog: CheckoutComponent;

  constructor(private dialog: MatDialog) { }

  ngOnInit(): void {
  }

  increment(): void {
    this.quantity += 1;
    this.price = this.basePrice * this.quantity;
  }

  decrement(): void {
    if (this.quantity === 1 || this.quantity === 0) {
      this.quantity = 0;
    } else {
      this.quantity -= 1;
    }
    this.price = this.basePrice * this.quantity;
  }

  openBuyDialog(): void {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.hasBackdrop = false;

    dialogConfig.data = {
      dataName: this.name,
      dataQuantity: this.quantity,
      dataPrice: this.price,
      dataDescription: this.description,
      dataBasePrice: this.basePrice,
    };

    if (this.dialog.openDialogs.length === 0) {
      const dialogRef = this.dialog.open(CheckoutComponent, dialogConfig);

      dialogRef.afterClosed()
        .subscribe(
          data => {
            console.log('Dialog output:', data);
            if (data.quantity > 0) {
              this.quantity = data.quantity;
              this.price = data.price;
              this.emitCoinsUsed.emit({price : data.price, name : this.name, quantity : data.quantity});
            } else {
              this.quantity = 1;
              this.price = this.basePrice * this.quantity;
            }
          }
        );
    }
  }
}
