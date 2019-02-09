import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TransactionComponent } from './transaction.component';
import {TransactionRoutingModule} from './transaction-routing.module';
import {SharedModule} from '../../../shared/shared.module';
@NgModule({
  imports: [
    CommonModule,
    TransactionRoutingModule,
    SharedModule, 
  ],
  declarations: [TransactionComponent]
})
export class TransactionModule { }