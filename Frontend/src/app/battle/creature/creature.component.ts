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
  image: string;
  isEmpty = true;

  constructor() { }

  ngOnInit(): void {
    if (this.creature != null) {
      this.image = 'assets/creatures/' + this.creature.name + '.png';
      this.isEmpty = false;
    }
  }
}
