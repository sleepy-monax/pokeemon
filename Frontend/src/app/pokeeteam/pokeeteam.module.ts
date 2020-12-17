import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PokeeteamComponent } from './pokeeteam/pokeeteam.component';
import {BattleModule} from '../battle/battle.module';
import { DialogPokeeComponent } from './dialog-pokee/dialog-pokee.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatDialogModule} from "@angular/material/dialog";
import {MatFormFieldModule} from "@angular/material/form-field";
import {ToolkitModule} from "../toolkit/toolkit.module";



@NgModule({
  declarations: [PokeeteamComponent, DialogPokeeComponent],
  imports: [
    CommonModule,
    BattleModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    FormsModule,
    ToolkitModule
  ]
})
export class PokeeteamModule { }
