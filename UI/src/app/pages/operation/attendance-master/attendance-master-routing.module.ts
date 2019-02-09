import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AttendanceMasterComponent } from './attendance-master.component';

const routes: Routes = [
    {
        path: '',
        component: AttendanceMasterComponent,
        data: {
            title: 'Attendance Master',
            status: true
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

    
})
export class AttendanceMasterRoutingModule { }
