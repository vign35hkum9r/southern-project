import { Component, OnInit, ViewChild } from '@angular/core';
import {MatPaginator, MatSort, MatTableDataSource} from '@angular/material';
import {transition, trigger, style, animate, state} from "@angular/animations";

export interface UserData {
  id: string;
  name: string;
  progress: string;
  color: string;
 
}
trigger('myAnimationTrigger', [
  transition('* => visible', [
    style({ opacity: 0 }),
    animate('500ms', style({ opacity: 1 }))
  ]),
  transition('* => hidden', [
    animate('500ms', style({ opacity: 0 }))
  ])
])
trigger('myAnimationTrigger', [
  state('visible', style({ opacity: 1 })),
  state('hidden', style({ opacity: 0 })),
  transition('* => visible', [
    animate('500ms')
  ]),
  transition('* => hidden', [
    animate('500ms')
  ])
])
/** Constants used to fill up our data base. */
const COLORS: string[] = ['maroon', 'red', 'orange', 'yellow', 'olive', 'green', 'purple',
  'fuchsia', 'lime', 'teal', 'aqua', 'blue', 'navy', 'black', 'gray'];
const NAMES: string[] = ['Maia', 'Asher', 'Olivia', 'Atticus', 'Amelia', 'Jack',
  'Charlotte', 'Theodore', 'Isla', 'Oliver', 'Isabella', 'Jasper',
  'Cora', 'Levi', 'Violet', 'Arthur', 'Mia', 'Thomas', 'Elizabeth'];

@Component({
  selector: 'app-chartofaccount',
  templateUrl: './chartofaccount.component.html',
  styleUrls: ['./chartofaccount.component.scss'],

  animations: [
    trigger('myAnimationTrigger', [
      transition('* => someState', [
        // animations go here
      ])
    ])
  ]

})


export class ChartofaccountComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'progress', 'color','action'];
  dataSource: MatTableDataSource<UserData>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  isFormOpen: boolean;

  constructor() {
    // Create 100 users
    const users = Array.from({length: 100}, (_, k) => createNewUser(k + 1));

    // Assign the data to the data source for the table to render
    this.dataSource = new MatTableDataSource(users);
  }
  
  create(){
    this.isFormOpen = true;
  }
  clear(){
    this.isFormOpen = false;
  }
  

  ngOnInit() {

    this.isFormOpen = false;
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  
}

/** Builds and returns a new User. */
function createNewUser(id: number): UserData {
  const name =
      NAMES[Math.round(Math.random() * (NAMES.length - 1))] + ' ' +
      NAMES[Math.round(Math.random() * (NAMES.length - 1))].charAt(0) + '.';

  return {
    id: id.toString(),
    name: name,
    progress: Math.round(Math.random() * 100).toString(),
    color: COLORS[Math.round(Math.random() * (COLORS.length - 1))],
 
 
  };

  
}
