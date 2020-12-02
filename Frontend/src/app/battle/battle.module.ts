import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ChatComponent } from './chat/chat.component';
import { MessageComponent } from './message/message.component';
import { TeamComponent } from './team/team.component';
import { CreatureComponent } from './creature/creature.component';
import { ConnectionComponent } from './connection/connection.component';
import { ToolkitModule } from '../toolkit/toolkit.module';

@NgModule({
  declarations: [
    ChatComponent,
    MessageComponent,
    TeamComponent,
    CreatureComponent,
    ConnectionComponent],
  exports: [
    ChatComponent,
    MessageComponent,
    TeamComponent,
    CreatureComponent,
    ConnectionComponent],
  imports: [
    CommonModule,
    FormsModule,

    ToolkitModule
  ]
})
export class BattleModule { }
