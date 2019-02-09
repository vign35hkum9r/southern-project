import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-ledger-library',
  templateUrl: './ledger-library.component.html',
  styleUrls: ['./ledger-library.component.scss']
})
export class LedgerLibraryComponent implements OnInit {
isFormOpen : boolean

  constructor() { }

  ngOnInit() {
    this.isFormOpen = false;
  }
  create(){
    this.isFormOpen = true;
  }
  clear(){
    this.isFormOpen = false;
  }
}


