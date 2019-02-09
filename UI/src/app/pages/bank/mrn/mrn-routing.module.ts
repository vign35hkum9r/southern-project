import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {MRNComponent} from './mrn.component';

const routes: Routes = [
  {
    path: '',
    component: MRNComponent,
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
export class MRNRoutingModule { }