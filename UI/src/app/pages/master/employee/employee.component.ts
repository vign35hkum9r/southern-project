import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator } from '@angular/material';
import { EmployeeMasterService } from 'src/app/service/master/employee-master.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  viewFlag = true;
  isEditing = false;

  constructor(
    private _employeeMasterService: EmployeeMasterService
  ) { }

  ngOnInit() {
    this.dataSource.paginator = this.paginator;
    this.LoadEmployeeMaster();
    this.getCompany();
    this.getState();
    this.getBloodgroup();
    this.getDesignation();
    this.getReportTo();
    this.getBankDetailById();
  }

  EmployeeData: any[] = [];
  stateData: any[] = [];
  companyData: any[] = [];
  cityData: any[] = [];
  designationData: any[] = [];
  bloodgroupData: any[] = [];
  reportData: any[] = [];
  BankData: any[] = [];

  employeeMaster: any = {
    Id: 0,
    EmployeeId: 0,
    FirstName: '',
    SecondName: '',
    FatherName: '',
    Gender: '',
    DateOfBirth: new Date,
    ContactNo: 0,
    Email: '',
    CurrentAddress: '',
    PermanentAddress: '',
    NativePlace: '',
    MedicalExam: '',
    DesignationId: 0,
    ReportTo: 0,
    BloodGroup: '',
    ReportToName: '',
    CompanyId: '',
    DesignationName: '',
    CompanyName: '',
    State: '',
    StateId: 0,
    CityId: 0,
    City: '',
    CreatedDate: new Date,
    ModifiedDate: new Date,
    CreatedBy: localStorage.getItem('userID'),
    modifiedBy: localStorage.getItem('userID'),
    Active: true,
  

  }

  employeeBankMaster: any = {
    EmployeeBankId: 0,
    Id: 0,
    AccountNo: '',
    BankName: '',
    IFSC: '',
    MICR: '',
    Branch: '',
    isPrimary: '',
    CreatedBy: localStorage.getItem('userID'),

  }
  employeeDetail: any = {
    Id: 0,
    EmployeeId: 0,
    FirstName: '',
    SecondName: '',
    FatherName: '',
    Gender: '',
    DateOfBirth: new Date,
    ContactNo: 0,
    Email: '',
    CurrentAddress: '',
    PermanentAddress: '',
    NativePlace: '',
    MedicalExam: '',
    DesignationId: 0,
    ReportTo: 0,
    BloodGroup: '',
    ReportToName: '',
    CompanyId: '',
    DesignationName: '',
    CompanyName: '',
    State: '',
    StateId: 0,
    CityId: 0,
    City: '',
    CreatedDate: new Date,
    ModifiedDate: new Date,
    CreatedBy: localStorage.getItem('userID'),
    modifiedBy: localStorage.getItem('userID'),
    Active: true,
    BankDetail: [{
      EmployeeBankId: 0,
      Id: 0,
      AccountNo: '',
      BankName: '',
      IFSC: '',
      MICR: '',
      Branch: '',
      isPrimary: true,
      CreatedBy: localStorage.getItem('userID'),
    }]
  };

  unchangeEmployeeDetail: any = {};

  upadteEmployeeDetail: any = {};

  displayedColumns: string[] = [
    "EmployeeId",
    "Name",
    "Contact",
    "Designation",
    "Company",
    "ReportTo",
    "Active",
    "Action"
  ];
  dataSource = new MatTableDataSource();
  @ViewChild(MatPaginator) paginator: MatPaginator;

  LoadEmployeeMaster(): void {
    debugger;
    let element = {
      ActionBy: localStorage.getItem('userID')
    };
    this._employeeMasterService.getAllEmployee(element).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.EmployeeData = result.result;
        this.dataSource.paginator = this.paginator;
        this.dataSource = result.result;
        console.log(this.EmployeeData);
      },
      error => {
        if (error.status === 401) {
          alert("Unauthorized");
        } else {
          alert("Something went wrong! Try Again");
        }
      }
    );
  }

    
  getBankDetailById(): void {
    debugger;
    let element = {
      ActionBy: localStorage.getItem('userID')
    };
    this._employeeMasterService.getBankDetail(element).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.BankData = result.result;
        console.log(this.BankData);
      },
      error => {
        if (error.status === 401) {
          alert("Unauthorized");
        } else {
          alert("Something went wrong! Try Again");
        }
      }
    );
  }

  addEmployeeDetails(): void {
    if (!this.isEditing) {
      this._employeeMasterService.addEmployee(this.employeeDetail).subscribe(
        (result: any) => {
          if (result.result === true) {
            alert("Successfully added");
            this.ngOnInit();
            this.viewFlag = !this.viewFlag;
          }
        },
        error => {
          if (error.status === 401) {
            alert("Unauthorized");
          } else {
            alert("Something went wrong! Try Again");
          }
        }
      );
    } else {
      this._employeeMasterService.modifyEmployee(this.employeeDetail).subscribe(
        (result: any) => {
          if (result.result === true) {
            alert("Successfully modified");
            this.ngOnInit();
            this.viewFlag = !this.viewFlag;
          }
        },
        error => {
          if (error.status === 401) {
            alert("Unauthorized");
          } else {
            alert("Something went wrong! Try Again");
          }
        }
      );
    }
  }

  editEmployeeDetails(modifyEmployee): void {
    debugger;
    this.employeeDetail = modifyEmployee;
    this.viewFlag = !this.viewFlag;
    this.isEditing = true;
  }

  
  addBankDetails(): void {
    if (!this.isEditing) {
      this._employeeMasterService.addBank(this.employeeDetail.BankDetail).subscribe(
        (result: any) => {
          if (result.result === true) {
            alert("Successfully added");
            this.ngOnInit();
            this.viewFlag = !this.viewFlag;
          }
        },
        error => {
          if (error.status === 401) {
            alert("Unauthorized");
          } else {
            alert("Something went wrong! Try Again");
          }
        }
      );
    } else {
      this._employeeMasterService.modifybank(this.employeeDetail.BankDetail).subscribe(
        (result: any) => {
          if (result.result === true) {
            alert("Successfully modified");
            this.ngOnInit();
            this.viewFlag = !this.viewFlag;
          }
        },
        error => {
          if (error.status === 401) {
            alert("Unauthorized");
          } else {
            alert("Something went wrong! Try Again");
          }
        }
      );
    }
  }

  editBankDetails(modifyBank): void {
    debugger;
    this.employeeDetail = modifyBank;
    this.viewFlag = !this.viewFlag;
    this.isEditing = true;
  }

  removeEmployeeDetail(element): void {
    let deleteElement = {
      Id: element.Id,
      Active: element.Active,
      ActionBy: localStorage.getItem('userID')
    }
    this._employeeMasterService.removeEmployee(deleteElement).subscribe(
      (result: any) => {
        console.log(result);
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  onNewClick() {
    this.viewFlag = !this.viewFlag;
  }

  resetScreen(): void {
    this.employeeDetail = Object.assign({}, this.unchangeEmployeeDetail);
    this.viewFlag = !this.viewFlag;
  }

  removeBankDetail(element): void {
    let deleteElement = {
      Id: element.Id,
      Active: element.Active,
      ActionBy: localStorage.getItem('userID')
    }
    this._employeeMasterService.removebank(deleteElement).subscribe(
      (result: any) => {
        console.log(result);
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getCompany(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    }
    this._employeeMasterService.getCompany(element).subscribe(
      (result: any) => {
        debugger;
        this.companyData = result.result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getCity(): void {
    let element = {
      State: this.employeeDetail.State,
      ActionBy: localStorage.getItem('userID')
    }
    this._employeeMasterService.getCity(element).subscribe(
      (result: any) => {
        debugger;
        this.cityData = result.result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getDesignation(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    }
    this._employeeMasterService.getDesignation(element).subscribe(
      (result: any) => {
        debugger;
        this.designationData = result.result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getState(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    }
    this._employeeMasterService.getState(element).subscribe(
      (result: any) => {
        debugger;
        this.stateData = result.result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getBloodgroup(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    }
    this._employeeMasterService.getBloodGroup(element).subscribe(
      (result: any) => {
        debugger;
        this.bloodgroupData = result.result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getReportTo(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    }
    this._employeeMasterService.getReport(element).subscribe(
      (result: any) => {
        debugger;
        this.reportData = result.result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }


}