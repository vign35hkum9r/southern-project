import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {KpemsComponent} from './kpems.component';

const routes: Routes = [
  {
    path: '',
    component: KpemsComponent,
    data: {
      title: 'KPMES',
      icon: 'icon-crown',
      caption: 'lorem ipsum dolor sit amet, consectetur adipisicing elit - slider',                
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class KpemsRoutingModule { }
