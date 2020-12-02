import {Attribute, Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-text-field',
  templateUrl: './text-field.component.html',
  styleUrls: ['./text-field.component.less']
})
export class TextFieldComponent implements OnInit {
  type: string;
  styles: string;
  placeholder: any;
  value: any;

  constructor(@Attribute('type') type: string,
              @Attribute('styles') styles: string,
              @Attribute('placeholder') placeholder: any,
              @Attribute('value') value: any) {
    this.type = type;
    this.styles = styles;
    this.placeholder = placeholder;
    this.value = value;
  }

  ngOnInit(): void {
  }

}
