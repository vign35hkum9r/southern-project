import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {RaiseDraftIndentComponent} from './raise-draft-indent.component';

const routes: Routes = [
  {
    path: '',
    component: RaiseDraftIndentComponent,
    data: {
      title: 'Raise-Draft-Indent',                  
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RaiseDraftIndentRoutingModule {}