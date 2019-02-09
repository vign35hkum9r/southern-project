import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerAssignComponent } from './customer-assign.component';

const routes: Routes = [
    {
        path: '',
        component: CustomerAssignComponent,
        data: {
            title: 'CustomerAssign',
            status: true
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

    
})
export class CustomerAssignRoutingModule { }
