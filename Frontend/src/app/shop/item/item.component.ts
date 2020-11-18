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

  @Input() name: string = "Name";
  @Input() quantity: number = 1;
  @Input() price: number = 1;
  @Input() description: string = "Description";
  @Input() basePrice: number = 1;

  increment() {
    this.quantity += 1;
    this.price = this.basePrice * this.quantity;
  }
}
