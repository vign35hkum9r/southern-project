

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChartofaccountComponent } from './chartofaccount.component';
import { ChartofaccountRoutingModule } from './chartofaccount-routing.modules';
import { SharedModule } from '../../../shared/shared.module';
import { FlexLayoutModule } from "@angular/flex-layout";
// import {BrowserAnimationsModule}from '@angular/platform-browser/animations';
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
  MatTableModule,
  
  MatPaginatorModule,   
  MatIconModule

} from '@angular/material';
import { CdkTableModule } from '@angular/cdk/table';
@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FlexLayoutModule,
    ChartofaccountRoutingModule,
    CdkTableModule,
    MatCardModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatRadioModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    // BrowserAnimationsModule,
    MatIconModule

  ],
  declarations: [ChartofaccountComponent]
})
export class ChartofaccountModule { }