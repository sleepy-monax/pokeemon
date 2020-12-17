import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {Creature} from '../../model/creature';

@Component({
  selector: 'app-dialog-pokee',
  templateUrl: './dialog-pokee.component.html',
  styleUrls: ['./dialog-pokee.component.less']
})
export class DialogPokeeComponent implements OnInit {

  constructor(
    private dialogRef: MatDialogRef<DialogPokeeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    console.log(this.data.dataCreature);
  }

  close(): void {
    this.dialogRef.close(null);
  }

  chooseYou(pos: number): void {
    this.dialogRef.close({
      position: pos as number, creature: this.data.dataCreature as Creature
    });
  }
}
