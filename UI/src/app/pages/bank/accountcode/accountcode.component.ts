import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';
import { ToastData, ToastOptions, ToastyService } from 'ng2-toasty';
import { AccountCodeService } from '../../../service/Account/accountcode.service';

@Component({
  selector: 'app-accountcode',
  templateUrl: './accountcode.component.html',
  styleUrls: ['./accountcode.component.scss',
    '../../../../../node_modules/ng2-toasty/style-bootstrap.css',
    '../../../../../node_modules/ng2-toasty/style-default.css',
    '../../../../../node_modules/ng2-toasty/style-material.css'],
  encapsulation: ViewEncapsulation.None
})
export class AccountcodeComponent implements OnInit {
  title: string;
  msg: string;
  showClose = true;
  isEditing: boolean = false;
  position = 'top-right';
  theme = 'bootstrap';
  type = 'default';
  closeOther = false;
  isFormOpen: boolean = false;
  isDisabled = true;
  value = false;
  model: any = [];
  isChange: boolean = false;
  AccountCodeList: any = [];
  displayedColumns: any[] = ['position', 'Classification of Account', 'Alpha Code', 'Starting Code', 'Ending Code'];
  dataSource = new MatTableDataSource<PeriodicElement>(ELEMENT_DATA);
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(private toastr: ToastyService, private accountCodeService: AccountCodeService) {

  }

  ngOnInit() {
    this.accountCodeService.getallAccountCode().subscribe(res => {
      this.AccountCodeList = res
      if (this.AccountCodeList.length > 0) {
        this.model.digits = this.AccountCodeList[0].Digits
        this.model.num = this.AccountCodeList[0].TypeOfCode
      }
      if (this.AccountCodeList[0].IsAllocate == 1) {
        this.isChange = true;
      }
      else
        this.isChange = false;
    })
    // this.model.num = 'Anumeric'
  }
  istax = false;

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.AccountCodeList.filter = filterValue;
  }


  StartingCode(row, index) {
    debugger;
    for (var i in this.AccountCodeList) {
      if (row.StartingCode != null && i != index) {
        if (this.AccountCodeList[i].StartingCode != null && this.AccountCodeList[i].EndingCode != null) {
          if (parseInt(this.AccountCodeList[i].StartingCode) >= parseInt(row.StartingCode) || parseInt(row.StartingCode) <=
            parseInt(this.AccountCodeList[i].EndingCode)) {
            this.toastr.info("already Exist")
            row.StartingCode = null;
            return
          }
          else {

          }
        }
        else {
          this.AccountCodeList[i].StartingCode = null
          this.AccountCodeList[i].EndingCode = null
        }
      }
    }
  }

  checkCode(row, index) {
    for (var i in this.AccountCodeList) {
      if (row.Code.toLowerCase() != "" || this.AccountCodeList[i].Code.toLowerCase() != "") {
        if (this.AccountCodeList[i].Code.toLowerCase() == row.Code.toLowerCase() && i != index) {
          this.toastr.info("Already Exist")
          row.Code = "";
        }
      }
    }
    row.Code = row.Code.toUpperCase();
  }

  keyPress(event: any) {
    const pattern = /[0-9\+\-\ ]/;

    let inputChar = String.fromCharCode(event.charCode);
    if (event.keyCode != 8 && !pattern.test(inputChar)) {
      event.preventDefault();
    }
  }

  keyPress1(event: any) {
    const pattern = /[a-zA-Z\+\-\ ]/;

    let inputChar = String.fromCharCode(event.charCode);
    if (event.keyCode != 8 && !pattern.test(inputChar)) {
      event.preventDefault();
    }
  }

  Save(model) {
    debugger;

    for (var i in this.AccountCodeList) {
      this.AccountCodeList[i].StartingCode = parseInt(this.AccountCodeList[i].StartingCode)
      this.AccountCodeList[i].EndingCode = parseInt(this.AccountCodeList[i].EndingCode)
      this.AccountCodeList[i].Digits = parseInt(model.digits)
      this.AccountCodeList[i].Code = ((this.model.num == 'Anumeric') ? this.AccountCodeList[i].Code : null)
      this.AccountCodeList[i].TypeOfCode = this.model.num
    }
    var obj = {
      AccountCode: JSON.stringify(this.AccountCodeList)
    }

    this.accountCodeService.createAccountCode(obj).subscribe((res: any) => {
      // alert("Insert sucessful")
      debugger;
      this.toastr.success("Added successfully")

    });


  }


  create() {
    this.isFormOpen = true;
    this.isEditing = false;
  }
  clear() {
    this.isFormOpen = false;
    this.isEditing = false;
    this.ngOnInit();
  }


  addToast(options) {
    if (options.closeOther) {
      this.toastr.clearAll();
    }
    this.position = options.position ? options.position : this.position;
    const toastOptions: ToastOptions = {
      title: options.title,
      msg: options.msg,
      showClose: options.showClose,
      timeout: options.timeout,
      theme: options.theme,
      onAdd: (toast: ToastData) => {
        /* added */
      },
      onRemove: (toast: ToastData) => {
        /* removed */
      }
    };
  }

  tax(event) {


    if (event.target.checked) {
      this.istax = true;
    }
    else {
      this.istax = false;
    }
  }
  group() {
    this.value = true;

  }

}
export interface PeriodicElement {
  position: number;
  ClassificationofAccount: string;
  AlphaCode: string;
  StartingCode: number;
  EndingCode: number;
}
const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, ClassificationofAccount: 'Assests', AlphaCode: 'A', StartingCode: 1000, EndingCode: 1999 },
  { position: 2, ClassificationofAccount: 'Liability', AlphaCode: 'B', StartingCode: 2000, EndingCode: 2999 },
  { position: 3, ClassificationofAccount: 'Income', AlphaCode: 'C', StartingCode: 3000, EndingCode: 3999 },
  { position: 4, ClassificationofAccount: 'Expense', AlphaCode: 'D', StartingCode: 4000, EndingCode: 4999 },
];

