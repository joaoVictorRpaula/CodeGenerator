import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeneratorPage } from './generator.page';
import { GeneratorFormComponent } from './generator-form/generator-form.component';
import { GeneratorRoutingModule } from './generator-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    GeneratorRoutingModule,
    SharedModule
  ],
  declarations: [
    GeneratorPage,
    GeneratorFormComponent
  ]
})
export class GeneratorModule { }
