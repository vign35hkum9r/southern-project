import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/service/login/login.service';
import { FormControl, FormGroupDirective, NgForm, Validators, ReactiveFormsModule } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { ToastyService } from 'ng2-toasty';
/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss',
    '../../../node_modules/ng2-toasty/style-bootstrap.css',
    '../../../node_modules/ng2-toasty/style-default.css',
    '../../../node_modules/ng2-toasty/style-material.css',


  ],
  encapsulation: ViewEncapsulation.None

})
export class LoginComponent implements OnInit {

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);
  matcher = new MyErrorStateMatcher();
  position = 'top-right';
  theme = 'material';
  type = 'material';
  User: any = [];
  str: string = "Sign In"
  isCheck: boolean = false;

  constructor(private router: Router, private loginservice: LoginService, private toastr: ToastyService) { }
  error: any;

  ngOnInit() {
  }

  login() {
    debugger;
    this.isCheck = true;
    this.str = "Processing"
    this.loginservice.login(this.User).subscribe(res => {
      console.log(res);
      if (res.status == 200) {
        this.isCheck = false;
        this.str = "Sign In"

        this.router.navigate([`./AdminComponent`])
      }
    }, error => {
      this.isCheck = false;
      this.str = "Sign In"

      this.toastr.error("invalid username  and password");
    })

  }

}
