import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LedgerSubledgerComponent } from './ledger-subledger.component';
import { LedgerSubledgerRoutingModule } from './ledger-subledger-routing.modules';
import { FlexLayoutModule } from "@angular/flex-layout";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Led_SubledService } from '../../../service/Account/Led_Subled.service';
import { AccountCodeService } from '../../../service/Account/accountcode.service';
import { GroupService } from '../../../service/Account/group.service';

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
  MatCheckboxModule,
  MatStepperModule,
  MatExpansionModule
} from '@angular/material';
@NgModule({
  imports: [
    CommonModule,

    LedgerSubledgerRoutingModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
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
    MatExpansionModule, 
    MatStepperModule

  ],
  declarations: [LedgerSubledgerComponent],
  providers: [Led_SubledService, AccountCodeService,GroupService]
})
export class LedgerSubledgerModule { }