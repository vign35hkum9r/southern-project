import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';
import { DatePipe } from '@angular/common';
import { ManpowerDetailService } from 'src/app/service/operation/manpower-detail.service';
import { configuration } from 'src/app/common/configuration/config';
import { ManpowerPersonalDetails, ManpowerVerificationDetails, ManpowerFamilyDetails, ManpowerBankDetails } from 'src/app/model/manpower-detail/manpower-detail.model';

@Component({
  selector: 'app-manpower-detail',
  templateUrl: './manpower-detail.component.html',
  styleUrls: ['./manpower-detail.component.css'],
  providers: [DatePipe]
})
export class ManpowerDetailComponent implements OnInit {

  viewFlag = true;
  isEditing = false;
  ProofCardNo: string = "";

  manpower: ManpowerPersonalDetails = {
    ManPowerId: 0,
    Name: "",
    Gender: "Male",
    DateofBirth: new Date(),
    Age: 0,
    Mobile: "",
    AlternateNumber: "",
    MaritalStatus: 0,
    CurrentAddress: "",
    PermanentAddress: "",
    Photo: "",
    State: "",
    City: "",
    JobType: "",
    Company: "",
    DateofJoin: "",
    Designation: "",
    ReferenceBy: "",
    PreviousCompany: "",
    ReferenceContact1: "",
    ReferenceContact2: "",
    TotalExperience: 0,
    VerificationStatus: 0,
    FatherName: "",
    MotherName: "",
    Payment: "",
    BloodGroup: "",
    CreatedBy: localStorage.getItem('userID'),
    ModifiedBy: localStorage.getItem('userID'),
    Active: 1,
  }

  manpowerVerification: ManpowerVerificationDetails = {
    Id: 0,
    ManPowerId: 0,
    ProofId: 0,
    ProofCardNo: "",
    ProofUrl: "",
    CreatedBy: localStorage.getItem('userID'),
  }

  manpowerFamily: ManpowerFamilyDetails = {
    Id: 0,
    ManPowerId: 0,
    MemberName: "",
    Relationship: "",
    Age: "",
    NomineeStatus: "",
    CreatedBy: localStorage.getItem('userID'),
  }

  manpowerBank: ManpowerBankDetails = {
    Id: 0,
    ManPowerId: 0,
    AccountType: 0,
    IFSCCode: "",
    BankId: {},
    AccountNumber: "",
    PassbookUrl: "",
    Active: "1",
    CreatedBy: localStorage.getItem('userID'),
  }
  bloodGroupData = [{ Name: 'A+' }, { Name: 'A-' }, { Name: 'B+' }, { Name: 'B-' }, { Name: 'O+' }, { Name: 'O-' }, { Name: 'AB+' }, { Name: 'AB-' }]

  displayedColumns: string[] = [
    'id',
    'name',
    'gender',
    'contact',
    'company',
    'designation',
    'state',
    'city',
    'photo',
    'status',
    'action'
  ];
  manpowerData: any = [];
  dataSource = new MatTableDataSource<any>(this.manpowerData);
  @ViewChild(MatPaginator) paginator: MatPaginator;
  manpowerPhoto: any;
  photoFlag = false;
  verificationFileFlag = false;
  companyData: any[] = [];
  // bloodGroupData: any[] = [];
  cityData: any[] = [];
  designationData: any[] = [];
  stateData: any[] = [];
  paymentData: any[] = [];
  API_URL: string;
  proofData: any[] = [];
  filteredProof: any[] = [];
  bankData: any[] = [];
  accountTypeData: any[] = [];
  familyDetailsData: any[] = [];
  bankDetailsData: any[] = [];
  verficationData: any[] = [];
  filteredBank: any[] = [];
  bankFileFlag = false;


  constructor(private _manpowerDetailService: ManpowerDetailService,
    private _datePipe: DatePipe, ) {
    this.photoFlag = false;
    this.API_URL = configuration.url;;
  }

  ngOnInit() {
    this.dataSource.paginator = this.paginator;
    this.getAllManpowerDetails();
    this.getCompany();
    this.getState();
    this.getPayment();
    // this.getDesignation();
  }

  onSearch() {
    let obj = {
      ProofCardNo: this.ProofCardNo,
      ActionBy: localStorage.getItem('userID'),
    }
    this._manpowerDetailService.searchManpower(obj).subscribe(
      (result: any) => {
        debugger;
        if (result.result) {
          this.verficationData = result.result.ProofDetails;
          this.familyDetailsData = result.result.FamilyDetails;
        }
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  onNewClick(): void {
    this.onClear();
    this.viewFlag = !this.viewFlag;
    this.isEditing = false;
  }

  onListClick(): void {
    this.viewFlag = !this.viewFlag;
    this.isEditing = false;
  }

  addManpowerPersonalDetails(): void {

    const formData = new FormData()
    {
      //  formData.append("BloodGroup", (this.manpower.BloodGroup == "") ? "": this.manpower.BloodGroup);
      if (!this.isEditing) {
        if (this.manpower.Photo != undefined && this.manpower.Photo != '' && this.photoFlag == true) {
          formData.append("Name", this.manpower.Name);
          formData.append("Gender", this.manpower.Gender.toString());
          formData.append("DateofBirth", this._datePipe.transform(this.manpower.DateofBirth.toString(), 'yyyy-MM-dd'));
          formData.append("Age", this.manpower.Age.toString());
          formData.append("Mobile", (this.manpower.Mobile == "") ? "" : this.manpower.Mobile);
          formData.append("AlternateNumber", (this.manpower.AlternateNumber == "") ? "" : this.manpower.AlternateNumber);
          formData.append("MaritalStatus", this.manpower.MaritalStatus.toString());
          formData.append("CurrentAddress", (this.manpower.CurrentAddress == "") ? "" : this.manpower.CurrentAddress);
          formData.append("PermanentAddress", (this.manpower.PermanentAddress == "") ? "" : this.manpower.PermanentAddress);
          this.photoFlag ?
            (formData.append("Photo", (this.manpower.Photo == "") ? "" : this.manpower.Photo)) :
            (formData.append("Photo", (this.manpower.Photo == "") ? "" : this.manpower.Photo));
          formData.append('State', this.manpower.State);
          formData.append('City', this.manpower.City);
          formData.append("JobType", (this.manpower.JobType == "") ? "" : this.manpower.JobType);
          formData.append("Company", this.manpower.Company);
          formData.append("DateofJoin", this._datePipe.transform(this.manpower.DateofJoin.toString(), 'yyyy-MM-dd'));
          formData.append("Designation", this.manpower.Designation);
          formData.append("ReferenceBy", this.manpower.ReferenceBy);
          formData.append("PreviousCompany", (this.manpower.PreviousCompany == "") ? "" : this.manpower.PreviousCompany);
          formData.append("ReferenceContact1", (this.manpower.ReferenceContact1 == "") ? "" : this.manpower.ReferenceContact1);
          formData.append("ReferenceContact2", (this.manpower.ReferenceContact2 == "") ? "" : this.manpower.ReferenceContact2);
          formData.append("TotalExperience", this.manpower.TotalExperience.toString());
          formData.append("VerificationStatus", this.manpower.VerificationStatus.toString());
          formData.append("FatherName", this.manpower.FatherName);
          formData.append("MotherName", this.manpower.MotherName);
          formData.append("Payment", this.manpower.Payment);
          formData.append("CreatedBy", this.manpower.CreatedBy);
          this._manpowerDetailService.addManpowerPersonalWithPhoto(formData).subscribe(
            (result: any) => {
              if (result === true) {
                alert("Successfully added");
                this.onNewClick();
                this.ngOnInit();
              }
            },
            error => {
              if (error.status === 401) { alert("Unauthorized"); }
              else { alert("Something went wrong! Try Again"); }
            }
          );
        } else {
          this.manpower.DateofBirth = new Date(this._datePipe.transform(this.manpower.DateofBirth, 'yyyy-MM-dd'));
          this.manpower.DateofJoin = this._datePipe.transform(this.manpower.DateofJoin, 'yyyy-MM-dd');
          this._manpowerDetailService.addManpowerPersonal(this.manpower).subscribe(
            (result: any) => {

              if (result === true) {
                alert("Successfully added");
                this.onNewClick();
                this.ngOnInit();
              }
            },
            error => {
              if (error.status === 401) { alert("Unauthorized"); }
              else { alert("Something went wrong! Try Again"); }
            }
          );
        }
      } else {
        if (this.manpower.Photo != undefined && this.manpower.Photo != '' && this.photoFlag == true) {
          formData.append("Name", this.manpower.Name);
          formData.append("Gender", this.manpower.Gender.toString());
          formData.append("DateofBirth", this._datePipe.transform(this.manpower.DateofBirth.toString(), 'yyyy-MM-dd'));
          formData.append("Age", this.manpower.Age.toString());
          formData.append("Mobile", (this.manpower.Mobile == "") ? "" : this.manpower.Mobile);
          formData.append("AlternateNumber", (this.manpower.AlternateNumber == "") ? "" : this.manpower.AlternateNumber);
          formData.append("MaritalStatus", this.manpower.MaritalStatus.toString());
          formData.append("CurrentAddress", (this.manpower.CurrentAddress == "") ? "" : this.manpower.CurrentAddress);
          formData.append("PermanentAddress", (this.manpower.PermanentAddress == "") ? "" : this.manpower.PermanentAddress);
          this.photoFlag ?
            (formData.append("Photo", (this.manpower.Photo == "") ? "" : this.manpower.Photo)) :
            (formData.append("Photo", (this.manpower.Photo == "") ? "" : this.manpower.Photo));
          formData.append('State', this.manpower.State);
          formData.append('City', this.manpower.City);
          formData.append("JobType", (this.manpower.JobType == "") ? "" : this.manpower.JobType);
          formData.append("Company", this.manpower.Company);
          formData.append("DateofJoin", this._datePipe.transform(this.manpower.DateofJoin.toString(), 'yyyy-MM-dd'));
          formData.append("Designation", this.manpower.Designation);
          formData.append("ReferenceBy", this.manpower.ReferenceBy);
          formData.append("PreviousCompany", (this.manpower.PreviousCompany == "") ? "" : this.manpower.PreviousCompany);
          formData.append("ReferenceContact1", (this.manpower.ReferenceContact1 == "") ? "" : this.manpower.ReferenceContact1);
          formData.append("ReferenceContact2", (this.manpower.ReferenceContact2 == "") ? "" : this.manpower.ReferenceContact2);
          formData.append("TotalExperience", this.manpower.TotalExperience.toString());
          formData.append("VerificationStatus", this.manpower.VerificationStatus.toString());
          formData.append("FatherName", this.manpower.FatherName);
          formData.append("MotherName", this.manpower.MotherName);
          formData.append("Payment", this.manpower.Payment);
          formData.append("CreatedBy", this.manpower.CreatedBy);
          formData.append("Active", this.manpower.Active.toString());
          formData.append("ManPowerId", this.manpower.ManPowerId.toString());
          this._manpowerDetailService.modifyManpowerPersonalWithPhoto(formData).subscribe(
            (result: any) => {
              debugger;
              if (result.result === true) {
                alert("Successfully modified");
                this.onNewClick();
                this.ngOnInit();
              }
            },
            error => {
              if (error.status === 401) { alert("Unauthorized"); }
              else { alert("Something went wrong! Try Again"); }
            }
          );
        } else {
          this.manpower.DateofBirth = new Date(this._datePipe.transform(this.manpower.DateofBirth, 'yyyy-MM-dd'));
          this.manpower.DateofJoin = this._datePipe.transform(this.manpower.DateofJoin, 'yyyy-MM-dd');
          this.manpower.ModifiedBy = localStorage.getItem('userID');
          this._manpowerDetailService.modifyManpowerPersonal(this.manpower).subscribe(
            (result: any) => {
              debugger;
              if (result.result === true) {
                alert("Successfully modified");
                this.onNewClick();
                this.ngOnInit();
              }
            },
            error => {
              if (error.status === 401) { alert("Unauthorized"); }
              else { alert("Something went wrong! Try Again"); }
            }
          );
        }
      }
    }
  }

  uploadImage(event) {

    const fileList = event.target.files;
    if (fileList && event.target.files[0]) {
      this.manpower.Photo = fileList[0];
      this.photoFlag = true;
    }
  }

  setCurrentAddress() {
    this.manpower.PermanentAddress = this.manpower.CurrentAddress
  }

  editManpowerDetails(modifyManpower): void {
    debugger;
    this.manpower = modifyManpower;
    this.manpower.MaritalStatus = Number(modifyManpower.MaritalStatus);
    this.cityData = [{
      CityId: modifyManpower.City,
      CityName: modifyManpower.CityName,
    }];
    this.designationData = [{
      DesignationId: modifyManpower.Designation,
      DesignationName: modifyManpower.DesignationName,
    }];
    this.getCompany();
    this.getState();
    this.getPayment();
    this.getDesignation();
    this.getCity();
    this.manpowerVerification = {
      Id: 0,
      ManPowerId: 0,
      ProofId: 0,
      ProofCardNo: "",
      ProofUrl: "",
      CreatedBy: localStorage.getItem('userID'),
    };
    this.manpowerFamily = {
      Id: 0,
      ManPowerId: 0,
      MemberName: "",
      Relationship: "",
      Age: "",
      NomineeStatus: "",
      CreatedBy: localStorage.getItem('userID'),
    };
    this.manpowerBank = {
      Id: 0,
      ManPowerId: 0,
      AccountType: 0,
      IFSCCode: "",
      BankId: 0,
      AccountNumber: "",
      PassbookUrl: "",
      Active: "",
      CreatedBy: "",
    }
    this.viewFlag = !this.viewFlag;
    this.isEditing = true;
    this.getAllBank();
    // this.getAllAccountType();
    this.getProofMaster();
    this.getManpowerVerification();
    this.getFamilyDetails();
    this.getAllBankDetails();
  }

  addManpowerVerificationDetails(): void {

    const formData = new FormData()
    {
      if (this.isEditing && this.verificationFileFlag) {
        debugger;
        formData.append("ManPowerId", this.manpower.ManPowerId.toString());
        formData.append("ProofId", this.manpowerVerification.ProofId.toString());
        formData.append("ProofCardNo", this.manpowerVerification.ProofCardNo);
        formData.append("CreatedBy", this.manpower.CreatedBy);
        this.verificationFileFlag ?
          (formData.append("Photo", (this.manpowerVerification.ProofUrl == "") ? "" : this.manpowerVerification.ProofUrl)) :
          (formData.append("Photo", (this.manpowerVerification.ProofUrl == "") ? "" : this.manpowerVerification.ProofUrl));
        this._manpowerDetailService.addManpowerVerificationWithProofUrl(formData).subscribe(
          (result: any) => {
            debugger;
            if (result.result === true) {
              this.getManpowerVerification();
              this.manpowerVerification = {
                Id: 0,
                ManPowerId: 0,
                ProofId: 0,
                ProofCardNo: "",
                ProofUrl: "",
                CreatedBy: localStorage.getItem('userID'),
              }
              alert("Successfully added");
            }
          },
          error => {
            if (error.status === 401) { alert("Unauthorized"); }
            else { alert("Something went wrong! Try Again"); }
          }
        );
      } else if (this.isEditing) {
        let element = {
          ManpowerId: this.manpower.ManPowerId,
          ProofId: this.manpowerVerification.ProofId,
          ProofCardNo: this.manpowerVerification.ProofCardNo,
          ProofUrl: this.manpowerVerification.ProofUrl == "" || this.manpowerVerification.ProofUrl == undefined ? "" : this.manpowerVerification.ProofUrl,
          CreatedBy: this.manpower.CreatedBy
        }
        this._manpowerDetailService.addManpowerVerification(element).subscribe(
          (result: any) => {
            debugger;
            if (result.result === true) {
              this.getManpowerVerification();
              alert("Successfully added");
            }
          },
          error => {
            if (error.status === 401) { alert("Unauthorized"); }
            else { alert("Something went wrong! Try Again"); }
          }
        );
      }
    }
  }

  getManpowerVerification(): void {
    let element = {
      ManpowerId: this.manpower.ManPowerId,
      ActionBy: localStorage.getItem('userID')
    }
    this._manpowerDetailService.getManpowerVerification(element).subscribe(
      (result: any) => {
        debugger;
        this.verficationData = result.result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  removeVerificationDetail(verify: any): void {
    debugger;
    let element = {
      Id: verify.Id,
      ProofUrl: verify.ProofUrl,
      ActionBy: localStorage.getItem('userID')
    }
    this._manpowerDetailService.removeVerification(element).subscribe(
      (result: any) => {
        debugger;
        if (result.result) {
          this.getManpowerVerification();
        }

      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  uploadVerificationFile(event) {

    const fileList = event.target.files;
    if (fileList && event.target.files[0]) {
      this.manpowerVerification.ProofUrl = fileList[0];
      this.verificationFileFlag = true;
    }
  }

  addManpowerFamilyDetails(): void {
    debugger;
    if (this.isEditing) {
      this.manpowerFamily.ManPowerId = this.manpower.ManPowerId;
      this._manpowerDetailService.addManpowerFamily(this.manpowerFamily).subscribe(
        (result: any) => {
          debugger;
          if (result.result === true) {
            this.getFamilyDetails();
            this.manpowerFamily = {
              Id: 0,
              ManPowerId: 0,
              MemberName: "",
              Relationship: "",
              Age: "",
              NomineeStatus: "",
              CreatedBy: localStorage.getItem('userID'),
            }
            alert("Successfully added");
          }
        },
        error => {
          if (error.status === 401) { alert("Unauthorized"); }
          else { alert("Something went wrong! Try Again"); }
        }
      );
    }
  }

  getFamilyDetails(): void {
    let element = {
      ManPowerId: this.manpower.ManPowerId,
      ActionBy: localStorage.getItem('userID')
    }
    this._manpowerDetailService.getFamilyDetails(element).subscribe(
      (result: any) => {
        debugger;
        this.familyDetailsData = result.result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  removeFamilyDetail(family: any): void {
    debugger;
    let element = {
      Id: family.Id,
      ManPowerId: family.ManpowerId,
      ActionBy: localStorage.getItem('userID')
    };
    this._manpowerDetailService.removeFamily(element).subscribe(
      (result: any) => {
        if (result.result === true) {
          this.getFamilyDetails();
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

  addManpowerBankDetails(): void {
    debugger;
    const formData = new FormData()
    {
      formData.append("ManPowerId", this.manpower.ManPowerId.toString());
      formData.append("BankId", this.manpowerBank.BankId.toString());
      formData.append("AccountType", this.manpowerBank.AccountType.toString());
      formData.append("AccountNumber", this.manpowerBank.AccountNumber);
      formData.append("IFSCCode", this.manpowerBank.IFSCCode);
      formData.append("CreatedBy", this.manpowerBank.CreatedBy);
      this.bankFileFlag ?
        (formData.append("Photo", (this.manpowerBank.PassbookUrl == "") ? "" : this.manpowerBank.PassbookUrl)) :
        (formData.append("Photo", (this.manpowerBank.PassbookUrl == "") ? "" : this.manpowerBank.PassbookUrl));
      this._manpowerDetailService.addManpowerBank(formData).subscribe(
        (result: any) => {
          if (result.result === true) {
            this.getAllBankDetails();
            this.manpowerBank = {
              Id: 0,
              ManPowerId: 0,
              AccountType: 0,
              IFSCCode: "",
              BankId: 0,
              AccountNumber: "",
              PassbookUrl: "",
              Active: "",
              CreatedBy: localStorage.getItem('userID'),
            }
            alert("Successfully added");
          }
        },
        error => {
          if (error.status === 401) { alert("Unauthorized"); }
          else { alert("Something went wrong! Try Again"); }
        }
      );
    }
  }

  getAllBankDetails(): void {
    let element = {
      ManPowerId: this.manpower.ManPowerId,
      // ActionBy: localStorage.getItem('userID')
    }
    this._manpowerDetailService.getAllBankDetails(element).subscribe(
      (result: any) => {
        debugger;
        this.bankDetailsData = result.result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  removeBankDetail(bank: any): void {
    var element = {
      Id: bank.ManpowerBankDetailId,
      PassbookUrl: bank.PassbookUrl,
      ActionBy: localStorage.getItem('userID')
    }
    this._manpowerDetailService.removeBank(element).subscribe(
      (result: any) => {
        const manpowerData = result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  uploadBankFile(event) {
    debugger;
    const fileList = event.target.files;
    if (fileList && event.target.files[0]) {
      this.manpowerBank.PassbookUrl = fileList[0];
      this.bankFileFlag = true;
    }
  }

  getAllManpowerDetails(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    }
    this._manpowerDetailService.getAllManpowerDetails(element).subscribe(
      (result: any) => {

        this.manpowerData = result.result;
        this.dataSource = this.manpowerData;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getCompany(): void {
    // let element = {
    //   ActionBy: localStorage.getItem('userID')
    // }
    this._manpowerDetailService.getCompany().subscribe(
      (result: any) => {
        this.companyData = result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getBloodGroup(): void {
    this._manpowerDetailService.getBloodGroupMaster().subscribe(
      (result: any) => {
        this.bloodGroupData = result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getCity(): void {
    // let element = {
    //   State: this.manpower.State,
    //   ActionBy: localStorage.getItem('userID')
    // }
    this._manpowerDetailService.getCityMaster(this.manpower.State).subscribe(
      (result: any) => {
        this.cityData = result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getDesignation(): void {
    // let element = {
    //   ActionBy: this.manpower.Company
    // }
    this._manpowerDetailService.getDesignation(this.manpower.Company).subscribe(
      (result: any) => {

        this.designationData = result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getState(): void {
    // let element = {
    //   ActionBy: localStorage.getItem('userID')
    // }
    this._manpowerDetailService.getStateMaster().subscribe(
      (result: any) => {
        this.stateData = result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getPayment(): void {
    this._manpowerDetailService.getPayment().subscribe(
      (result: any) => {

        this.paymentData = result.result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  getProofMaster(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    }
    this._manpowerDetailService.getProofMaster(element).subscribe(
      (result: any) => {
        debugger;
        this.proofData = result.result;
        this.filteredProof = this.proofData;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  filterProof(ProofName: string) {
    this.filteredProof = this.proofData.filter(proofName =>
      proofName.ProofName.toLowerCase().startsWith(
        ProofName.trim().toLowerCase()
      )
    );
  }

  getAllBank(): void {
    let element = {
      ActionBy: localStorage.getItem('userID')
    }
    this._manpowerDetailService.getAllBank(element).subscribe(
      (result: any) => {
        debugger;
        this.bankData = result.result;
        this.filteredBank = this.bankData;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  // filterBank(bankId: any) {
  //   
  //   this.filteredBank = this.bankData.filter(bankId =>
  //     bankId.BankName.toLowerCase().startsWith(
  //       bankId.BankName.trim().toLowerCase()
  //     )
  //   );
  // }

  getAllAccountType(): void {
    debugger;
    // let element = {
    //   AccountTypeMasterId: this.manpowerBank.BankId,
    //   AccountTypeName: this.manpowerBank.BankId
    // }
    this._manpowerDetailService.getAllAccountType().subscribe(
      (result: any) => {
        debugger;
        this.accountTypeData = result.result;
      },
      error => {
        if (error.status === 401) { alert("Unauthorized"); }
        else { alert("Something went wrong! Try Again"); }
      }
    );
  }

  onClear(): void {
    this.manpower = {
      ManPowerId: 0,
      Name: "",
      Gender: "",
      DateofBirth: new Date(),
      Age: 0,
      Mobile: "",
      AlternateNumber: "",
      MaritalStatus: 0,
      CurrentAddress: "",
      PermanentAddress: "",
      Photo: "",
      State: "",
      City: "",
      JobType: "",
      Company: "",
      DateofJoin: "",
      Designation: "",
      ReferenceBy: "",
      PreviousCompany: "",
      ReferenceContact1: "",
      ReferenceContact2: "",
      TotalExperience: 0,
      VerificationStatus: 0,
      FatherName: "",
      MotherName: "",
      Payment: "",
      BloodGroup: "",
      CreatedBy: localStorage.getItem('userID'),
      ModifiedBy: localStorage.getItem('userID'),
      Active: 1,
    }

    this.manpowerVerification = {
      Id: 0,
      ManPowerId: 0,
      ProofId: 0,
      ProofCardNo: "",
      ProofUrl: "",
      CreatedBy: localStorage.getItem('userID'),
    }

    this.manpowerFamily = {
      Id: 0,
      ManPowerId: 0,
      MemberName: "",
      Relationship: "",
      Age: "",
      NomineeStatus: "",
      CreatedBy: localStorage.getItem('userID'),
    }

    this.manpowerBank = {
      Id: 0,
      ManPowerId: 0,
      AccountType: 0,
      IFSCCode: "",
      BankId: 0,
      AccountNumber: "",
      PassbookUrl: "",
      Active: "",
      CreatedBy: localStorage.getItem('userID'),
    }
    this.isEditing = false;
  }
}