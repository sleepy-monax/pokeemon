import {Component, Input, OnInit} from '@angular/core';
import {Creatures} from '../../model/creature';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.less']
})
export class TeamComponent implements OnInit {

  @Input()
  creatures: Creatures;

  constructor() { }

  ngOnInit(): void {
  }

}
