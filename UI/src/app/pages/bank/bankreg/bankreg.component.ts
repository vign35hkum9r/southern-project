
import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-bankreg',
  templateUrl: './bankreg.component.html',
  styleUrls: ['./bankreg.component.scss']
})

export class BankregComponent implements OnInit { 


   // Stepper overview
   isOptional = false; 
   firstFormGroup: FormGroup;
   secondFormGroup: FormGroup;
   ThirdFormGroup:FormGroup;
   FourFormGroup: FormGroup;
   // Stepper overview End
  account: boolean=false;
  accounts: boolean=true;
  model: any=[];
  bank = true;
  banks = false;
  selected = 'option2';
  isFormOpen : boolean=false;
  value=[];
  viewValue=[];
  
 
  constructor(private _formBuilder: FormBuilder) { }

  ngOnInit() {
    // Stepper overview
    this.firstFormGroup = this._formBuilder.group({
      Type_of_AccountCtrl: ['', Validators.required],
      Name_of_the_BankCtrl: ['', Validators.required],
      Name_of_the_ProjectCtrl: ['', Validators.required],
      Account_No: ['', Validators.required],
      Openning_Balance: ['', Validators.required],
      Previous_Year_Openning_Balance: ['', Validators.required],
      Currency: ['', Validators.required]      
    });
    this.secondFormGroup = this._formBuilder.group({
      Address1: ['', Validators.required],
      Address2: ['', Validators.required],
      Country: ['', Validators.required],
      Area: ['', Validators.required],
      CityDistrict: ['', Validators.required],
      State: ['', Validators.required],
      Pincode: ['', Validators.required]  ,  
      Email_Id: ['', Validators.required],
      Land_Line_Number: ['', Validators.required], 
      Branch_Code: ['', Validators.required] ,   
      IFSC_Code: ['', Validators.required],
      MIRC_Code: ['', Validators.required]    
    });
    this.ThirdFormGroup = this._formBuilder.group({
      Name_of_the_Person1: ['', Validators.required],      
      Designation: ['', Validators.required],
      cellno: ['', Validators.required]  ,  
      Email_Id: ['', Validators.required],
      Name_of_the_Person2: ['', Validators.required], 
      designation: ['', Validators.required] ,   
      CellNo: ['', Validators.required],
      emailId: ['', Validators.required]    
    });

    this.FourFormGroup = this._formBuilder.group({
      Enter_the_Name_of_the_Ledger: ['', Validators.required],      
      Classification_of_Account: ['', Validators.required],
      Starting_Code: ['', Validators.required]  ,  
      Ending_Code: ['', Validators.required],
      Enter_the_Accounting_Code: ['', Validators.required], 
      Group_Subgroup: ['', Validators.required] ,         
    });
    // Stepper overview End  
  }
  
  Bank() {
    this.bank = false;
    this.banks = true;

  }
  Account() {
    this.accounts = false;
    this.account = true;

  }
  cancel(){
    this.bank = true;
    this.banks = false;
  }
  Cancel(){
    this.accounts = true;
    this.account = false;
  }
   Food = [
    {value: 'steak-0', viewValue: 'Steak'},
    {value: 'pizza-1', viewValue: 'Pizza'},
    {value: 'tacos-2', viewValue: 'Tacos'}
  ];

foods(f){
  this.model.Food[f]=(this.value=this.viewValue)
  this.model.Food=this.foods[f].value
}
getProject(){
 
if(this.Food.length > 0)
  this.model.Food=this.model.value
}
 
  create(){
    this.isFormOpen = true;
  }
  clear(){
    this.isFormOpen = false;
  }

  
}




