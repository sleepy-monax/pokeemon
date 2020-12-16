import {Component, Input, OnInit} from '@angular/core';
import {Creature} from '../../model/creature';

@Component({
  selector: 'app-creature',
  templateUrl: './creature.component.html',
  styleUrls: ['./creature.component.less']
})
export class CreatureComponent implements OnInit {

  @Input()
  creature: Creature;

  constructor() { }

  ngOnInit(): void {
  }

}
