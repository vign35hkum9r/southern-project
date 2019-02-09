import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {BankRoutingModule} from './bank-routing.module';
import {SharedModule} from '../../shared/shared.module';

 


@NgModule({
  imports: [
    CommonModule,
    BankRoutingModule,
    SharedModule
    
  ],
  declarations: []
})
export class BankModule { }
