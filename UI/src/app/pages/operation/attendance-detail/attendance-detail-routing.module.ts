import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AttendanceDetailComponent } from './attendance-detail.component';

const routes: Routes = [
    {
        path: '',
        component: AttendanceDetailComponent,
        data: {
            title: 'Attendance Detail',
            status: true
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AttendanceDetailRoutingModule { }
