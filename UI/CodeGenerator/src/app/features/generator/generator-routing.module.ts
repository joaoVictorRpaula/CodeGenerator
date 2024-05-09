import { GeneratorFormComponent } from './generator-form/generator-form.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GeneratorPage } from './generator.page';

const routes: Routes = [
  {
    path:'',
    component: GeneratorPage,
    children: [
      {
        path:'',
        component : GeneratorFormComponent
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GeneratorRoutingModule { }
