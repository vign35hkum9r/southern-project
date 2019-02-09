import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LedgerLibraryComponent} from './ledger-library.component';

const routes: Routes = [
  {
    path: '',
    component: LedgerLibraryComponent,
    data: {
      title: 'ledgerlibrary',                  
      status: true
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LedgerLibraryRoutingModule { }