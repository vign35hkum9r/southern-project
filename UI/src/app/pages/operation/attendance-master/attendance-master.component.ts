import { Component, OnInit } from '@angular/core';
// import { AttendanceMasterService } from 'src/app/ERP/services/attendance/attendance-master/attendance-master.service';
import { DatePipe } from '@angular/common';
import { AttendanceMasterService } from 'src/app/service/operation/attendance-master.service';

@Component({
  selector: 'app-attendance-master',
  templateUrl: './attendance-master.component.html',
  styleUrls: ['./attendance-master.component.css'],
  providers: [DatePipe]
})
export class AttendanceMasterComponent implements OnInit {
  customerData: any[] = [];
  attendance: any = {};
  areaData: any[] = [];
  siteData: any[] = [];
  classificationData: any[] = [];
  manpowerData: any[] = [];
  StatusList: any[] = [];
  shiftMapData: any[] = [];

  constructor(
    private _attendanceMasterService: AttendanceMasterService,
    private _datePipe: DatePipe) {
    this.attendance.Date = new Date();
  }

  ngOnInit() {
    this.getCustomers();
  }

  getCustomers(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    }
    this._attendanceMasterService.getCustomers(element).subscribe(
      (result: any) => {
        this.customerData = result.result;
        this.getStatus();
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getStatus(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    }
    this._attendanceMasterService.getStatus(element).subscribe(
      (result: any) => {
        this.StatusList = result.result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getArea(): void {
    let element = {
      CustomerId: this.attendance.CustomerId,
      ActionBy: localStorage.getItem('userID')
    }
    this._attendanceMasterService.getArea(element).subscribe(
      (result: any) => {
        this.areaData = result.result;
        // this.getAssignManpowers();
        // this.siteData = [];
        // this.classificationData = [];
        // this.serviceData = [];
        // this.manpowerData = [];
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getSite(): void {
    let element = {
      CustomerId: this.attendance.CustomerId,
      BranchId: this.attendance.BranchId,
      ActionBy: localStorage.getItem('userID')
    }
    this._attendanceMasterService.getSite(element).subscribe(
      (result: any) => {
        this.siteData = result.result;
        // this.classificationData = [];
        // // this.serviceData = [];
        // // this.manpowerData = [];
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getAllManpower(): void {
    let element = {
      CustomerId: this.attendance.CustomerId,
      BranchId: this.attendance.BranchId,
      SiteId: this.attendance.SiteId,
      Date: this._datePipe.transform(new Date(), 'yyyy-MM-dd'),
      ActionBy: localStorage.getItem('userID')
    }
    this._attendanceMasterService.getManpower(element).subscribe(
      (result: any) => {
        debugger;
        this.manpowerData = result.result;
        this.setManpower();
        console.log(this.manpowerData);
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  setManpower() {
    debugger;
    for (var i in this.manpowerData) {
      this.manpowerData[i].isAttendance = false;
      for (var j in this.StatusList) {
        if (this.manpowerData[i].AttendanceStatus == null) {
          this.manpowerData[i].selectedStatus = this.StatusList[0];
        } else {
          if (this.manpowerData[i].AttendanceStatus == this.StatusList[j].StatusId) {
            this.manpowerData[i].selectedStatus = this.StatusList[j];
            this.manpowerData[i].isAttendance = true;
          }
        }
      }

      if (this.manpowerData[i].InTime != null) {
        var strInTime = this.manpowerData[i].InTimeTimeSpan.split(':');
        this.manpowerData[i].InTime = new Date().setHours(strInTime[0], strInTime[1], strInTime[2]);
      }

      if (this.manpowerData[i].OutTime != null) {
        var strOutTime = this.manpowerData[i].OutTimeTimeSpan.split(':');
        this.manpowerData[i].OutTime = new Date().setHours(strOutTime[0], strOutTime[1], strOutTime[2]);
      }
      if (this.manpowerData[0].ContractId != null) {
        this.getShiftMaster();
      }
    }
  }

  getShiftMaster() {
    debugger;
    let element = {
      ContractId: this.manpowerData[0].ContractId
    }
    this._attendanceMasterService.getShiftMaster(element).subscribe(
      (result: any) => {
        debugger;
        this.shiftMapData = result.result;
        for (var i in this.manpowerData) {
          for (var k in this.shiftMapData) {
            if (this.manpowerData[i].ShiftMappingId == this.shiftMapData[k].MappingId) {
              this.manpowerData[i].selectedShift = this.shiftMapData[k];
            }
          }
        }
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  isChecked(check: boolean) {
    if (check) {
      return true;
    }
  }

  // getClassification(): void {
  //   let element = {
  //     CustomerId : this.attendance.CustomerId, 
  //     BranchId : this.attendance.BranchId,
  //     SiteId : this.attendance.SiteId,  
  //     ActionBy:localStorage.getItem('userID')
  //   }
  //   this._attendanceMasterService.getClassification(element).subscribe(
  //     (result: any) => {
  //       this.classificationData = result.result;
  //       // this.serviceData = [];
  //       // this.manpowerData = [];
  //     },
  //     error => {
  //       if (error.status === 401) { alert("Unauthorized"); }
  //       else { alert("Something went wrong! Try Again"); }
  //     }
  //   );
  // }
}
