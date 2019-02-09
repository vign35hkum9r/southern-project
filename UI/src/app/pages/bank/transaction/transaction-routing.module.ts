import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {TransactionComponent} from './transaction.component';

const routes: Routes = [
  {
    path: '',
    component: TransactionComponent,
    data: {
      title: 'Transaction',                  
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TransactionRoutingModule { }
