import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
@Component({
  selector: 'app-raise-draft-indent',
  templateUrl: './raise-draft-indent.component.html',
  styleUrls: ['./raise-draft-indent.component.scss']
})

export class RaiseDraftIndentComponent implements OnInit {
  isFormOpen: boolean;
 
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

