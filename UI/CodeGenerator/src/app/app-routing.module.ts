import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePage } from './features/home/home.page';

const routes: Routes = [
  {
    path:'',
    loadChildren: () => import('./features/home/home.module').then(x => x.HomeModule)
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
