import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.less']
})
export class ItemComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  classItemName:any = {
    'itemName': true
  };

  classItemQuantity:any = {
    'itemQuantity': true
  };

  classItemPrice:any = {
    'itemPrice': true
  }

  classItemDescription:any = {
    'itemDescription': true
  }
  name: string = "Name";
  quantity: string = "Quantity";
  price: string = "Price";
  description: string = "Description";

}
