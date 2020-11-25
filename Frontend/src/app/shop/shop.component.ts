import { Component, OnInit } from '@angular/core';
// @ts-ignore
import itemsJson from '../../assets/items.json';
import {Item} from '../../model/item';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.less']
})
export class ShopComponent implements OnInit {

  items: Item[] = itemsJson;

  quantity: number = 1;
  coins: number = 1000;

  constructor() {
  }

  ngOnInit(): void {
  }

}
