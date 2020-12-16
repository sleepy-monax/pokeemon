import {Component, OnDestroy, OnInit} from '@angular/core';
import { Creatures} from '../../model/creature';
import {Subscription} from 'rxjs';
import {CreatureService} from '../../services/creature.service';

@Component({
  selector: 'app-pokeeteam',
  templateUrl: './pokeeteam.component.html',
  styleUrls: ['./pokeeteam.component.less']
})
export class PokeeteamComponent implements OnInit, OnDestroy {

  creatures: Creatures;
  id = 1;

  private subscription: Subscription[] = [];

  constructor(private creaturesService: CreatureService) { }

  ngOnInit(): void {

    this.creaturesService.get(this.id)
      .subscribe(creatures => this.creatures = creatures);
  }

  ngOnDestroy(): void {
    this.subscription.forEach(sub => sub && sub.unsubscribe());
  }

}
