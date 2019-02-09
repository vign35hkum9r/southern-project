import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SalaryAllocationComponent } from './salary-allocation.component';

const routes: Routes = [
    {
        path: '',
        component: SalaryAllocationComponent,
        data: {
            title: 'Salary Allocation',
            status: true
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

    
})
export class SalaryAllocationRoutingModule { }
