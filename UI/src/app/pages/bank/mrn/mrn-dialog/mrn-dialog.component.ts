//import { Component, OnInit } from '@angular/core';
import {Component, Inject, OnInit} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
 

export interface PeriodicElement {
  SNO: number;
  MRN_Date: any;
  MRN_No: any;
  Received_Qty: any;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {SNO: 1,   MRN_Date: '03/06/18',   MRN_No: 'W/FP/MRN/17-18/001',   Received_Qty: '562'},
 
];

export interface DialogData {
  // animal: string;
  // name: string;
}

@Component({
  selector: 'app-mrn-dialog',
  templateUrl: './mrn-dialog.component.html',
  styleUrls: ['./mrn-dialog.component.scss']
})

export class MrnDialogComponent implements OnInit {

  displayedColumns: string[] = ['SNO',  'MRN_Date', 'MRN_No', 'Received_Qty'];
  dataSource = ELEMENT_DATA;
  //dialogRef: any;

  
  constructor(
    public dialogRef: MatDialogRef<MrnDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {}

  onNoClick() {
    debugger
    this.dialogRef.close(); 
  }

  ngOnInit() {
  }

}
