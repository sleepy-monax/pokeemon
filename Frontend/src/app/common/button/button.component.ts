import {Attribute, Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.less']
})
export class ButtonComponent implements OnInit {

  text: string;
  icon: string;
  style: string;

  constructor(@Attribute('text') text: string,
              @Attribute('icon') icon: string,
              @Attribute('styles') style: string) {
    this.text = text;
    this.icon = icon;
    this.style = style;
  }

  ngOnInit(): void {
  }

}
