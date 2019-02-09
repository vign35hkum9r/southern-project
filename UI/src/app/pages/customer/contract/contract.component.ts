import { Component, OnInit, ViewChild, ViewEncapsulation } from "@angular/core";
import { MatPaginator, MatTableDataSource, ErrorStateMatcher } from "@angular/material";
import { ContractMasterService } from "src/app/service/customer/contract-master.service";
import { DatePipe } from "@angular/common";
import { ToastyService } from "ng2-toasty";
import { FormGroupDirective, FormControl, NgForm } from "@angular/forms";
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: "app-contract",
  templateUrl: "./contract.component.html",
  styleUrls: ["./contract.component.css",
  '../../../../../node_modules/ng2-toasty/style-bootstrap.css',
  '../../../../../node_modules/ng2-toasty/style-default.css',
  '../../../../../node_modules/ng2-toasty/style-material.css',],
  encapsulation: ViewEncapsulation.None
})
export class ContractComponent implements OnInit {

  constructor(private _contractMasterService: ContractMasterService,
    private _date: DatePipe,
    private toastr: ToastyService) { }
    matcher = new MyErrorStateMatcher();
    position = 'top-right';
    theme = 'material';
    type = 'material';
  viewFlag = true;
  StartDate =  new Date();
  EndDate = new Date();
  isEditing = false;
  CustomerData: any[] = [];
  FilterCustomerData: any[] = [];
  SetCustomerData: any[] = [];
  AllCustomerData: any[] = [];
  contractDetail: any = {
    CustomerId: "",
    StartDate: new Date(),
    EndDate: new Date(),
    CreatedBy: localStorage.getItem('userID'),
    modifiedBy: localStorage.getItem('userID'),
    Active: true
  };
  UnchangecontractDetail: any = {
    CustomerId: "",
    StartDate: new Date(),
    EndDate: new Date(),
    CreatedBy: localStorage.getItem('userID'),
  };

  UpdatecontractDetail: any = {
    CustomerId: "",
    StartDate: new Date(),
    EndDate: new Date(),
    modifiedBy: localStorage.getItem('userID'),
    Active: true
  };
  displayedColumns: string[] = [
    "CustomerId",
    "CustomerName",
    "StartDate",
    "EndDate",
    "TotalAmount",
    "Active",
    "action"
  ];

  dataSource = new MatTableDataSource<any>();
  @ViewChild(MatPaginator) tablePaginator: MatPaginator;



  ngOnInit() {
    this.getAllCustomers();
    this.LoadContractMaster();
  }

  LoadContractMaster(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    };
    this._contractMasterService.getAllContract(element).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.CustomerData = result.result;
        this.matTableConfig(this.CustomerData);
        this.SetCustomerData=this.CustomerData;
        console.log(this.CustomerData);
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

  matTableConfig(tableRecords: any): void {
    this.dataSource = new MatTableDataSource(tableRecords);
    this.dataSource.paginator = this.tablePaginator;
  }

  editContractDetails(modifyContract): void {
    debugger;
    this.contractDetail = modifyContract;
    this.viewFlag = !this.viewFlag;
    this.isEditing = true;
  }

  addContractDetails(): void {
    debugger;
    if (this.contractDetail.CustomerId != '') {
      if (!this.isEditing) {
        this.contractDetail.StartDate = this._date.transform(this.StartDate, 'yyyy-MM-dd');
        this.contractDetail.EndDate = this._date.transform(this.EndDate, 'yyyy-MM-dd');
        this._contractMasterService.addContract(this.contractDetail).subscribe(
          (result: any) => {
            if (result.result === true) {
              this.toastr.success("Successfully added");
              this.ngOnInit();
              this.viewFlag = !this.viewFlag;
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
        this._contractMasterService.modifyContract(this.contractDetail).subscribe(
          (result: any) => {
            if (result.result === true) {
              this.toastr.success("Successfully modified");
              this.ngOnInit();
              this.viewFlag = !this.viewFlag;
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
    }else {
      this.toastr.error("Select Customer Name");
    }
  }

  searchId(searchValue: any){
    debugger;
    searchValue = searchValue.trim();
    searchValue = searchValue.toLocaleLowerCase();
    this.FilterCustomerData = this.SetCustomerData.filter(
      data => data.CustomerId.toString().toLocaleLowerCase().startsWith(
        searchValue.toLocaleLowerCase()
      )
    );
    this.CustomerData = this.FilterCustomerData;
    this.matTableConfig(this.CustomerData);
  }

  searchName(searchValue: any){
    debugger;
    searchValue = searchValue.trim();
    searchValue = searchValue.toLocaleLowerCase();
    this.FilterCustomerData = this.SetCustomerData.filter(
      data => data.CustomerName.toLocaleLowerCase().startsWith(
        searchValue.toLocaleLowerCase()
      )
    );
    this.CustomerData = this.FilterCustomerData;
    this.matTableConfig(this.CustomerData);
  }

  searchDate(searchValue: any){
    debugger;
    searchValue = searchValue.trim();
    searchValue = searchValue.toLocaleLowerCase();
    this.FilterCustomerData = this.SetCustomerData.filter(
      data => data.StartDate.toLocaleLowerCase().startsWith(
        searchValue.toLocaleLowerCase()
      )
    );
    this.CustomerData = this.FilterCustomerData;
    this.matTableConfig(this.CustomerData);
  }

  searchAmount(searchValue: any){
    debugger;
    searchValue = searchValue.trim();
    searchValue = searchValue.toLocaleLowerCase();
    this.FilterCustomerData = this.SetCustomerData.filter(
      data => data.TotalAmount.toString().toLocaleLowerCase().startsWith(
        searchValue.toLocaleLowerCase()
      )
    );
    this.CustomerData = this.FilterCustomerData;
    this.matTableConfig(this.CustomerData);
  }

  removeContractDetail(element): void {
    debugger
    let deleteElement = {
       Id: element.Id,
      Active: element.Active,
      ActionBy: localStorage.getItem('userID')
    }
    this._contractMasterService.removeContract(deleteElement).subscribe(
      (result: any) => {
        if(result.result == true) {
          this.toastr.success("Remove Successfully");
          this.LoadContractMaster();
        } 
      },
      error => {
        if (error.status === 401) {  this.toastr.error("Unauthorized"); }
        else {  this.toastr.error("Something went wrong! Try Again"); }
      }
    );
  }

  getAllCustomers(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    };
    this._contractMasterService.getAllSuccessCustomer(element).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.AllCustomerData = result.result;
        console.log(this.AllCustomerData);
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

  onNewClick() {
    this.viewFlag = !this.viewFlag;
  }

  resetScreen(): void {
    this.contractDetail = Object.assign({}, this.UnchangecontractDetail);
    this.viewFlag = !this.viewFlag;
  }
}
