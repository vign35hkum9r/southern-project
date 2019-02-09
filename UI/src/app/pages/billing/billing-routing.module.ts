import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '',
        data: {
            title: 'Billing',
            status: false
        },
        children: [
            {
                path: 'SalaryAllocation',
                loadChildren: './salary-allocation/salary-allocation.module#SalaryAllocationModule'
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class BillingRoutingModule { }
