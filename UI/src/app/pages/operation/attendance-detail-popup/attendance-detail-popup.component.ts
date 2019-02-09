import { Component, OnInit, Inject } from '@angular/core';
import { AttendanceDetailsService } from 'src/app/service/operation/attendance-details.service';
import { GetStatus } from 'src/app/model/attendance-detail-popup/attendance-detail-popup.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { LocalStorage } from 'src/app/shared/local-storage';

@Component({
  selector: 'app-attendance-detail-popup',
  templateUrl: './attendance-detail-popup.component.html',
  styleUrls: ['./attendance-detail-popup.component.css']
})
export class AttendanceDetailPopupComponent implements OnInit {

  employee: string;
  statusData: GetStatus[] = [];
  setAttendance: string;
  setStatus: number;
  setDate: Date = new Date();

  
  constructor(public dialogRef: MatDialogRef<AttendanceDetailPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public _data: any,
    private _attendanceService: AttendanceDetailsService,
    private _localStorage: LocalStorage,
  ) {
   this.employee = this._localStorage.getUserId();
  }

  ngOnInit() {
    debugger;
    this._data;
    this.setAttendance = this._data.element[Number(this._data.date)];
    this.setDate = new Date(
    this.setDate.setFullYear(this._localStorage.getYear(), this._localStorage.getMonth(), (Number(this._data.date)))
    );
    this.getStatusMaster();
  }

  getStatusMaster() {
    debugger;
    var obj = {
      ActionBy: parseInt(this.employee)
    }
    this._attendanceService.getStatusMaster(obj).subscribe((respose: any) => {
      debugger;
      this.statusData = JSON.parse(respose._body).result;
      this.setStatus = this.statusData[this.statusData.findIndex(element => element.StatusName == this.setAttendance)].StatusId
    });
  }

  modifyAttendance() {
    debugger;
    var obj = {
      Date: new Date(this.setDate),
      ModifiedBy: parseInt(this.employee),
      UpdateAtt: [{
        ManpowerId: this._data.element.ManpowerId,
        StatusId: this.setStatus,
      }]
    }
    this._attendanceService.modifyAttendance(obj).subscribe((respose: any) => {
      debugger;
      if (respose.status == 200) {
        alert('Successfully updated');
        this.closeDialog();
      }
    });
  }

  closeDialog() {
    this.dialogRef.close();
  }
}

