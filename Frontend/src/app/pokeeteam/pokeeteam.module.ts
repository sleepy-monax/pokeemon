import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PokeeteamComponent } from './pokeeteam/pokeeteam.component';
import {BattleModule} from '../battle/battle.module';



@NgModule({
  declarations: [PokeeteamComponent],
    imports: [
      CommonModule,
      BattleModule
    ]
})
export class PokeeteamModule { }
