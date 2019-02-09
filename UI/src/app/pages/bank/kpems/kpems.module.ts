import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxCarouselModule } from 'ngx-carousel';
import { KpemsRoutingModule } from './kpems-routing.module';
import { SharedModule } from '../../../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

//import { SlideshowModule } from 'ng-simple-slideshow';
import { KpemsComponent } from './kpems.component';
///import { SliderModule } from 'angular-image-slider';
import {MatStepperModule } from '@angular/material/stepper';
import {MatCardModule} from '@angular/material/card';

import { Routes } from '@angular/router';
import {ChartModule} from 'angular2-chartjs';



const routes: Routes = [
  {
    path: '',
    component: KpemsComponent,
    data: {
      title: 'Slider',
      icon: 'icon-crown',
      caption: 'lorem ipsum dolor sit amet, consectetur adipisicing elit - slider',
      status: true
    }
  }
];




@NgModule({
  imports: [
    KpemsRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule,
  //  SlideshowModule,
  //  SliderModule,
    MatCardModule,
    NgxCarouselModule,
      MatStepperModule,
    ChartModule,
    CommonModule,   
    
  ],

  declarations: [KpemsComponent],
  providers: [

  ]
})
export class KpemsModule { }


