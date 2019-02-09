import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DesignationComponent } from './designation.component';

const routes: Routes = [
    {
        path: '',
        component: DesignationComponent,
        data: {
            title: 'Designation',
            status: true
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

    
})
export class DesignationRoutingModule { }
