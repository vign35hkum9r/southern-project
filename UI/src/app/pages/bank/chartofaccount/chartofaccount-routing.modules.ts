import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ChartofaccountComponent} from './chartofaccount.component';

const routes: Routes = [
  {
    path: '',
    component: ChartofaccountComponent,
    data: {
      title: 'Chart-of-account',                  
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ChartofaccountRoutingModule { }
