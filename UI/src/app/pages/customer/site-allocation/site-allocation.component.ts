import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { SiteAllocationService } from 'src/app/service/customer/site-allocation.service';
import { GetSiteAllocation } from 'src/app/model/Site-allocation/site-allocation.model';
import { ToastyService } from 'ng2-toasty';
import { MyErrorStateMatcher } from 'src/app/login/login.component';

@Component({
  selector: 'app-site-allocation',
  templateUrl: './site-allocation.component.html',
  styleUrls: ['./site-allocation.component.css',
    '../../../../../node_modules/ng2-toasty/style-bootstrap.css',
    '../../../../../node_modules/ng2-toasty/style-default.css',
    '../../../../../node_modules/ng2-toasty/style-material.css',],
  encapsulation: ViewEncapsulation.None
})
export class SiteAllocationComponent implements OnInit {

  getAllSiteAllocation: any;
  constructor(private _SiteAllocationService: SiteAllocationService,
    private toastr: ToastyService) { }
  matcher = new MyErrorStateMatcher();
  position = 'top-right';
  theme = 'material';
  type = 'material';
  CustomerData: any[] = [];
  BranchData: any[] = [];
  SiteData: any[] = [];
  ClassificationData: any[] = [];
  ServiceData: any[] = [];
  ManData: any = [];
  getAllAllocation: GetSiteAllocation[] = [];
  addSiteAllocation: any = {
    CustomerId: 0,
    Id: 0,
    SiteId: 0,
    ClassificationId: 0,
    ServiceId: 0,
    NoofManpower: 0,
    CreatedBy: '',
  }
  
  UnChangeaddSiteAllocation: any = {
    CustomerId: 0,
    Id: 0,
    SiteId: 0,
    ClassificationId: 0,
    ServiceId: 0,
    NoofManpower: 0,
    CreatedBy: '',
  }

  ngOnInit() {
    // this.getSiteAllocation();
    this.getAllCustomers();
    // this.getAllBranch();
    // this.getAllSite();
    // this.getAllClassification();
    // this.getAllService();
  // this.getAllManpowerList();
  }

  resetScreen(): void {
    this.addSiteAllocation = Object.assign({}, this.UnChangeaddSiteAllocation);
    this.getAllSiteAllocation = [];
  }

  getSiteAllocation(): void {
    debugger;
    let element = {
      CustomerId: this.addSiteAllocation.CustomerId,
      ActionBy: localStorage.getItem('userID')
    }
    this._SiteAllocationService.getAllSiteAllocation(element).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.getAllSiteAllocation = result.result;
        console.log(this.getAllSiteAllocation);
      },
      error => {
        if (error.status === 401) { this.toastr.error("Unauthorized"); }
        else { this.toastr.error("Something went wrong! Try Again"); }
      }
    );
  }

  getAllCustomers(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    }
    this._SiteAllocationService.getCustomer(element).subscribe(
      (result: any) => {
        debugger;
        this.CustomerData = result.result;
        console.log(this.CustomerData);
      },
      error => {
        if (error.status === 401) { this.toastr.error("Unauthorized"); }
        else { this.toastr.error("Something went wrong! Try Again"); }
      }
    );
  }

  getAllBranch(): void {
    let element = {
      CustomerId: this.addSiteAllocation.CustomerId,
      ActionBy: localStorage.getItem('userID')
    }
    this._SiteAllocationService.getBranch(element).subscribe(
      (result: any) => {
        this.BranchData = result.result;
        console.log(this.BranchData);
      },
      error => {
        if (error.status === 401) { this.toastr.error("Unauthorized"); }
        else { this.toastr.error("Something went wrong! Try Again"); }
      }
    );
  }

  getAllSite(): void {
    let element = {
      CustomerId: this.addSiteAllocation.CustomerId,
      BranchId: this.addSiteAllocation.Id,
      ActionBy: localStorage.getItem('userID')
    }
    this._SiteAllocationService.getSite(element).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.SiteData = result.result;
        console.log(this.SiteData);
      },
      error => {
        if (error.status === 401) { this.toastr.error("Unauthorized"); }
        else { this.toastr.error("Something went wrong! Try Again"); }
      }
    );
  }

  getAllClassification(): void {
    let element = {
      CustomerId: this.addSiteAllocation.CustomerId,
      BranchId: this.addSiteAllocation.Id,
      SiteId: this.addSiteAllocation.SiteId,
      ActionBy: localStorage.getItem('userID')
    }
    this._SiteAllocationService.getClassification(element).subscribe(
      (result: any) => {
        console.log(result);
        this.ClassificationData = result.result;
        console.log(this.ClassificationData);
      },
      error => {
        if (error.status === 401) { this.toastr.error("Unauthorized"); }
        else { this.toastr.error("Something went wrong! Try Again"); }
      }
    );
  }

  getAllService(): void {
    let element = {
      CustomerId: this.addSiteAllocation.CustomerId,
      ActionBy: localStorage.getItem('userID')
    }
    this._SiteAllocationService.getService(element).subscribe(
      (result: any) => {
        console.log(result);
        this.ServiceData = result.result;
        console.log(this.ServiceData);
      },
      error => {
        if (error.status === 401) { this.toastr.error("Unauthorized"); }
        else { this.toastr.error("Something went wrong! Try Again"); }
      }
    );
  }

  // getService(): void {
  //   let element = {
  //     ActionBy: localStorage.getItem('userID')
  //   };
  //   this._SiteAllocationService.getService(element).subscribe(
  //     (result: any) => {
  //       debugger;
  //       console.log(result);
  //       this.ServiceData = result;
  //       console.log(this.ServiceData);
  //     },
  //     error => {
  //       if (error.status === 401) {
  //         this.toastr.error("Unauthorized");
  //       } else {
  //         this.toastr.error("Something went wrong! Try Again");
  //       }
  //     }
  //   );
  // }

  getAllManpowerList(): void {
    debugger;
    let element = {
      CustomerId: this.addSiteAllocation.CustomerId,
      BranchId: this.addSiteAllocation.Id,
      SiteId: this.addSiteAllocation.SiteId,
      ClassificationId: this.addSiteAllocation.ClassificationId,
      ServiceId: this.addSiteAllocation.ServiceId,
      ActionBy: localStorage.getItem('userID')
    }
    this._SiteAllocationService.getmanpowerList(element).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.ManData = result.result;
        console.log(this.ManData, 'manpower');
      },
      error => {
        if (error.status === 401) { this.toastr.error("Unauthorized"); }
        else { this.toastr.error("Something went wrong! Try Again"); }
      }
    );
  }

  onEnterManpower(event: KeyboardEvent, currentManpower: String) {
    debugger;
    if (event.charCode >= 48 && event.charCode <= 57) {
      currentManpower = currentManpower.concat(event.key);
      if (Number(currentManpower) <= this.ManData.length) {
        return true;
      } else {
        return false;
      }
    } else {
      return false;
    }
  }


  removeSiteAllocation(element): void {
    let deleteElement = {
      Id: element.Id,
      BranchId: element.BranchId,
      CustomerId: element.CustomerId,
      SiteId: element.SiteId,
      ClassificationId: element.ClassificationId,
      ServiceId: element.ServiceId,
      ActionBy: localStorage.getItem('userID')
    }
    this._SiteAllocationService.removeSiteAllocation(deleteElement).subscribe(
      (result: any) => {
        console.log(result);
      },
      error => {
        if (error.status === 401) { this.toastr.error("Unauthorized"); }
        else { this.toastr.error("Something went wrong! Try Again"); }
      }
    );
  }

  AddAllSite(): void {
    debugger;
    if (this.checkValidation()) {
      this.addSite();
    }
  }

  checkValidation(): boolean {
    debugger;
    if (this.addSiteAllocation.CustomerId === 0) {
      this.toastr.error('Select Customer Name')
      return false;
    } else if (this.addSiteAllocation.Id === 0) {
      this.toastr.error('Select Branch Name')
      return false;
    }
    else if (this.addSiteAllocation.SiteId === 0) {
      this.toastr.error('Select Site Name')
      return false;
    }
    else if (this.addSiteAllocation.ClassificationId === 0) {
      this.toastr.error('Select Classification Name')
      return false;
    }
    else if (this.addSiteAllocation.ServiceId === 0) {
      this.toastr.error('Select Service Name')
      return false;
    }
    else if (this.addSiteAllocation.NoofManpower === 0) {
      this.toastr.error('Enter No Of Manpower')
      return false;
    } else {
      return true;
    }
  }

  addSite() {
    debugger;
    let addSiteDetails = {
      CustomerId: this.addSiteAllocation.CustomerId,
      BranchId: this.addSiteAllocation.Id,
      SiteId: this.addSiteAllocation.SiteId,
      ClassificationId: this.addSiteAllocation.ClassificationId,
      Service: this.addSiteAllocation.ServiceId,
      NoofManpower: this.addSiteAllocation.NoofManpower,
      CreatedBy: localStorage.getItem('userID'),
    }
    this._SiteAllocationService.addSiteAllocation(addSiteDetails).subscribe((result: any) => {
      debugger;
      if (result.result == true) {
        this.toastr.error("Successfully saved");
        this.getSiteAllocation();
      }
    }, (error) => {
      console.log(error);
    })
  }
}
