import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AttendanceDetailPopupComponent } from './attendance-detail-popup.component';

const routes: Routes = [
    {
        path: '',
        component: AttendanceDetailPopupComponent,
        data: {
            title: 'Attendance Detail Popup',
            status: true
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AttendanceDetailPopupRoutingModule { }
