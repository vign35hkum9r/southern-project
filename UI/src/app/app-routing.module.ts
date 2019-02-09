import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './layout/admin/admin.component';
import { AuthComponent } from './layout/auth/auth.component';
import { LoginComponent } from './login/login.component';
const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  {
    path: '',
    component: AdminComponent,
    children: [
      {
        path: '',
        redirectTo: 'home/dashboard/default',
        pathMatch: 'full'
      },
      {
        path: 'home/dashboard',
        loadChildren: './pages/dashboard/dashboard.module#DashboardModule'
      },

      {
        path: '',
        loadChildren: './pages/bank/banking.module#BankModule'
      },

      {
        path: '',
        loadChildren: './pages/bdm/bdm.module#BdmModule'
      },
      {
        path: '',
        loadChildren: './pages/operation/operation.module#OperationModule'
      },
      {
        path: '',
        loadChildren: './pages/customer/customer.module#CustomerModule'
      },
      {
        path: '',
        loadChildren: './pages/billing/billing.module#BillingModule'
      },
      {
        path: '',
        loadChildren: './pages/master/master.module#MasterModule'
      }
    ]
  },
  {
    path: '**',
    redirectTo: 'home/dashboard/default'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
