import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContractComponent } from './contract.component';

const routes: Routes = [
    {
        path: '',
        component: ContractComponent,
        data: {
            title: 'Contract',
            status: true
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

    
})
export class ContractRoutingModule { }
