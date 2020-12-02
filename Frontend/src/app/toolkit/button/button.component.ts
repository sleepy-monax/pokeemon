import { Attribute, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.less']
})
export class ButtonComponent implements OnInit {
  icon: string;
  color: string;

  @Input()
  isDisabled = false;

  hiddenclass = {
    hidden: true
  };

  constructor(@Attribute('icon') icon: string, @Attribute('color') color: string) {
    if (icon != null) {
      this.hiddenclass.hidden = false;
    }
    this.icon = icon;
    this.color = color;
  }

  ngOnInit(): void {
  }
}
