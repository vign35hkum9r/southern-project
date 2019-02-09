import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {MatBottomSheet, MatBottomSheetRef} from '@angular/material';
import { MRSDialogComponent } from './mrs/mrs-dialog.component';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-mrs',
  templateUrl: './mrs.component.html',
  styleUrls: ['./mrs.component.scss']
})
export class MrsComponent implements OnInit {

  isFormOpen: boolean;
  dataSource: any;
  isLinear = false;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  panelOpenState = false;
  isdivOpen: boolean;
  constructor(private _formBuilder: FormBuilder,private bottomSheet: MatBottomSheet,public dialog: MatDialog) { }
 
  model: any = [];
  store = true;
  stores = false;
  create() {
    this.isFormOpen = true;
  }
  clear() {
    this.isFormOpen = false;
  }
  addlist(){
    this.isdivOpen = true;
  }
  Store() {
    this.store = false;
    this.stores = true;

  }

  cancel() {
    this.store = true;
    this.stores = false;
  }
  Cancel() {
    this.stores = true;
    this.store = false;
  }
  openBottomSheet(): void {
    const dialogRef = this.dialog.open(MRSDialogComponent, {
      width: 'auto',
      data: {}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
    });
  }
  ngOnInit() {
  }

}
