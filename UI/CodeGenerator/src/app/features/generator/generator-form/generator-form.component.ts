import { ApplicationDtoEndpoint } from './../../../domain/application-dto/application-dto-endpoint';
import { ApplicationDto } from './../../../domain/application-dto/application-dto';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { catchError, throwError } from 'rxjs';
import { DialogMessageService } from 'src/app/shared/dialog-message/dialog-message.service';

@Component({
  selector: 'app-generator-form',
  templateUrl: './generator-form.component.html',
  styleUrls: ['./generator-form.component.scss']
})
export class GeneratorFormComponent implements OnInit {

  mainForm : FormGroup;

  constructor(
    private fb: FormBuilder,
    private dialogMessageService : DialogMessageService,
    private applicationDtoEndpoint : ApplicationDtoEndpoint
  ) { 
    this.mainForm = this.fb.group({
      ApplicationName: ['' , Validators.required],
      Path: ['' , Validators.required],
      ApiVersion: ['' , Validators.required],
      DbInformation: this.fb.group({
        Server: ['', Validators.required],
        Database: ['', Validators.required],
        Auth: [1, Validators.required],
        User: [null],
        Password: [null]
      })
    })
  }

  ngOnInit() {
  }

  onSubmit(){
    var applicationDto =  this.mainForm.value;
    this.applicationDtoEndpoint.generate(applicationDto).pipe(catchError((error : any) => {
      this.dialogMessageService.openErrorDialog();
      return throwError(() => error);
    }))
    .subscribe(x => {
      this.dialogMessageService.openSuccessDialog();
      // .afterClosed().subscribe(x => this.route.navigate([]));
    });
  }

}
