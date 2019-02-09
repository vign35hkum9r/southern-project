import { Component, OnInit, ViewChild, ViewEncapsulation } from "@angular/core";
import { MatPaginator, MatTableDataSource } from "@angular/material";
import { CustomerRegistrationService } from "src/app/service/customer/customer-registration.service";
import { MyErrorStateMatcher } from "src/app/login/login.component";
import { ToastyService } from "ng2-toasty";
import { Customer } from "src/app/model/customer-registration/customer-registration.model";

@Component({
  selector: "app-customer-registration",
  templateUrl: "./customer-registration.component.html",
  styleUrls: ["./customer-registration.component.css",
    '../../../../../node_modules/ng2-toasty/style-bootstrap.css',
    '../../../../../node_modules/ng2-toasty/style-default.css',
    '../../../../../node_modules/ng2-toasty/style-material.css',],
  encapsulation: ViewEncapsulation.None
})
export class CustomerRegistrationComponent implements OnInit {

  matcher = new MyErrorStateMatcher();
  position = 'top-right';
  theme = 'material';
  type = 'material';
  viewFlag: boolean = true;
  CustomerTableData: any[] = [];
  FilterCustomerTableData: any[] = [];
  SetCustomerData: any[] = [];
  CustomerData: any[] = [];
  CompanyData: any[] = [];
  CityData: any[] = [];
  StateData: any[] = [];
  isEditing: boolean;
  customer: any = {
    Id: "",
    Name: "",
    ContactNo: "",
    ContactPerson: "",
    ConcernPerson: "",
    Email: "",
    Address: "",
    CompanyId: 0,
    Contact: "",
    State: 0,
    City: 0,
    GSTNo: "",
    CGST: 0,
    IGST: 0,
    SGST: 0,
    PANNumber: "",
    CINNumber: "",
    CreatedBy: localStorage.getItem('userID'),
    Active: true,
    ModifiedBy: localStorage.getItem('userID'),
  };

  UnChangedcustomer: any = {
    Id: "",
    Name: "",
    ContactNo: "",
    ContactPerson: "",
    ConcernPerson: "",
    Email: "",
    Address: "",
    CompanyId: 0,
    Contact: "",
    State: 0,
    City: 0,
    GSTNo: "",
    CGST: 0,
    IGST: 0,
    SGST: 0,
    PANNumber: "",
    CINNumber: "",

  };

  displayedColumns: string[] = [
    "Id",
    "Name",
    "ContactNo",
    "Email",
    "Address",
    "GSTNo",
    "CompanyName",
    "StateName",
    "CityName",
    "Active",
    "action"
  ];
  dataSource = new MatTableDataSource<any>();
  @ViewChild(MatPaginator) tablePaginator: MatPaginator;

  constructor(
    private _customerRegistrationService: CustomerRegistrationService,
    private toastr: ToastyService
  ) { }

  ngOnInit() {
    this.getCustomers();
    this.getAllCustomers();
    this.getAllCompany();
    this.getAllState();
    // this.getAllCity();
  }

  onNewClick() {
    this.viewFlag = !this.viewFlag;
    this.isEditing = false;
  }

  onListClick() {
    this.viewFlag = !this.viewFlag;
    this.onCancel();
  }

  saveCustomer(): void {
    debugger;
    if (this.checkValidation()) {
      this.addCustomer();
    }
  }

  checkValidation(): boolean {
    if (this.customer.Name === '') {
      this.toastr.error('Enter Customer Name')
      return false;
    } else if (this.customer.CompanyId === 0) {
      this.toastr.error('Select Company')
      return false;
    } else if (this.customer.ContactNo === '') {
      this.toastr.error('Enter ContactNo')
      return false;
    } else if (this.customer.State === 0) {
      this.toastr.error('Select State')
      return false;
    }
    else if (this.customer.Email === '') {
      this.toastr.error('Enter Email')
      return false;
    }
    else if (this.customer.City === 0) {
      this.toastr.error('Select City')
      return false;
    }
    else if (this.customer.ContactPerson === '') {
      this.toastr.error('Enter Contact Person')
      return false;
    }
    else if (this.customer.Address === '') {
      this.toastr.error('Enter Address')
      return false;
    }
    else if (this.customer.ConcernPerson === '') {
      this.toastr.error('Enter Concern Person')
      return false;
    }
    else if (this.customer.PANNumber === '') {
      this.toastr.error('Enter PAN Number')
      return false;
    }
    else if (this.customer.GSTNo === '') {
      this.toastr.error('Enter GSTNo')
      return false;
    }
    else if (this.customer.IGST === 0) {
      this.toastr.error('Enter IGST')
      return false;
    }
    else if (this.customer.CGST === 0) {
      this.toastr.error('Enter CGST')
      return false;
    }
    else if (this.customer.SGST === 0) {
      this.toastr.error('Enter SGST')
      return false;
    }
    else if (this.customer.CINNumber === '') {
      this.toastr.error('Enter CINNumber')
      return false;
    } else {
      return true;
    }
  }

  addCustomer(): void {
    debugger;
    if (!this.isEditing) {
      let addElement = {
        Id: this.customer.Id,
        Name: this.customer.Name,
        ContactNo: this.customer.ContactNo,
        ContactPerson: this.customer.ContactPerson,
        ConcernPerson: this.customer.ConcernPerson,
        Email: this.customer.Email,
        Address: this.customer.Address,
        CompanyId: this.customer.CompanyId,
        Mobile: this.customer.Contact,
        State: this.customer.State,
        City: this.customer.City,
        GSTNo: this.customer.GSTNo,
        CGST: this.customer.CGST,
        IGST: this.customer.IGST,
        SGST: this.customer.SGST,
        PANNumber: this.customer.PANNumber,
        CINNumber: this.customer.CINNumber,
        CreatedBy: localStorage.getItem('userID'),
        Active: true,
        ModifiedBy: localStorage.getItem('userID'),
      }
      this._customerRegistrationService.addCustomer(addElement).subscribe(
        (result: any) => {
          if (result.result === true) {
            this.toastr.error("Successfully added");
            this.ngOnInit();
            this.onNewClick();
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
      let modifyElement = new Customer()
      modifyElement.Id = this.customer.Id,
        modifyElement.Name = this.customer.Name,
        modifyElement.ContactNo = this.customer.ContactNo,
        modifyElement.ContactPerson = this.customer.ContactPerson,
        modifyElement.ConcernPerson = this.customer.ConcernPerson,
        modifyElement.Email = this.customer.Email,
        modifyElement.Address = this.customer.Address,
        modifyElement.CompanyId = this.customer.CompanyId,
        // modifyElement.Mobile = this.customer.Contact,
        modifyElement.State = this.customer.State,
        modifyElement.City = this.customer.City,
        modifyElement.GSTNo = this.customer.GSTNo,
        modifyElement.CGST = this.customer.CGST,
        modifyElement.IGST = this.customer.IGST,
        modifyElement.SGST = this.customer.SGST,
        modifyElement.PANNumber = this.customer.PANNumber,
        modifyElement.CINNumber = this.customer.CINNumber,
        // CreatedBy: localStorage.getItem('userID'),
        modifyElement.Active = true,
        modifyElement.ModifiedBy = String(localStorage.getItem('userID')),
        this._customerRegistrationService.modifyCustomer(modifyElement).subscribe(
          (result: any) => {
            if (result.result === true) {
              this.toastr.error("Successfully modified");
              this.ngOnInit();
              this.onNewClick();
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

  modifyCustomer(modifyValues: any): void {
    debugger;
    this.customer = modifyValues;
    this.CityData = [{ CityId: modifyValues.City, CityName: modifyValues.CityName }];
    this.getAllCity();
    this.viewFlag = !this.viewFlag;
    this.isEditing = true;
  }

  resetScreen(): void {
    this.customer = Object.assign({}, this.UnChangedcustomer);
    this.viewFlag = !this.viewFlag;
  }

  onCancel(): void {
    this.customer = {
      Id: 0,
      Name: "",
      Email: "",
      Address: "",
      Company: "",
      Contact: "",
      State: "",
      City: "",
      GSTNo: ""
    };
  }
  getCustomers(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    };
    this._customerRegistrationService.getAllCustomer(element).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.CustomerTableData = result.result;
        this.matTableConfig(this.CustomerTableData);
        this.SetCustomerData = this.CustomerTableData;
        console.log(this.CustomerTableData);
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

  searchId(searchValue: any) {
    debugger;
    searchValue = searchValue.trim();
    searchValue = searchValue.toLocaleLowerCase();
    this.FilterCustomerTableData = this.SetCustomerData.filter(
      data => data.Id.toString().toLocaleLowerCase().startsWith(
        searchValue.toLocaleLowerCase()
      )
    );
    this.CustomerTableData = this.FilterCustomerTableData;
    this.matTableConfig(this.CustomerTableData);
  }

  searchName(searchValue: any) {
    debugger;
    searchValue = searchValue.trim();
    searchValue = searchValue.toLocaleLowerCase();
    this.FilterCustomerTableData = this.SetCustomerData.filter(
      data => data.Name.toLocaleLowerCase().startsWith(
        searchValue.toLocaleLowerCase()
      )
    );
    this.CustomerTableData = this.FilterCustomerTableData;
    this.matTableConfig(this.CustomerTableData);
  }

  searchContact(searchValue: any) {
    debugger;
    searchValue = searchValue.trim();
    searchValue = searchValue.toLocaleLowerCase();
    this.FilterCustomerTableData = this.SetCustomerData.filter(
      data => data.ContactNo.toLocaleLowerCase().startsWith(
        searchValue.toLocaleLowerCase()
      )
    );
    this.CustomerTableData = this.FilterCustomerTableData;
    this.matTableConfig(this.CustomerTableData);
  }
  searchEmail(searchValue: any) {
    debugger;
    searchValue = searchValue.trim();
    searchValue = searchValue.toLocaleLowerCase();
    this.FilterCustomerTableData = this.SetCustomerData.filter(
      data => data.Email.toLocaleLowerCase().startsWith(
        searchValue.toLocaleLowerCase()
      )
    );
    this.CustomerTableData = this.FilterCustomerTableData;
    this.matTableConfig(this.CustomerTableData);
  }
  searchCompany(searchValue: any) {
    debugger;
    searchValue = searchValue.trim();
    searchValue = searchValue.toLocaleLowerCase();
    this.FilterCustomerTableData = this.SetCustomerData.filter(
      data => data.CompanyName.toLocaleLowerCase().startsWith(
        searchValue.toLocaleLowerCase()
      )
    );
    this.CustomerTableData = this.FilterCustomerTableData;
    this.matTableConfig(this.CustomerTableData);
  }
  searchGST(searchValue: any) {
    debugger;
    searchValue = searchValue.trim();
    searchValue = searchValue.toLocaleLowerCase();
    this.FilterCustomerTableData = this.SetCustomerData.filter(
      data => data.GSTNo.toString().toLocaleLowerCase().startsWith(
        searchValue.toLocaleLowerCase()
      )
    );
    this.CustomerTableData = this.FilterCustomerTableData;
    this.matTableConfig(this.CustomerTableData);
  }
  matTableConfig(tableRecords: any): void {
    this.dataSource = new MatTableDataSource(tableRecords);
    this.dataSource.paginator = this.tablePaginator;
  }
  getAllCustomers(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    };
    this._customerRegistrationService.getAllSuccessCustomer(element).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.CustomerData = result;
        console.log('this.CustomerData', this.CustomerData);
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
  getAllCompany(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    };
    debugger;
    this._customerRegistrationService.getCompany(element).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.CompanyData = result;
        console.log(this.CompanyData);

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
  getAllState(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    };
    this._customerRegistrationService.getState(element).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.StateData = result;
        console.log(this.StateData);
        this.getAllCity();
        this.CityData = [];
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
  removeCustomerDetail(element): void {
    let deleteElement = {
      Id: element.Id,
      Active: element.Active,
      ActionBy: localStorage.getItem('userID')
    }
    this._customerRegistrationService.removeCustomer(deleteElement).subscribe(
      (result: any) => {
        if (result.result == true) {
          this.toastr.error("Remove Successfully");
          this.getCustomers();
        }
      },
      error => {
        if (error.status === 401) { this.toastr.error("Unauthorized"); }
        else { this.toastr.error("Something went wrong! Try Again"); }
      }
    );
  }

  getAllCity(): void {
    // let element = {
    //   StateId: this.customer.State,
    // //  ActionBy: localStorage.getItem('userID')
    // };
    this._customerRegistrationService.getCity(this.customer.State).subscribe(
      (result: any) => {
        debugger;
        console.log(result);
        this.CityData = result;
        console.log(this.CityData);
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
