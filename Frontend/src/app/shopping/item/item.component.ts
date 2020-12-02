import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { take } from 'rxjs/operators';
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

  @Output() emitCoinsUsed = new EventEmitter();

  @ViewChild(CheckoutComponent) buyDialog: CheckoutComponent;

  constructor(private dialog: MatDialog) { }

  ngOnInit(): void {
  }

  increment() {
    this.quantity += 1;
    this.price = this.basePrice * this.quantity;
  }

  decrement() {
    if (this.quantity == 1 || this.quantity == 0) {
      this.quantity = 0
    } else {
      this.quantity -= 1;
    }
    this.price = this.basePrice * this.quantity;
  }

  openBuyDialog() {
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

    if (this.dialog.openDialogs.length == 0) {
      const dialogRef = this.dialog.open(CheckoutComponent, dialogConfig);

      dialogRef.afterClosed()
        .subscribe(
          data => {
            console.log("Dialog output:", data);
            if (data.data.quantity > 0) {
              this.quantity = data.data.quantity;
              this.price = data.data.price;
              this.emitCoinsUsed.emit(data.data.price);
            } else {
              this.quantity = 1;
              this.price = this.basePrice * this.quantity;
            }
          }
        );
    }
  }
}
