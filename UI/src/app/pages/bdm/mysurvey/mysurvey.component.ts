import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-mysurvey',
  templateUrl: './mysurvey.component.html',
  styleUrls: ['./mysurvey.component.css']
})
export class MysurveyComponent implements OnInit {

  isFormOpen: boolean = false;
  isEditing: boolean = false;
  checkEditing: boolean = false;
  AppoinmentDetail: any = {};
  requirement: any = {};
  existingRequirement : any ={};
  constructor() { }

  ngOnInit() {
  }


  addBdmAppointment() {
    this.isFormOpen = true;
    this.isEditing = false;
  }

  Cancel() {
    this.isFormOpen = false;
    this.isEditing = false;
  }

}
