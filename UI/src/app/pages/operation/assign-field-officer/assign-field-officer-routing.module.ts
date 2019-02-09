import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssignFieldOfficerComponent } from './assign-field-officer.component';

const routes: Routes = [
    {
        path: '',
        component: AssignFieldOfficerComponent,
        data: {
            title: 'Assign Field Officer',
            status: true
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

    
})
export class AssignFieldOfficerRoutingModule { }
