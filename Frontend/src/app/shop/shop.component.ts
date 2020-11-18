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

  classShopTitle:any = {
    'shopTitle': true
  }

  test: string = "TestInput";
  price: number  = 10;
  description: string = "TestDescription";
  quantity: number = 1;
  basePrice: number = 10;
}
