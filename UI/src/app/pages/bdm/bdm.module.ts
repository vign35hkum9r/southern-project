import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {BdmRoutingModule} from './bdm-routing.module';
import {SharedModule} from '../../shared/shared.module';


@NgModule({
  imports: [
    CommonModule,
    BdmRoutingModule,
    SharedModule,
    
  ],
  declarations: []
})
export class BdmModule { }
