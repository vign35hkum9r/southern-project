import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerRegistrationComponent } from './customer-registration.component';

const routes: Routes = [
    {
        path: '',
        component: CustomerRegistrationComponent,
        data: {
            title: 'CustomerRegistration',
            status: true
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

    
})
export class CustomerRegistrationRoutingModule { }
