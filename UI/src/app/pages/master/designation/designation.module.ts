import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DesignationRoutingModule } from './designation-routing.module';
import { SharedModule } from '../../../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { SelectModule } from 'ng-select';
import { ToastyModule } from 'ng2-toasty';
import {
    MatTableModule,
    MatPaginatorModule,
    MatRadioModule,
    MatFormFieldModule,
    MatInputModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatStepperModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
} from '@angular/material';

import { DesignationComponent } from './designation.component';
import { DesignationService } from 'src/app/service/master/designation.service';
import { DepartmentService } from 'src/app/service/master/department.service';
import { LocalStorage } from 'src/app/shared/local-storage';
@NgModule({
    imports: [
        CommonModule,
        DesignationRoutingModule,
        SharedModule,
        FormsModule,
        SelectModule,
        MatInputModule,
        MatFormFieldModule,
        MatRadioModule,
        MatTableModule,
        MatPaginatorModule, MatAutocompleteModule,
        MatBadgeModule,
        MatBottomSheetModule,
        MatButtonModule,
        MatButtonToggleModule,
        MatCardModule,
        MatCheckboxModule,
        MatChipsModule,
        MatDatepickerModule,
        MatDialogModule,
        MatDividerModule,
        MatExpansionModule,
        MatGridListModule,
        MatIconModule,
        MatListModule,
        MatMenuModule,
        MatNativeDateModule,
        MatProgressBarModule,
        MatProgressSpinnerModule,
        MatRippleModule,
        MatSelectModule,
        MatSidenavModule,
        MatSliderModule,
        MatSlideToggleModule,
        MatSnackBarModule,
        MatSortModule,
        MatStepperModule,
        MatTabsModule,
        MatToolbarModule,
        MatTooltipModule,
        MatTreeModule,
        ToastyModule.forRoot()
    ],
    declarations: [DesignationComponent],
    providers: [DesignationService, LocalStorage, DepartmentService]
})
export class DesignationModule { }