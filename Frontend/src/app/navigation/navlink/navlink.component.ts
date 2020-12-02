import { Attribute, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navlink',
  templateUrl: './navlink.component.html',
  styleUrls: ['./navlink.component.less']
})
export class NavLinkComponent implements OnInit {
  icon: string;

  constructor(@Attribute('icon') icon: string) {
    this.icon = icon;
  }

  ngOnInit(): void {
  }
}
