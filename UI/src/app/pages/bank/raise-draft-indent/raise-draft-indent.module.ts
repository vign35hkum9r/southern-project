
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RaiseDraftIndentComponent } from './raise-draft-indent.component';
import {RaiseDraftIndentRoutingModule} from './raise-draft-indent-routing.modules';
import { FlexLayoutModule } from "@angular/flex-layout";
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

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
  MatStepperModule,
  MatCheckboxModule,
 
} from '@angular/material';
@NgModule({
  imports: [
    CommonModule,
  
    RaiseDraftIndentRoutingModule, 
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
  MatStepperModule,
  ReactiveFormsModule
  ],
  declarations: [RaiseDraftIndentComponent]
})
export class RaiseDraftIndentModule { }