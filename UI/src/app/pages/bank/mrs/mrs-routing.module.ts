import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {MrsComponent} from './mrs.component';

const routes: Routes = [
  {
    path: '',
    component: MrsComponent,
    data: {
      title: 'Material purchase Order',                  
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MRSRoutingModule { }