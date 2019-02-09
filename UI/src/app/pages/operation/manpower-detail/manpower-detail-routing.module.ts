import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManpowerDetailComponent } from './manpower-detail.component';

const routes: Routes = [
    {
        path: '',
        component: ManpowerDetailComponent,
        data: {
            title: 'Manpower Detail',
            status: true
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

    
})
export class ManpowerDetailRoutingModule { }
