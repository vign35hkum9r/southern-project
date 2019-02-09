

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TdsComponent } from './tds.component'; 
import {TdsRoutingModule} from './tds-routing.modules';
import { FlexLayoutModule } from "@angular/flex-layout";
import {FormsModule} from '@angular/forms';

import {
  MatCardModule,
  MatToolbarModule,
  MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatRadioModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatButtonModule,
  MatIconModule,
  MatCheckboxModule
} from '@angular/material';
@NgModule({
  imports: [
    CommonModule,
  
    TdsRoutingModule, 
    FlexLayoutModule,
    FormsModule,
    
    MatCardModule,
    MatToolbarModule,
    MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatRadioModule,
  MatCheckboxModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatButtonModule,
  MatIconModule,
  
  ],
  declarations: [TdsComponent]
})
export class TdsModule { }