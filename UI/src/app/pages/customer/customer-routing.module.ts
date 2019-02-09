import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '',
        data: {
            title: 'Customer',
            status: false
        },
        children: [
            {
                path: 'Contract',
                loadChildren: './contract/contract.module#ContractModule'
            },
            {
                path: 'ContractDetail',
                loadChildren: './contract-detail/contract-detail.module#ContractDetailModule'
            },
            {
                path: 'CustomerAssign',
                loadChildren: './customer-assign/customer-assign.module#CustomerAssignModule'
            },
            {
                path: 'CustomerRegistration',
                loadChildren: './customer-registration/customer-registration.module#CustomerRegistrationModule'
            },
            {
                path: 'CustomerSiteMapping',
                loadChildren: './customer-site-mapping/customer-site-mapping.module#CustomerSiteMappingModule'
            },
            {
                path: 'SiteAllocation',
                loadChildren: './site-allocation/site-allocation.module#SiteAllocationModule'
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class CustomerRoutingModule { }
