import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AccountcodeComponent} from './accountcode.component';

const routes: Routes = [
  {
    path: '',
    component: AccountcodeComponent,
    data: {
      title: 'Account Code',                  
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountCodeRoutingModule { }
