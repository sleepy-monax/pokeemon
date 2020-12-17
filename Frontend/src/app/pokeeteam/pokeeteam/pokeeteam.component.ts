import {Component, OnDestroy, OnInit} from '@angular/core';
import { Creature, Creatures} from '../../model/creature';
import {Subscription} from 'rxjs';
import {CreatureService} from '../../services/creature.service';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';
import {DialogPokeeComponent} from '../dialog-pokee/dialog-pokee.component';

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

  constructor(private creaturesService: CreatureService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.creaturesService.get(this.id)
      .subscribe(creatures => {
        this.creatures = creatures;
        creatures.forEach(creature => {
          if (creature.pickable) {
            this.creaturePickable.push(creature);
          }
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
              this.creaturesService.update(data.creature.id, data.creature)
                .subscribe()
            );
            const oldCreature = this.creaturePickable[data.position];
            if (oldCreature != null) {
              oldCreature.pickable = false;
              this.subscription.push(
                this.creaturesService.update(oldCreature.id, oldCreature)
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
