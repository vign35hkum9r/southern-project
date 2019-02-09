//import { Component, OnInit } from '@angular/core';
import {Component, Inject, OnInit} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material'; 
import { MatBottomSheetRef} from '@angular/material';
import { DialogData } from '../../mrn/mrn-dialog/mrn-dialog.component';
 
 
@Component({
  selector: 'app-mrs-dialog',
  templateUrl: './mrs-dialog.component.html',
  styleUrls: ['./mrs-dialog.component.scss']

})
 

export class MRSDialogComponent implements OnInit {
  
    constructor(public dialogRef: MatDialogRef<MRSDialogComponent>,
      @Inject(MAT_DIALOG_DATA) public data: DialogData) {}

 
      onNoClick() {
        debugger
        this.dialogRef.close(); 
      }

  ngOnInit() {   
  }
}


