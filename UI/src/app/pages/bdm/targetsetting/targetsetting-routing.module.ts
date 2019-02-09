import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {TargetsettingComponent} from './targetsetting.component';

const routes: Routes = [
  {
    path: '',
    component: TargetsettingComponent,
    data: {
      title: 'Target Setting',                  
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TargetSettingRoutingModule { }
