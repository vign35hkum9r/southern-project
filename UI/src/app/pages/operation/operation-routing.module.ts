import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '',
        data: {
            title: 'Operation',
            status: false
        },
        children: [
            {
                path: 'AttendanceMaster',
                loadChildren: './attendance-master/attendance-master.module#AttendanceMasterModule'
            },
            {
                path: 'AttendanceDetail',
                loadChildren: './attendance-detail/attendance-detail.module#AttendanceDetailModule'
            },
            {
                path: 'AssignFieldOfficer',
                loadChildren: './assign-field-officer/assign-field-officer.module#AssignFieldOfficerModule'
            },
            {
                path: 'AssignManpower',
                loadChildren: './assign-manpower/assign-manpower.module#AssignManpowerModule'
            },
            {
                path: 'ManpowerDetail',
                loadChildren: './manpower-detail/manpower-detail.module#ManpowerDetailModule'
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class OperationRoutingModule { }
