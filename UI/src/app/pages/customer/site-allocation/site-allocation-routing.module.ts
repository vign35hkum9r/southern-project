import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SiteAllocationComponent } from './site-allocation.component';

const routes: Routes = [
    {
        path: '',
        component: SiteAllocationComponent,
        data: {
            title: 'SiteAllocation',
            status: true
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

    
})
export class SiteAllocationRoutingModule { }
