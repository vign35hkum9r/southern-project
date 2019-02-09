import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GroupComponent } from './group.component';
import {GroupRoutingModule} from './group-routing.modules';
import {SharedModule} from '../../../shared/shared.module';
import { FlexLayoutModule } from "@angular/flex-layout";
import {FormsModule} from '@angular/forms';
import { ToastyModule } from 'ng2-toasty';
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
  MatStepperModule,
  MatIconModule
  
} from '@angular/material';
@NgModule({
  imports: [
    CommonModule,
    GroupRoutingModule,
    SharedModule, 
    FlexLayoutModule,
    FormsModule,
    
    MatCardModule,
    MatToolbarModule,
    MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatRadioModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatButtonModule,
  MatStepperModule,
  MatIconModule,
  ToastyModule.forRoot()
  ],
  declarations: [GroupComponent],
  providers: [GroupService]
})
export class GroupModule { }