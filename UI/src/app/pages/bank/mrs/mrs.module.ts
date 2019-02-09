import { NgModule } from '@angular/core';
import { MrsComponent } from './mrs.component';
import { MRSRoutingModule } from './mrs-routing.module';
import { SharedModule } from '../../../shared/shared.module';
import { FormsModule, ReactiveFormsModule, } from '@angular/forms';
import { MatCheckboxModule, MatAutocompleteModule } from '@angular/material';
import {
  MatStepperModule,
  MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatCardModule,
  MatButtonModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatTableModule,
  MatIconModule,
  MatDialogModule,
  MatBottomSheetModule

} from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MRSDialogComponent } from './mrs/mrs-dialog.component';
// import { MrnDialogComponent } from './mrn-dialog/mrn-dialog.component';


@NgModule({
  imports: [
    MRSRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MatCheckboxModule,
    SharedModule,
    FlexLayoutModule,
    MatStepperModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatSelectModule,
    MatCardModule,
    MatIconModule,
    MatTableModule,
    MatNativeDateModule,
    MatDialogModule,
    MatAutocompleteModule,
    MatBottomSheetModule

  ],

  declarations: [MrsComponent,MRSDialogComponent],
  providers: [
  ],
   entryComponents: [MRSDialogComponent]
})
export class MRSModule { }


