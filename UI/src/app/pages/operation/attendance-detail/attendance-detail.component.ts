import { Component, OnInit, ViewChild } from '@angular/core';
import { AttendanceDetailsService } from 'src/app/service/operation/attendance-details.service';
import { DateAdapter, MAT_DATE_FORMATS, MatDatepicker, MatDialog } from '@angular/material';
import { appMonthAdapter, APP_DATE_FORMATS } from 'src/app/shared/directives/monthPicker';
import { DatePipe } from '@angular/common';
import { LocalStorage } from 'src/app/shared/local-storage';
import { AttendanceDetailPopupComponent } from '../attendance-detail-popup/attendance-detail-popup.component';


@Component({
  selector: 'app-attendance-detail',
  templateUrl: './attendance-detail.component.html',
  styleUrls: ['./attendance-detail.component.css'],
  providers: [
    { provide: DateAdapter, useClass: appMonthAdapter },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS },
    DatePipe
  ]
 })
 export class AttendanceDetailComponent implements OnInit {

  model: any = {};
  data: any;
  mydata: any;
  reverse: boolean;
  mycolumns: any[];
  orderField: any;
  cellvisible: boolean = true;
  displayColumns: string[];
  displayData: any = [];
  checkbox: boolean = false;
  selectedAll: boolean = false;
  CustomerList: any;
  BranchList: any;
  SiteList: any;
  ManpowerList: any;
  isLoading: boolean = false;
  FromDate: any;
  ToDate: any;
  isDataCheck: boolean = false;
  // date = new FormControl(moment());
  roleName: string;
  roleId: number;
  employee: any;
  StatusId: any;
  maxDate: Date = new Date();

  @ViewChild("picker") datepicker: MatDatepicker<"picker">;

  onMonthSelected(event) {
   this.model.SelectedDate = new Date(event);
   this.datepicker.close();
 }
   constructor(
     public _dialog: MatDialog, private _attendanceDetailsService : AttendanceDetailsService,
     private _localStorage: LocalStorage,
) { }

  ngOnInit() {
   this.roleId = this._localStorage.getRoleId();
   this.roleName = this._localStorage.getRoleName();
    this.employee = localStorage.getItem('userID');
    var obj = {
      ActionBy: parseInt(this.employee)
    }
    this._attendanceDetailsService.listCustomer(obj).subscribe((respose: any) => {
      debugger;
      this.CustomerList = JSON.parse(respose._body).result.CustomerList;
      console.log(this.CustomerList, "CL")
    });
  }

  editAttendanceDetail(element, date): void {
    if (this.employee == 1004) {
      const dialogRef = this._dialog.open(AttendanceDetailPopupComponent, {
        width: '250px',
        data: { element: element, date: date }
      });

      dialogRef.afterClosed().subscribe(result => {
        this.Show();
      });
    }
  }

  CurrentMonth() {
    var date = new Date();
    this.FromDate = new Date(date.getFullYear(), date.getMonth(), 1);
    this.ToDate = new Date(date.getFullYear(), date.getMonth() + 1, 0);
  }


  getBranch() {
    var obj = {
      CustomerId: parseInt(this.model.SelectedCustomer),
      ActionBy: parseInt(this.employee)
    }
    this._attendanceDetailsService.listBranch(obj).subscribe((respose: any) => {
      debugger;
      this.BranchList = JSON.parse(respose._body).result.BranchList;
    });
  }

  getSite() {
    var obj = {
      CustomerId: parseInt(this.model.SelectedCustomer),
      BranchId: parseInt(this.model.SelectedBranch),
      ActionBy: parseInt(this.employee)
    }
    this._attendanceDetailsService.listSite(obj).subscribe((respose: any) => {
      this.SiteList = JSON.parse(respose._body).result.SiteList;
    });
  }

  getManpower() {
    debugger;
    var obj = {
      CustomerId: parseInt(this.model.SelectedCustomer),
      BranchId: parseInt(this.model.SelectedBranch),
      SiteId: parseInt(this.model.SelectedSite),
      ActionBy: parseInt(this.employee)
    }
    this._attendanceDetailsService.listManpower(obj).subscribe((respose: any) => {
      this.ManpowerList = JSON.parse(respose._body).result.ManpowerList;
    });

  }

  Show() {
    debugger;
    this.displayData = [];
    this.displayColumns = [];
    this.isDataCheck = false;
    this.isLoading = true;
    this.model.Date = this.model.SelectedDate._d
    var date = new Date(this.model.Date);
    this.FromDate = new Date(date.getFullYear(), date.getMonth(), 1);
    this.ToDate = new Date(date.getFullYear(), date.getMonth() + 1, 0);
    this._localStorage.setMonth(date.getMonth());
    this._localStorage.setYear(date.getFullYear());
    if (this.employee == 1004) {
      this.StatusId = '1,3'
    }
    else {
      this.StatusId = 2
    }


    var obj = {
      CustomerId: (this.model.SelectedCustomer != undefined) ? parseInt(this.model.SelectedCustomer) : 0,
      BranchId: (this.model.SelectedBranch != undefined) ? parseInt(this.model.SelectedBranch) : 0,
      FromDate: this.FromDate.toLocaleDateString(),
      ToDate: this.ToDate.toLocaleDateString(),
      ActionBy: parseInt(this.employee),
      Status: this.StatusId
    }
    this._attendanceDetailsService.listAttendance(obj).subscribe((respose: any) => {
      debugger;
      this.data = JSON.parse(respose._body).result;
      var List = [];
      if (this.data.Table.length > 0) {
        this.displayColumns = Object.keys(this.data.Table[0]);

        this.displayData = this.data.Table;
        this.isDataCheck = false;
      }
      else {
        this.isDataCheck = true;
      }
      this.isLoading = false;
    })
  }

  select() {
    if (this.model.selectedAll) {
      this.selectedAll = false;
    } else {
      this.selectedAll = true;
    }
    for (var i in this.displayData) {
      this.displayData[i].isSelected = this.selectedAll;
    }
  };

  ischecked(check) {
    if (check) {
      this.checkbox = true;
    }
  }

  SendForApproval() {
    var ApprovalList = [];
    for (var i in this.displayData) {
      if (this.displayData[i].isSelected) {
        ApprovalList.push(this.displayData[i].ManpowerId)
      }
    }
    var obj = {
      ManPowerId: ApprovalList.join(),
      Status: 2,
      FromDate: this.FromDate.toLocaleDateString(),
      ToDate: this.ToDate.toLocaleDateString()
    }
    this._attendanceDetailsService.saveAttendance(obj).subscribe((res: any) => {
      if (res) {
        alert("Saved");
        this.ngOnInit();
        this.displayData = [];
        this.displayColumns = [];
        this.isDataCheck = false;
        this.model = {};
      }
    });
  }

  Approve() {
    var ApprovalList = [];
    for (var i in this.displayData) {
      if (this.displayData[i].isSelected) {
        ApprovalList.push(this.displayData[i].ManpowerId)
      }
    }
    var obj = {
      ManPowerId: ApprovalList.join(),
      Status: 4,
      FromDate: this.FromDate.toLocaleDateString(),
      ToDate: this.ToDate.toLocaleDateString()
    }
    this._attendanceDetailsService.saveAttendance(obj).subscribe((res: any) => {
      if (res) {
        alert("Saved");
        this.ngOnInit();
        this.displayData = [];
        this.displayColumns = [];
        this.isDataCheck = false;
        this.model = {};
      }
    });
  }

  Reject() {
    var ApprovalList = [];
    for (var i in this.displayData) {
      if (this.displayData[i].isSelected) {
        ApprovalList.push(this.displayData[i].ManpowerId)
      }
    }
    var obj = {
      ManPowerId: ApprovalList.join(),
      Status: 3,
      FromDate: this.FromDate.toLocaleDateString(),
      ToDate: this.ToDate.toLocaleDateString()
    }
    this._attendanceDetailsService.saveAttendance(obj).subscribe((res: any) => {
      if (res) {
        alert("Saved");
        this.ngOnInit();
        this.displayData = [];
        this.displayColumns = [];
        this.isDataCheck = false;
        this.model = {};
      }
    });
  }


  // chosenYearHandler(normalizedYear: Moment) {
  //   const ctrlValue = this.date.value;
  //   ctrlValue.year(normalizedYear.year());
  //   this.date.setValue(ctrlValue);
  // }

  // chosenMonthHandler(normlizedMonth: Moment, datepicker: MatDatepicker<Moment>) {
  //   const ctrlValue = this.date.value;
  //   ctrlValue.month(normlizedMonth.month());
  //   this.date.setValue(ctrlValue);
  //   datepicker.close();
  // }

 }
