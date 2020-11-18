import { Component, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.less']
})
export class ItemComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() name: string;
  @Input() quantity: number;
  @Input() price: number;
  @Input() description: string;
  @Input() basePrice: number;

  increment() {
    this.quantity += 1;
    this.price = this.basePrice * this.quantity;
  }
}
