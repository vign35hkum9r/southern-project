import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { BillingRoutingModule } from './billing-routing.module';


@NgModule({
    imports: [
        CommonModule,
        BillingRoutingModule,
        SharedModule,

    ],
    declarations: []
})
export class BillingModule { }
