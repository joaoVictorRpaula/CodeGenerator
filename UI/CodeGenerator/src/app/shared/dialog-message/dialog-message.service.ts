import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { DialogMessageModal } from './dialog-message.modal';

@Injectable({
  providedIn: 'root'
})
export class DialogMessageService {

constructor(private dialog : MatDialog) { }

public openConfirmDialog(message? : string) : MatDialogRef<DialogMessageModal> {
  return this.dialog.open(DialogMessageModal, {
    width: '350px',
    height: '300px',
    data : {
      iconStatus : "warning",
      message : message ? message : "Você deseja confirmar essa operação?",
      showCancelButton : true
    }
  })
}

public openErrorDialog(message? : string) : MatDialogRef<DialogMessageModal> {
  return this.dialog.open(DialogMessageModal, {
    width: '350px',
    height: '300px',
    data : {
      iconStatus : "error",
      message : message ? message : "Erro ao realizar a operação.",
      showCancelButton : false
    }
  })
}

public openSuccessDialog(message? : string) : MatDialogRef<DialogMessageModal> {
  return this.dialog.open(DialogMessageModal, {
    width: '350px',
    height: '300px',
    data : {
      iconStatus : "good",
      message : message ? message : "Operação realizada com sucesso!",
      showCancelButton : false
    }
  })
}

}
