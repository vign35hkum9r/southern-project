import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LedgerSubledgerComponent} from './ledger-subledger.component';

const routes: Routes = [
  {
    path: '',
    component: LedgerSubledgerComponent,
    data: {
      title: 'LedgerSubledger',                  
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LedgerSubledgerRoutingModule { }