import { Component, Input, OnInit, Output } from '@angular/core';
import {BuyComponent} from '../buy/buy.component';
import {MAT_DIALOG_DATA, MatDialog, MatDialogConfig, MatDialogRef} from '@angular/material/dialog';

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

  constructor(private dialog: MatDialog) { }

  ngOnInit(): void {
  }

  increment() {
    this.quantity += 1;
    this.price = this.basePrice * this.quantity;
  }

  openDialog() {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.hasBackdrop = false;

    dialogConfig.data = {
      dataName : this.name,
      dataQuantity : this.quantity,
      dataPrice : this.price,
      dataDescription : this.description,
      dataBasePrice : this.basePrice,
    };

    const dialogRef = this.dialog.open(BuyComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(
      data => console.log("Dialog output:", data)
    );
  }

}
