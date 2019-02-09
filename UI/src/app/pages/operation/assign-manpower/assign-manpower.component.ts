import { Component, OnInit } from '@angular/core';
import { AssignManpower } from 'src/app/model/assign-manpower/assign-manpower.model';
import { AssignManpowerService } from 'src/app/service/operation/assign-manpower.service';

@Component({
  selector: 'app-assign-manpower',
  templateUrl: './assign-manpower.component.html',
  styleUrls: ['./assign-manpower.component.css']
})
export class AssignManpowerComponent implements OnInit {

  viewFlag = true;
  isEditing = false;

  assignManpower: AssignManpower = {
    ContractId: 0,
    Customer: {},
    BranchId: 0,
    SiteId: 0,
    ClassificationId: 0,
    ServiceId: 0,
    CreatedBy: localStorage.getItem('userID')
  }
  selectedManpower = [];
  // getAssignManpower: GetAssignManpower = {
  //   AllocationId: 0,
  //   ContractId: 0,
  //   CustomerId: 0,
  //   BranchId: 0,
  //   SiteId: 0,
  //   ClassificationId: 0,
  //   ServiceId: 0,
  //   NoofManpower: 0,
  //   CustomerName: "",
  //   BranchName: "",
  //   SiteName: "",
  //   ClassificationName: "",
  //   ServiceName: "",
  //   ManPowerId: 0,
  //   ManPowerName: "",
  // }
  customerData: any[] = [];
  areaData: any[] = [];
  siteData: any[] = [];
  assignManpowerData: any[] = [];
  serviceData: any[] = [];
  classificationData: any[] = [];
  manpowerData: any[] = [];

  constructor(private _assignManpowerService: AssignManpowerService) { }

  ngOnInit() {
    this.getCustomers();
  }
  
  addAssignManpower(): void {
    debugger;
    var tempManpower = [];
    for (var i in this.selectedManpower) {
      var temp = {
        ManPowerId:this.selectedManpower[i].ManPowerId
      }
      tempManpower.push(temp);
    }
    let element = {
      ContractId: this.assignManpower.Customer.ContractId,
      CustomerId: this.assignManpower.Customer.CustomerId,
      BranchId: this.assignManpower.BranchId,
      SiteId: this.assignManpower.SiteId,
      ClassificationId: this.assignManpower.ClassificationId,
      ServiceId : this.assignManpower.ServiceId, 
      ManPower: tempManpower,
      ActionBy: localStorage.getItem('userID')
    }
    this._assignManpowerService.addAssignManpower(element).subscribe(
      (result: any) => {
        if (result.status === 200) { alert("Successfully added"); }
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  // editAssignManpower(modifyManpower): void {
  //   debugger;
  //   this.assignManpower = modifyManpower;
  //   this.viewFlag = !this.viewFlag;
  //   this.isEditing = true;
  // }


  removeAssignManpower(obj: any): void {
    let element = {
      AllocationId: obj.AllocationId,
      ActionBy:localStorage.getItem('userID')
    }
    this._assignManpowerService.removeAssignManpower(element).subscribe(
      (result: any) => {
        const manpowerData = result;
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
    this._assignManpowerService.getCustomers(element).subscribe(
      (result: any) => {
        this.customerData = result.result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getArea(): void {
    let element = {
      CustomerId : this.assignManpower.Customer.CustomerId,  
      ActionBy:localStorage.getItem('userID')
    }
    this._assignManpowerService.getArea(element).subscribe(
      (result: any) => {
        this.areaData = result.result;
        this.getAssignManpowers();
        this.siteData = [];
        this.classificationData = [];
        this.serviceData = [];
        this.manpowerData = [];
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getSite(): void {
    let element = {
      CustomerId : this.assignManpower.Customer.CustomerId, 
      BranchId : this.assignManpower.BranchId,  
      ActionBy:localStorage.getItem('userID')
    }
    this._assignManpowerService.getSite(element).subscribe(
      (result: any) => {
        this.siteData = result.result;
        this.classificationData = [];
        this.serviceData = [];
        this.manpowerData = [];
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getClassification(): void {
    let element = {
      CustomerId : this.assignManpower.Customer.CustomerId, 
      BranchId : this.assignManpower.BranchId,
      SiteId : this.assignManpower.SiteId,  
      ActionBy:localStorage.getItem('userID')
    }
    this._assignManpowerService.getClassification(element).subscribe(
      (result: any) => {
        this.classificationData = result.result;
        this.serviceData = [];
        this.manpowerData = [];
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getService(): void {
    let element = {
      CustomerId : this.assignManpower.Customer.CustomerId, 
      BranchId : this.assignManpower.BranchId,
      SiteId : this.assignManpower.SiteId,
      ClassificationId : this.assignManpower.ClassificationId,  
      ActionBy:localStorage.getItem('userID')
    }
    this._assignManpowerService.getService(element).subscribe(
      (result: any) => {
        this.serviceData = result.result;
        this.manpowerData = [];
        console.log(this.serviceData);
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getManpower(): void {
    let element = {
      ServiceId : this.assignManpower.ServiceId,  
      ActionBy:localStorage.getItem('userID')
    }
    this._assignManpowerService.getManpower(element).subscribe(
      (result: any) => {
        this.manpowerData = result.result;
        console.log(this.manpowerData);
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getAssignManpowers(): void {
    let element = {
      CustomerId : this.assignManpower.Customer.CustomerId,
      ActionBy:localStorage.getItem('userID')
    }
    this._assignManpowerService.getAssignManpowers(element).subscribe(
      (result: any) => {
        this.assignManpowerData = result.result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  onClear(){
    this.assignManpower = {
      ContractId: 0,
      Customer: {},
      BranchId: 0,
      SiteId: 0,
      ClassificationId: 0,
      ServiceId: 0,
      CreatedBy: localStorage.getItem('userID')
    }
    this.areaData = [];
    this.siteData = [];
    this.classificationData = [];
    this.serviceData = [];
    this.manpowerData = [];
    this.assignManpowerData = [];
  }
}
