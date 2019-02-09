import { Component, OnInit } from '@angular/core';
import { AssignFieldOfficer } from 'src/app/model/assign-field-officer/assign-field-officer.model';
import { AssignFieldOfficerService } from 'src/app/service/operation/assign-field-officer.service';


@Component({
  selector: 'app-assign-field-officer',
  templateUrl: './assign-field-officer.component.html',
  styleUrls: ['./assign-field-officer.component.css']
})
export class AssignFieldOfficerComponent implements OnInit {

  viewFlag = true;
  isEditing = false;

  assignFieldOfficer: AssignFieldOfficer = {
    EmployeeId: 0,
    CustomerId: 0,
    BranchId: 0,
    Site: {},
    CreatedBy: localStorage.getItem('userID'),
  }

  customerData: any[] = [];
  areaData: any[] = [];
  siteData: any[] = [];
  employeeData: any[] = [];
  fieldOfficerData: any[] = [];

  constructor(private _assignFieldOfficerService: AssignFieldOfficerService) { }

  ngOnInit() {
    this.getEmployees();
    this.getCustomers();
  }

  addFieldOfficer(): void {
    debugger;
    var tempSite = [];
    for (var i in this.assignFieldOfficer.Site) {
      var temp = {
        SiteId:this.assignFieldOfficer.Site[i].SiteId
      }
      tempSite.push(temp);
    }
    let element = {
      ContractId: this.assignFieldOfficer.EmployeeId,
      CustomerId: this.assignFieldOfficer.CustomerId,
      BranchId: this.assignFieldOfficer.BranchId,
      SiteId: tempSite,
      CreatedBy: localStorage.getItem('userID')
    }
    this._assignFieldOfficerService.addFieldOfficer(element).subscribe(
      (result: any) => {
        if (result.status === 200) { alert("Successfully added"); }
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }


  removeFieldOfficer(obj: any): void {
    let element = {
      Id: obj.Id,
      ActionBy:localStorage.getItem('userID')
    }
    this._assignFieldOfficerService.removeFieldOfficer(element).subscribe(
      (result: any) => {
        const manpowerData = result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getEmployees(): void {
    let element = {
      ActionBy:localStorage.getItem('userID')
    }
    this._assignFieldOfficerService.getEmployees(element).subscribe(
      (result: any) => {
        this.employeeData = result.result;
        // console.log(this.employeeData);
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getFieldOfficer(): void {
    debugger;
    let element = {
      EmployeeId:this.assignFieldOfficer.EmployeeId,
      ActionBy:localStorage.getItem('userID')
    }
    this._assignFieldOfficerService.getFieldOfficer(element).subscribe(
      (result: any) => {
        this.fieldOfficerData = result.result;
        console.log(this.fieldOfficerData);
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getCustomers(): void {
    let element = {
      ActionBy:localStorage.getItem('userID')
    }
    this._assignFieldOfficerService.getCustomers(element).subscribe(
      (result: any) => {
        this.customerData = result.result;
        this.areaData = [];
        this.siteData = [];
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getArea(): void {
    this.areaData = [];
    let element = {
      CustomerId : this.assignFieldOfficer.CustomerId,  
      ActionBy:localStorage.getItem('userID')
    }
    this._assignFieldOfficerService.getArea(element).subscribe(
      (result: any) => {
        this.areaData = result.result;
        this.siteData = [];
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getSite(): void {
    let element = {
      CustomerId : this.assignFieldOfficer.CustomerId, 
      BranchId : this.assignFieldOfficer.BranchId,  
      ActionBy:localStorage.getItem('userID')
    }
    this._assignFieldOfficerService.getSite(element).subscribe(
      (result: any) => {
        this.siteData = result.result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  onClear() {
    this.assignFieldOfficer = {
      EmployeeId: 0,
      CustomerId: 0,
      BranchId: 0,
      Site: {},
      CreatedBy: "localStorage.getItem('userID')",
    }
    this.assignFieldOfficer.Site = [];
    this.fieldOfficerData = [];
  }
}
