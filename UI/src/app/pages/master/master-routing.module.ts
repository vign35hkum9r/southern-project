import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '',
        data: {
            title: 'Master',
            status: false
        },
        children: [
            {
                path: 'Employee',
                loadChildren: './employee/employee.module#EmployeeModule'
            },
            {
                path: 'department',
                loadChildren: './department/department.module#DepartmentModule'
            },
            {
                path: 'designation',
                loadChildren: './designation/designation.module#DesignationModule'
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class MasterRoutingModule { }
