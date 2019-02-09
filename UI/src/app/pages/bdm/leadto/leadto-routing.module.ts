import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LeadtoComponent} from './leadto.component';

const routes: Routes = [
  {
    path: '',
    component: LeadtoComponent,
    data: {
      title: 'Lead To',                  
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LeadToRoutingModule { }
