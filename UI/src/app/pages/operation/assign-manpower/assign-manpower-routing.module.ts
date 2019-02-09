import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssignManpowerComponent } from './assign-manpower.component';

const routes: Routes = [
    {
        path: '',
        component: AssignManpowerComponent,
        data: {
            title: 'Assign Manpower',
            status: true
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

    
})
export class AssignManpowerRoutingModule { }
