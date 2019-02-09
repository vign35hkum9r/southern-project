import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Led_SubledService, } from '../../../service/Account/Led_Subled.service';
import { AccountCodeService } from '../../../service/Account/accountcode.service';
import { GroupService } from '../../../service/Account/group.service';
import { Response } from '@angular/http/src/static_response';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Validators, } from '@angular/forms';

import { ToastyService } from 'ng2-toasty';

@Component({
  selector: 'app-ledger-subledger',
  templateUrl: './ledger-subledger.component.html',
  styleUrls: ['./ledger-subledger.component.scss']
})

export class LedgerSubledgerComponent implements OnInit {
  // Stepper overview
  panelOpenState = false;
  isLinear = false;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  // Stepper overview End
  List: any;
  value = [];
  viewValue = [];
  selectedValue: string;
  editing: boolean = false;
  editing1: boolean = false;

  CreditorList: any = [
    { Id: 1, TypeOfCreditor: "Contractor" },
    { Id: 2, TypeOfCreditor: "Supplier" },
    { Id: 3, TypeOfCreditor: "Consultent" }];


  isFormOpen: boolean;
  model: any = {};
  model1: any = {};

  LedgerList: any = [];
  AccountCodeList = [];
  GroupList = [];
  NameList = [];

  constructor(public http: HttpClient, private Led_SubledService: Led_SubledService,
    private accountCodeService: AccountCodeService, private groupService: GroupService,
    private toastr: ToastyService, private _formBuilder: FormBuilder) { }
  ngOnInit() {
    debugger;
    this.Led_SubledService.getallLedger().subscribe((res: any) => {
      this.LedgerList = res;
      this.accountCodeService.getallAccountCode().subscribe((res: any) => {
        this.AccountCodeList = res
      })
    })
    this.groupService.getallGroup().subscribe((res: any) => {
      this.GroupList = res
    })

    // Stepper overview
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required]
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });// Stepper overview End

  }
  ledger: boolean = false;
  subledger: boolean = false;

  ledgers(checkTax) {
    if (checkTax.value == 1) {
      this.subledger = false;
      this.ledger = true;
    }
    else {
      this.subledger = true;
      this.ledger = false;
    }
  }

  getCode(code) {
    this.model.StartingCode = code.StartingCode
    this.model.EndingCode = code.EndingCode
    this.Led_SubledService.getLedgerCode(code.AccountCodeId).subscribe((res: any) => {
      this.model.LedgerCode = res.LedgerCode;
    });
  }

  create() {
    this.isFormOpen = true;
  }


  clear() {
    this.model = {};
    this.isFormOpen = false;
  }

  getName(Id) {
    this.NameList = [{ "Id": 1, "Name": "Ravi" }, { "Id": 2, "Name": "Sathish" },]
  }


  save(model) {
    debugger;
    var obj = {
      LedgerName: model.LedgerName,
      PrintLedgerName: model.PrintLedgerName,
      AccountCodeId: model.SelectedAccount.AccountCodeId,
      LedgerCode: model.LedgerCode,
      GroupId: model.SelectedGroup.GroupId,
      CreatedBy: 1004
    }
    this.Led_SubledService.createLedger(obj).subscribe((res: Response) => {
      this.clear();
    });
  }

  saveSubLedger(model1) {
    var obj = {
      TypeOfCreditor: model1.Select_the_Type_of_Creditors.Id,
      SubLedgerName: model1.SelectedType.Id,
      PrintSubLedgerName: model1.PrintSubLedgerName,
      SubLedgerCode: model1.SubLedgerCode,
      OpeningBalance: model1.OpeningBalance,
      PreYearOpeningBalance: model1.PreYearOpeningBalance
    }
    this.Led_SubledService.createSubLedger(obj).subscribe((res: Response) => {
      this.clear();
    });
  }
}
