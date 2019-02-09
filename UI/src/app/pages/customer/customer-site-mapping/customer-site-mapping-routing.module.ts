import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerSiteMappingComponent } from './customer-site-mapping.component';

const routes: Routes = [
    {
        path: '',
        component: CustomerSiteMappingComponent,
        data: {
            title: 'CustomerSiteMapping',
            status: true
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

    
})
export class CustomerSiteMappingRoutingModule { }
