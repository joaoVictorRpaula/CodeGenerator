import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

export interface options{
  iconStatus : string;
  message : string;
  showCancelButton : boolean;
}

@Component({
  selector: 'app-dialog-message',
  templateUrl: './dialog-message.modal.html',
  styleUrls: ['./dialog-message.modal.scss']
})
export class DialogMessageModal implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: options,
  public dialogRef: MatDialogRef<DialogMessageModal>) { }

  ngOnInit() {
  }

  closeDialog(confirm : Boolean) {
    this.dialogRef.close(confirm);
  }

}
