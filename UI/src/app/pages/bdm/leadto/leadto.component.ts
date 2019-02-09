import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';
import { ToastData, ToastOptions, ToastyService } from 'ng2-toasty';
import { LeadToService } from '../../../service/bdm/leadto.service';

@Component({
  selector: 'app-leadto',
  templateUrl: './leadto.component.html',
  styleUrls: ['./leadto.component.css',
    '../../../../../node_modules/ng2-toasty/style-bootstrap.css',
    '../../../../../node_modules/ng2-toasty/style-default.css',
    '../../../../../node_modules/ng2-toasty/style-material.css'],
  encapsulation: ViewEncapsulation.None
})
export class LeadtoComponent implements OnInit {

  constructor(private toastr: ToastyService, private leadtoService: LeadToService) { }
  position = 'top-right';
  theme = 'bootstrap';
  type = 'default';
  ServiceList: any = [];
  OldLeadList: any = [];
  NewLeadList: any = [];
  ClientList: any = [];
  model: any = {};

  ngOnInit() {

    var objGetServiceDTO = {
      ActionBy: 1001
    }
    this.leadtoService.getService(objGetServiceDTO).subscribe(res => {
      this.ServiceList = res.result;
    })
  }

  getOldLeadList() {
    var objGetOldLeadDTO = {
      Id: this.model.selectedService.Id,
      ActionBy: 1001
    }
    this.leadtoService.getOldLeadList(objGetOldLeadDTO).subscribe(res => {
      this.OldLeadList = res.result;
    })
  }

  getNewLeadList() {
    var objGetNewLeadDTO = {
      State: this.model.selectedOldEmployee.StateId,
      OldLead: this.model.selectedOldEmployee.EmployeeId,
      ActionBy: 1001
    }
    this.leadtoService.getNewLeadList(objGetNewLeadDTO).subscribe(res => {
      this.NewLeadList = res.result;
      var objEmpDTO = {
        EmployeeId: this.model.selectedOldEmployee.EmployeeId
      }
      this.leadtoService.getClientByEmpId(objEmpDTO).subscribe(res => {
        this.ClientList = res.result;
      })
    })
  }

  saveClientLeadDetail() {
    var objChangeClientLead: any = {
      EmployeeId: this.model.selectedNewEmployee.EmployeeId,
      ActionBy: 1001
    }
    var ClientId = [];
    for (var i in this.ClientList) {
      if (this.ClientList.ClientList[i].hasPermission) {
        ClientId.push(this.ClientList[i].ClientId);
      }
    }
    objChangeClientLead.ClientId = ClientId;
    this.leadtoService.saveChangeLead(objChangeClientLead).subscribe((res: any) => {
      // alert("Insert sucessful")
      debugger;
      this.toastr.success("Added successfully")
      this.getNewLeadList();
    });
  }
}
