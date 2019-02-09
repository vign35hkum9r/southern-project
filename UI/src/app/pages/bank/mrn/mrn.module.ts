import { NgModule } from '@angular/core';
import { MRNComponent } from './mrn.component';
import { MRNRoutingModule } from './mrn-routing.module';
import { SharedModule } from '../../../shared/shared.module';
import { FormsModule, ReactiveFormsModule, } from '@angular/forms';
import { SelectionModel } from '@angular/cdk/collections';
import { MatTableDataSource, MatCheckboxModule } from '@angular/material';
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



} from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MrnDialogComponent } from './mrn-dialog/mrn-dialog.component';


@NgModule({
  imports: [
    MRNRoutingModule,
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
    // MatTableDataSource,
    MatTableModule,
    MatNativeDateModule,
    MatDialogModule

  ],

  declarations: [MRNComponent,MrnDialogComponent],
  providers: [
  ],
  entryComponents: [MrnDialogComponent]
})
export class MRNModule { }


