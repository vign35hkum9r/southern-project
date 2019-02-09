
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LedgerLibraryComponent } from './ledger-library.component';
import {LedgerLibraryRoutingModule} from './ledger-library-routing.modules';
import {SharedModule} from '../../../shared/shared.module';
import { FlexLayoutModule } from "@angular/flex-layout";
import {
  MatCardModule,
  MatToolbarModule,
  MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatRadioModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatButtonModule

} from '@angular/material';
@NgModule({
  imports: [
    CommonModule,  
    SharedModule, 
    FlexLayoutModule,
    LedgerLibraryRoutingModule,
    
    MatCardModule,
    MatToolbarModule,
    MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatRadioModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatButtonModule 
  ],
  declarations: [LedgerLibraryComponent]
})
export class LedgerLibraryModule { }