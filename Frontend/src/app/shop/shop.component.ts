import {Component, OnInit} from '@angular/core';
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
  isHidden: boolean = true;

  constructor() {
  }

  ngOnInit(): void {
  }

  modifyCoins(event) {
    console.log("Coins spent : ", event);
    var diff = this.coins - event;
    if (diff < 0) {
      console.log("No money for this");
      this.isHidden = false;
      return;
    } else {
      this.coins -= event;
      this.isHidden = true;
    }
  }
}
