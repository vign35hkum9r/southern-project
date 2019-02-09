import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatTableDataSource } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { MrnDialogComponent } from './mrn-dialog/mrn-dialog.component';



export interface PeriodicElement {
  Zucon: string;
  S_No: number;
  item_of_Material_Description: string;
  UOM: string;
  Packing_Unit: string;
  PO_Qty: number;
  Qty_RECEIVED_So_For: number;
  Received_Qty_in_UOM: number;
  Total_Received_Qty: number;
  Balance: number;
  History: any;
  Remove:any;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    S_No: 1, Zucon: 'M-B91F1A1-10001', item_of_Material_Description: 'Vitrified Floor Tiles of RAK Tiles', UOM: 'sq ft',
    Packing_Unit: 'Boxes', PO_Qty: 1560, Qty_RECEIVED_So_For: 750, Received_Qty_in_UOM: 11.25,
    Total_Received_Qty: 950, Balance: 600, History: 'history',Remove:'Remove'
  },
  {
    S_No: 2, Zucon: 'L-B91F1A1-10001', item_of_Material_Description: 'Vitrified Floor Tiles of RAK Tiles', UOM: 'sq ft',
    Packing_Unit: 'Boxes', PO_Qty: 1560, Qty_RECEIVED_So_For: 750, Received_Qty_in_UOM: 10.25,
    Total_Received_Qty: 760, Balance: 800, History: 'history',Remove:'Remove'
  },
  {
    S_No: 3, Zucon: 'G-B91F1A1-10001', item_of_Material_Description: 'Vitrified Floor Tiles of RAK Tiles', UOM: 'sq ft',
    Packing_Unit: 'Boxes', PO_Qty: 1560, Qty_RECEIVED_So_For: 750, Received_Qty_in_UOM: 9.25,
    Total_Received_Qty: 750, Balance: 400, History: 'history',Remove:'Remove'
  },

  // {position: 2, name: 'M-B91F1A1-10002', weight: 4.0026, symbol: 'He'},
  // {position: 3, name: 'M-B91F1A1-10003', weight: 6.941, symbol: 'Li'},
  // {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
  // {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
  // {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
  // {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
  // {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},

  // {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
  // {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
];

@Component({
  selector: 'app-mrn',
  templateUrl: './mrn.component.html',
  styleUrls: ['./mrn.component.scss']
})



// export class SelectMultipleExample {
//   toppings = new FormControl();
//   toppingList: string[] = ['Extra cheese', 'Mushroom', 'Onion', 'Pepperoni', 'Sausage', 'Tomato'];
// }

export class MRNComponent implements OnInit {
  // Stepper overview
  isOptional = false;
  firstFormGroup: FormGroup;

  // Stepper overview End
  mrn: boolean = false;
  mrns: boolean = true;
  model: any = [];
  bank = true;
  banks = false;
  selected = 'option2';
  isFormOpen: boolean = false;
  value = [];
  viewValue = [];
  constructor(private _formBuilder: FormBuilder,public dialog: MatDialog) {
  }
  ngOnInit() {
   
  }



  Bank() {
    this.bank = false;
    this.banks = true;

  }
  MRN() {
    this.mrns = false;
    this.mrn = true;

  }
  cancel() {
    this.bank = true;
    this.banks = false;
  }
  Cancel() {
    this.mrns = true;
    this.mrn = false;
  }
  Food = [
    { value: 'steak-0', viewValue: 'Steak' },
    { value: 'pizza-1', viewValue: 'Pizza' },
    { value: 'tacos-2', viewValue: 'Tacos' }
  ];

  foods(f) {
    this.model.Food[f] = (this.value = this.viewValue)
    this.model.Food = this.foods[f].value
  }
  getProject() {

    if (this.Food.length > 0)
      this.model.Food = this.model.value
  }

  create() {
    this.isFormOpen = true;
  }
  clear() {
    this.isFormOpen = false;
  }

  displayedColumns: string[] = ['select', 'S_No', 'Zucon', 'item of Material Description', 'UOM', 'Packing Unit',
    'PO Qty', 'Qty RECEIVED So For', 'Received Qty', 'Total Received Qty', 'Balance', 'History','Remove'];
  dataSource = new MatTableDataSource<PeriodicElement>(ELEMENT_DATA);
  selection = new SelectionModel<PeriodicElement>(true, []);

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.dataSource.data.forEach(row => this.selection.select(row));
  }

  view() {
    const dialogRef = this.dialog.open(MrnDialogComponent, {
      width: 'auto',
      data: {}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
    });
    
  }
}

