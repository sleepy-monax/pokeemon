import { Component, OnInit } from '@angular/core';
// @ts-ignore
import itemsJson from '../../assets/items.json';

interface Item {
  name: String;
  description: String;
  price: number;
}

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.less']
})
export class ShopComponent implements OnInit {

  items: Item[] = itemsJson;

  constructor() {
  }

  ngOnInit(): void {
  }

  quantity: number = 1;
}
