import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {MysurveyComponent} from './mysurvey.component';

const routes: Routes = [
  {
    path: '',
    component: MysurveyComponent,
    data: {
      title: 'My Survey',                  
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MySurveyRoutingModule { }
