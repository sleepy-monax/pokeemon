import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ChatComponent } from './chat/chat.component';
import { MessageComponent } from './message/message.component';
import { TeamComponent } from './team/team.component';
import { CreatureComponent } from './creature/creature.component';
import { ConnectionComponent } from './connection/connection.component';
import { ToolkitModule } from '../toolkit/toolkit.module';
import { BattleComponent } from './battle/battle.component';
import { BattleGroundComponent } from './battle-ground/battle-ground.component';
import { BattleMenuComponent } from './battle-menu/battle-menu.component';
import {MatIconModule} from "@angular/material/icon";

@NgModule({
  declarations: [
    ChatComponent,
    MessageComponent,
    TeamComponent,
    CreatureComponent,
    ConnectionComponent,
    BattleComponent,
    BattleGroundComponent,
    BattleMenuComponent],
  exports: [
    ChatComponent,
    MessageComponent,
    TeamComponent,
    CreatureComponent,
    ConnectionComponent,
    BattleComponent],
  imports: [
    CommonModule,
    FormsModule,
    ToolkitModule,
    MatIconModule
  ]
})
export class BattleModule { }
