import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.less']
})
export class ShopComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  classItemContainer:any = {
    'itemContainer': true
  }

  classShopTitle:any = {
    'shopTitle': true
  }
}
