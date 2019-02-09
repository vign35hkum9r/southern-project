import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatTableDataSource, MatPaginator } from '@angular/material';
import { ContractDetailService } from 'src/app/service/customer/contract-detail.service';
import { MyErrorStateMatcher } from 'src/app/login/login.component';
import { ToastyService } from 'ng2-toasty';
@Component({
  selector: 'app-contract-detail',
  templateUrl: './contract-detail.component.html',
  styleUrls: ['./contract-detail.component.css',
  '../../../../../node_modules/ng2-toasty/style-bootstrap.css',
  '../../../../../node_modules/ng2-toasty/style-default.css',
  '../../../../../node_modules/ng2-toasty/style-material.css',],
  encapsulation: ViewEncapsulation.None
})
export class ContractDetailComponent implements OnInit {

  constructor(private _contractDetail: ContractDetailService,
    private toastr: ToastyService) { }

  matcher = new MyErrorStateMatcher();
  position = 'top-right';
  theme = 'material';
  type = 'material';
  viewFlag = true;
  isEditing = false;
  isEditing1 = false;
  agreementView = false;
  contractView = false;
  customer: any;
  AllCustomerData: any[] = [];
  ContractIdData: any[] = [];
  ContractData: any[] = [];
  ConsumeData: any[] = [];
  DesignationData: any[] = [];
  ServiceData: any[] = [];

  addContractDetail: any = {
    ContractId: 0,
    CustomerId: 0,
    Service: 0,
    Designation: '',
    RatePerEmployee: 0,
    EmployeeCount: 0,
    CreatedBy: localStorage.getItem('userID'),
    modifiedBy: localStorage.getItem('userID'),
    Active: true

  }
  unChangeaddContractDetail: any = {
    ContractId: 0,
    CustomerId: 0,
    Service: 0,
    Designation: '',
    RatePerEmployee: 0,
    EmployeeCount: 0,
    CreatedBy: localStorage.getItem('userID')
  }
  addConsumetDetail: any = {
    Id: 0,
    ContractId: 0,
    SuppliedByCustomer: 0,
    PF: 0,
    ESIC: 0,
    Uniform: 0,
    LeaveWithWages: 0,
    Bonus: 0,
    Conveyance: 0,
    Gratuity: 0,
    ContractAmount: 0,
    ServiceCharge: 0,
    ServiceTax: 18,
    TotalAmount: 0,
    Remarks: '',
    CreatedBy: localStorage.getItem('userID'),
    modifiedBy: localStorage.getItem('userID'),
    Active: true

  }
  unChangeaddConsumetDetail: any = {
    ContractId: 0,
    SuppliedByCustomer: true,
    PF: true,
    ESIC: true,
    Uniform: true,
    LeaveWithWages: true,
    Bonus: true,
    Conveyance: true,
    Gratuity: true,
    ContractAmount: 0,
    ServiceCharge: 0,
    ServiceTax: 18,
    TotalAmount: 0,
    Remarks: '',
    CreatedBy: localStorage.getItem('userID')
  }
  ngOnInit() {
    // this.getAllContractDetail();
    this.getAllConsumeDetail();
   // this.getAllCustomers();
   // this.getService();
    console.log(this.customer)
    // this.getDesignation();
  }

  getAllCustomers(): void {

    let element = {
      ActionBy: localStorage.getItem('userID')
    };
    this._contractDetail.getAllSuccessCustomer(element).subscribe(
      (result: any) => {

        console.log(result);
        this.AllCustomerData = result.result;
        console.log(this.AllCustomerData);
        this.ContractData = [];
        this.ConsumeData = [];
      },
      error => {
        if (error.status === 401) {
          this.toastr.error("Unauthorized");
        } else {
          this.toastr.error("Something went wrong! Try Again");
        }
      }
    );
  }

  getAllContractDetail(): void {
    debugger;
    let element = {
      ContractId: this.customer.Id,
      ActionBy: localStorage.getItem('userID')
    };
    this._contractDetail.getAllContractDetailById(element).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.ContractData = result.result;
        console.log(this.ContractData);
        this.getAllConsumeDetail();
      },
      error => {
        if (error.status === 401) {
          this.toastr.error("Unauthorized");
        } else {
          this.toastr.error("Something went wrong! Try Again");
        }
      }
    );
  }


  getAllConsumeDetail(): void {
    debugger;
    let element = {
      ContractId: this.customer.Id,
      ActionBy: localStorage.getItem('userID')
    };
    this._contractDetail.getAllConsumeById(element).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.ConsumeData = result.result;
        console.log(this.ConsumeData);
      },
      error => {
        if (error.status === 401) {
          this.toastr.error("Unauthorized");
        } else {
          this.toastr.error("Something went wrong! Try Again");
        }
      }
    );
  }

  getDesignation(): void {
    // let element = {
    //   Id: this.addContractDetail.Service,
    // };
    this._contractDetail.getDesignation(this.addContractDetail.Service).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.DesignationData = result;
        console.log(this.DesignationData, 'Des');
      },
      error => {
        if (error.status === 401) {
          this.toastr.error("Unauthorized");
        } else {
          this.toastr.error("Something went wrong! Try Again");
        }
      }
    );
  }

  getService(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    };
    this._contractDetail.getService(element).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.ServiceData = result;
        console.log(this.ServiceData);
        this.DesignationData = [];
      },
      error => {
        if (error.status === 401) {
          this.toastr.error("Unauthorized");
        } else {
          this.toastr.error("Something went wrong! Try Again");
        }
      }
    );
  }

  AddContract(): void {
    debugger;
    if (this.checkValidation()) {
      this.addContractDetails();
    }
  }

  checkValidation(): boolean {
    if (this.addContractDetail.Service === 0) {
      this.toastr.error('Select Service')
      return false;
    } else if (this.addContractDetail.Designation === '') {
      this.toastr.error('Select Designation')
      return false;
    }
    else if (this.addContractDetail.RatePerEmployee === 0) {
      this.toastr.error('Enter Rate Per Employee')
      return false;
    }
    else if (this.addContractDetail.EmployeeCount === 0) {
      this.toastr.error('Enter Employee Count')
      return false;
    } else {
      return true;
    }
  }



  addContractDetails(): void {
    this.addContractDetail.ContractId = this.customer.Id;
    this.addContractDetail.CustomerId = this.customer.CustomerId;
    if (!this.isEditing) {
      this._contractDetail.addContractDetail(this.addContractDetail).subscribe(
        (result: any) => {
          if (result.result === true) {
            this.toastr.error("Successfully added");
            this.getAllContractDetail();
            this.contractView = !this.contractView
          }
        },
        error => {
          if (error.status === 401) {
            this.toastr.error("Unauthorized");
          } else {
            this.toastr.error("Something went wrong! Try Again");
          }
        }
      );
    } else {
      this._contractDetail.modifyContractDetail(this.addContractDetail).subscribe(
        (result: any) => {
          if (result.result === true) {
            this.toastr.error("Successfully modified");
            this.getAllContractDetail();
            this.contractView = !this.contractView
          }
        },
        error => {
          if (error.status === 401) {
            this.toastr.error("Unauthorized");
          } else {
            this.toastr.error("Something went wrong! Try Again");
          }
        }
      );
    }
  }
  
  editContractDetails(modifyContract): void {
    debugger;
    this.addContractDetail = modifyContract;
    this.addContractDetail.Service = modifyContract.Service;
    this.addContractDetail.Designation = modifyContract.Designation;
    this.getDesignation();
    // this.DesignationData = [{ DesignationId: Number(modifyContract.Designation), DesignationName: modifyContract.DesignationName }];
    this.contractView = !this.contractView
    this.isEditing = true;
  }
  resetContractScreen(): void {
    this.addContractDetail = Object.assign({}, this.unChangeaddContractDetail);
    this.contractView = !this.contractView
  }
  addConsumeDetails(): void {
    debugger;
    if (!this.isEditing1) {
      let addElement = {
        ContractId: this.addConsumetDetail.ContractId,
        SuppliedByCustomer: this.addConsumetDetail.SuppliedByCustomer,
        PF: this.addConsumetDetail.PF,
        ESIC: this.addConsumetDetail.ESIC,
        Uniform: this.addConsumetDetail.Uniform,
        LeaveWithWages: this.addConsumetDetail.LeaveWithWages,
        Bonus: this.addConsumetDetail.Bonus,
        Conveyance: this.addConsumetDetail.Conveyance,
        Gratuity: this.addConsumetDetail.Gratuity,
        ContractAmount: this.addConsumetDetail.ContractAmount,
        ServiceCharge: this.addConsumetDetail.ServiceCharge,
        ServiceTax: this.addConsumetDetail.ServiceTax,
        TotalAmount: this.addConsumetDetail.TotalAmount,
        Remarks: this.addConsumetDetail.Remarks,
        CreatedBy: localStorage.getItem('userID'),
      }
      this._contractDetail.addConsume(addElement).subscribe(
        (result: any) => {
          if (result.result === true) {
            debugger;
            this.getAllConsumeDetail();
            this.toastr.error("Successfully added");
            this.agreementView = !this.agreementView
          }
        },
        error => {
          if (error.status === 401) {
            this.toastr.error("Unauthorized");
          } else {
            this.toastr.error("Something went wrong! Try Again");
          }
        }
      );
    } else {
      let ModifyElement = {
        ContractId: this.addConsumetDetail.ContractId,
        SuppliedByCustomer: this.addConsumetDetail.SuppliedByCustomer,
        PF: this.addConsumetDetail.PF,
        ESIC: this.addConsumetDetail.ESIC,
        Uniform: this.addConsumetDetail.Uniform,
        LeaveWithWages: this.addConsumetDetail.LeaveWithWages,
        Bonus: this.addConsumetDetail.Bonus,
        Conveyance: this.addConsumetDetail.Conveyance,
        Gratuity: this.addConsumetDetail.Gratuity,
        ContractAmount: this.addConsumetDetail.ContractAmount,
        ServiceCharge: this.addConsumetDetail.ServiceCharge,
        ServiceTax: this.addConsumetDetail.ServiceTax,
        TotalAmount: this.addConsumetDetail.TotalAmount,
        Remarks: this.addConsumetDetail.Remarks,
        Active: this.addConsumetDetail.Active,
        modifiedBy: localStorage.getItem('userID'),
      }
      this._contractDetail.modifyConsume(ModifyElement).subscribe(
        (result: any) => {
          if (result.result === true) {
            debugger;
            this.getAllConsumeDetail();
            this.toastr.error("Successfully modified");
            this.agreementView = !this.agreementView
          }
        },
        error => {
          if (error.status === 401) {
            this.toastr.error("Unauthorized");
          } else {
            this.toastr.error("Something went wrong! Try Again");
          }
        }
      );
    }
  }
  editConsumeDetails(modifyConsume): void {
    debugger;
    this.addConsumetDetail = modifyConsume;
    this.agreementView = !this.agreementView
    this.isEditing1 = true;
  }
  resetConsumeScreen(): void {
    this.addConsumetDetail = Object.assign({}, this.unChangeaddConsumetDetail);
    this.agreementView = !this.agreementView
  }

  removeContractDetail(element): void {
    let deleteElement = {
      Id: element.Id,
      Active: element.Active,
      ActionBy: localStorage.getItem('userID')
    }
    this._contractDetail.removeContractDetail(deleteElement).subscribe(
      (result: any) => {
        if (result.result == true) {
          this.toastr.error("Remove Successfully");
          this.getAllContractDetail();
        }
      },
      error => {
        if (error.status === 401) { this.toastr.error("Unauthorized"); }
        else { this.toastr.error("Something went wrong! Try Again"); }
      }
    );
  }
  onNewClick() {
    this.viewFlag = !this.viewFlag;
  }
  onListClick() {
    this.viewFlag = !this.viewFlag;
  }

  onInput() {
    this.addConsumetDetail.TotalAmount = +this.addConsumetDetail.ContractAmount + (+this.addConsumetDetail.ContractAmount * (+this.addConsumetDetail.ServiceTax / 100));
  }

  onEnterNumber(event: any, maxValue: number, allowPeriod?: boolean) {
    if (allowPeriod) {
      if (
        (event.charCode >= 48 && event.charCode <= 57) ||
        event.charCode === 46
      ) {
        if (event.charCode === 48 && event.target.value.indexOf("0") === 0) {
          return false;
        } else {
          if (
            Number(
              event.target.value
                .toString()
                .concat(event.key !== "." ? event.key : "")
            ) <= maxValue
          ) {
            if (
              String(event.target.value).includes(".") === false ||
              event.charCode !== 46
            ) {
              if (String(event.target.value).includes(".") === true) {
                let decimalLength = String(event.target.value)
                  .concat(event.key)
                  .split(".")[1].length;
                if (decimalLength <= 2) {
                  return true;
                } else {
                  return false;
                }
              } else {
                return true;
              }
            } else {
              return false;
            }
          } else {
            return false;
          }
        }
      } else {
        return false;
      }
    } else {
      if (event.charCode >= 48 && event.charCode <= 57) {
        if (
          Number(event.target.value.toString().concat(event.key)) <= maxValue
        ) {
          return true;
        } else {
          return false;
        }
      } else {
        return false;
      }
    }
  }
}
