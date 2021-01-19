import {Component, OnDestroy, OnInit} from '@angular/core';
import { Creature, Creatures} from '../../model/creature';
import {Subscription} from 'rxjs';
import {CreatureService} from '../../services/creature.service';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';
import {DialogPokeeComponent} from '../dialog-pokee/dialog-pokee.component';
import {UserApiService} from '../../services/user-api.service';
import {AuthenticationService} from '../../services/authentication.service';
import {first} from 'rxjs/operators';
import {GlobalUser} from '../../helpers/global-user';

@Component({
  selector: 'app-pokeeteam',
  templateUrl: './pokeeteam.component.html',
  styleUrls: ['./pokeeteam.component.less']
})
export class PokeeteamComponent implements OnInit, OnDestroy {

  creatures: Creatures;
  id = 2;
  creaturePickable: Creatures = [];

  private subscription: Subscription[] = [];

  constructor(private creatureService: CreatureService,
              private userService: UserApiService,
              private globalUser: GlobalUser,
              private dialog: MatDialog) { }

  ngOnInit(): void {
    this.userService.query().pipe(first()).subscribe(users => {
      this.creatureService.get(JSON.parse(localStorage.getItem('currentUser')).id)
        .subscribe(creatures => {
          this.creatures = creatures;
          creatures.forEach(creature => {
            if (creature.pickable) {
              this.creaturePickable.push(creature);
            }
          });
        });
    });
  }

  ngOnDestroy(): void {
    this.subscription.forEach(sub => sub && sub.unsubscribe());
  }

  openDialog(creature: Creature): void {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.hasBackdrop = false;

    dialogConfig.data = {
      dataCreature: creature,
    };

    if (this.dialog.openDialogs.length === 0) {
      const dialogRef = this.dialog.open(DialogPokeeComponent, dialogConfig);

      dialogRef.afterClosed()
        .subscribe(
          data => {
            if (data == null) {
              return;
            }

            console.log(data.creature);
            data.creature.pickable = true;
            this.subscription.push(
              this.creatureService.update(data.creature.id, data.creature)
                .subscribe()
            );
            const oldCreature = this.creaturePickable[data.position];
            if (oldCreature != null) {
              oldCreature.pickable = false;
              this.subscription.push(
                this.creatureService.update(oldCreature.id, oldCreature)
                  .subscribe()
              );
            }
            this.creaturePickable[data.position] = data.creature;

            console.log(oldCreature);
            console.log(data.creature);
          }
        );
    }
  }

}
