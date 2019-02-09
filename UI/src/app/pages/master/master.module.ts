import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { MasterRoutingModule } from './master-routing.module';


@NgModule({
    imports: [
        CommonModule,
        MasterRoutingModule,
        SharedModule,

    ],
    declarations: []
})
export class MasterModule { }
