import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContractDetailComponent } from './contract-detail.component';

const routes: Routes = [
    {
        path: '',
        component: ContractDetailComponent,
        data: {
            title: 'ContractDetail',
            status: true
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

    
})
export class ContractDetailRoutingModule { }
