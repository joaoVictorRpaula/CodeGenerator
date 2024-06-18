import { ApplicationDtoEndpoint } from './../../../domain/application-dto/application-dto-endpoint';
import { ApplicationDto } from './../../../domain/application-dto/application-dto';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { catchError, throwError } from 'rxjs';
import { DialogMessageService } from 'src/app/shared/dialog-message/dialog-message.service';
import { CodeGeneratorEndpoint } from 'src/app/domain/code-generator/code-generator-endpoint';

@Component({
  selector: 'app-generator-form',
  templateUrl: './generator-form.component.html',
  styleUrls: ['./generator-form.component.scss']
})
export class GeneratorFormComponent implements OnInit {

  mainForm : FormGroup;
  loading : Boolean = false;
  templates : string[] = [];
  languages : string[] = [];

  constructor(
    private fb: FormBuilder,
    private dialogMessageService : DialogMessageService,
    private applicationDtoEndpoint : ApplicationDtoEndpoint,
    private codeGeneratorEndpoint : CodeGeneratorEndpoint
  ) { 
    this.mainForm = this.fb.group({
      ApplicationName: ['' , Validators.required],
      Path: ['' , Validators.required],
      VariableTypes: ['' , Validators.required],
      TemplateName: ['' , Validators.required],
      DbInformation: this.fb.group({
        Server: ['', Validators.required],
        Database: ['', Validators.required],
        // Auth: [1, Validators.required],
        User: [null],
        Password: [null]
      })
    })
  }

  ngOnInit() {
    this.codeGeneratorEndpoint.getAllTemplates().subscribe(x => {
      this.templates = x;
    })

    this.codeGeneratorEndpoint.getAllLanguages().subscribe(x => {
      this.languages = x;
    })
  }

  onSubmit(){
    this.loading = true;
    var applicationDto =  this.mainForm.value;
    this.applicationDtoEndpoint.generate(applicationDto).pipe(catchError((error : any) => {
      this.loading = false;
      this.dialogMessageService.openErrorDialog();
      return throwError(() => error);
    }))
    .subscribe(x => {
      this.loading = false;
      this.dialogMessageService.openSuccessDialog();
    });
  }

}
