import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {BankregComponent} from './bankreg.component';

const routes: Routes = [
  {
    path: '',
    component: BankregComponent,
    data: {
      title: 'Bank Registration',                  
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BankRegRoutingModule { }
