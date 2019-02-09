import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountcodeComponent } from './accountcode.component';
import { AccountCodeRoutingModule } from './accountcode-routing.module';
import { SharedModule } from '../../../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { SelectModule } from 'ng-select';
import { ToastyModule } from 'ng2-toasty';
import { AccountCodeService } from '../../../service/Account/accountcode.service';
import {
  MatTableModule,
  MatPaginatorModule,
  MatRadioModule,
  MatFormFieldModule,
  MatInputModule
} from '@angular/material';
@NgModule({
  imports: [
    CommonModule,
    AccountCodeRoutingModule,
    SharedModule,
    FormsModule,
    SelectModule,
    MatInputModule,
    MatFormFieldModule,
    MatRadioModule,
    MatTableModule,
    MatPaginatorModule,
    ToastyModule.forRoot()
  ],
  declarations: [AccountcodeComponent],
  providers: [AccountCodeService]
})
export class AccountCodeModule { }