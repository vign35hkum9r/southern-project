import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-tds',
  templateUrl: './tds.component.html',
  styleUrls: ['./tds.component.scss']
})
export class TdsComponent implements OnInit {
  checkTax: boolean;   
  account: boolean=false;
  accounts: boolean=true;
  model: any=[];
  bank = true;
  banks = false;
  selected = 'option2';
  isFormOpen : boolean=false;
  value=[];
  viewValue=[];
  isChecked:boolean = false;
  constructor() { }

  ngOnInit() {
 
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
  istax = false;
  tax(checkTax) {
    debugger;
    this.isChecked = !this.isChecked;   
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

