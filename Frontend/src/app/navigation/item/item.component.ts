import { Attribute, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navigation-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.less']
})
export class NavigationItemComponent implements OnInit {
  icon: string;

  constructor(@Attribute('icon') icon: string) {
    this.icon = icon;
  }

  ngOnInit(): void {
  }
}
