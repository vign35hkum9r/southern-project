import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BankregComponent } from './bankreg.component';
import {BankRegRoutingModule} from './bankreg-routing.module';
import {SharedModule} from '../../../shared/shared.module';
import { FlexLayoutModule } from "@angular/flex-layout";
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
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
  MatStepperModule
  
} from '@angular/material';
@NgModule({
  imports: [
    CommonModule,
    BankRegRoutingModule,
    SharedModule, 
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule,
    MatToolbarModule,
    MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatRadioModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatButtonModule,
  MatIconModule ,
  MatStepperModule
  ],
  declarations: [BankregComponent]
})
export class BankRegModule { }