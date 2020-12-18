import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CreatureService } from '../../services/creature.service';
import { Creatures } from '../../model/creature';
import { UserApiService } from '../../services/user-api.service';
import { Users } from '../../model/user';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../../services/authentication.service';
import { GlobalUser } from '../../helpers/global-user';
import { BattleService } from 'src/app/services/battle.service';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.less']
})
export class LandingComponent implements OnInit, OnDestroy {

  private subscription: Subscription[] = [];
  id: number;
  creatures: Creatures = [];
  loading = false;
  users: Users;
  public battles: any[];

  constructor(private creatureService: CreatureService,
    private userService: UserApiService,
    private globalUser: GlobalUser,
    private battleService: BattleService) { }

  ngOnInit(): void {
    this.loading = true;
    this.userService.query().pipe(first()).subscribe(users => {
      this.loading = false;
      this.users = users;
      this.creatureService.get(this.globalUser.user.id)
        .subscribe(creatures => {
          creatures.forEach(creature => {
            if (creature.pickable) {
              this.creatures.push(creature);
            }
          });
        });
    });

    this.battleService.battles.subscribe((value: any[]) => {
      this.battles = value;
    });

    this.battleService.refreshList();
  }

  ngOnDestroy(): void {
    this.subscription.forEach(sub => sub && sub.unsubscribe());
  }

  public create() {
    this.battleService.create();
  }

  public join(battle) {
    this.battleService.join(battle);
  }
}
