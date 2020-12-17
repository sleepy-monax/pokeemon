import {Component, OnDestroy, OnInit} from '@angular/core';
import {Subscription} from 'rxjs';
import {CreatureService} from '../../services/creature.service';
import {Creatures} from '../../model/creature';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.less']
})
export class LandingComponent implements OnInit, OnDestroy {

  private subscription: Subscription[] = [];
  id = 2;
  creatures: Creatures = [];

  constructor(private creatureService: CreatureService) { }

  ngOnInit(): void {
    this.creatureService.get(this.id)
      .subscribe(creatures => {
        creatures.forEach(creature => {
          if (creature.pickable) {
            this.creatures.push(creature);
          }
        });
      });
  }

  ngOnDestroy(): void {
    this.subscription.forEach(sub => sub && sub.unsubscribe());
  }

}
