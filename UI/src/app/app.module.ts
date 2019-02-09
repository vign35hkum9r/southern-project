import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminComponent } from './layout/admin/admin.component';
//import { AuthComponent } from './layout/auth/auth.component'; 
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/shared.module';
import { BreadcrumbsComponent } from './layout/admin/breadcrumbs/breadcrumbs.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { LoginService } from 'src/app/service/login/login.service';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { ToastyModule } from 'ng2-toasty';
import { MatDialogRef, MAT_DIALOG_DATA, MAT_DATE_LOCALE, DateAdapter, MAT_DATE_FORMATS } from '@angular/material';
import { AppDateAdapter, APP_DATE_FORMATS } from './shared/directives/date-picker';
// import { EmployeeComponent } from './pages/master/employee/employee.component';
// import { DepartmentComponent } from './pages/master/department/department.component';
// import { DesignationComponent } from './pages/master/designation/designation.component';




@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    // AuthComponent,
    BreadcrumbsComponent,
    LoginComponent,
    // EmployeeComponent,
    // DepartmentComponent,
    // DesignationComponent,




  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    HttpModule,
    BrowserAnimationsModule,
    RouterModule,
    AppRoutingModule,
    SharedModule,
    FormsModule,
    ToastyModule.forRoot(),








  ],
  schemas: [],
  providers: [

    LoginService, { provide: MatDialogRef, useValue: {} },
    { provide: MAT_DIALOG_DATA, useValue: [] },
    { provide: MAT_DATE_LOCALE, useValue: "en-gb" },
    { provide: DateAdapter, useClass: AppDateAdapter },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS }


  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
