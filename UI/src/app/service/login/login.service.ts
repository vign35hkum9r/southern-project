import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers, Jsonp } from '@angular/http';

import 'rxjs/Rx';
import { HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';

import { configuration } from '../../common/configuration/config';

import { Observable } from 'rxjs/internal/Observable';


@Injectable()
export class LoginService {
    debugger;
    Username: any;
    userid: any;
    data: any;
    token: any;
    MenuList: any;
    loggedUser: any;
    SelectedCompany: any;
    selectedCompanyName: any;
    isAuth: any;
    constructor(private http: HttpClient) {
    }


    login(obj): Observable<any> {
        const body = JSON.stringify({ UserName: obj.Username, Password: obj.password });
        return this.http.post<any>(configuration.url + 'login ', { UserName: obj.Username, Password: obj.password },
            {
                headers: new HttpHeaders().set('Authorization', 'Basic ' +
                    btoa(obj.Username + ":" + obj.password)), observe: 'response'
            }).do(response => {
                if (response.status == 200) {
                    this.data = response.headers.get('UserId');
                    this.isAuth = true;
                    localStorage.setItem('userID', this.data)
                    sessionStorage.setItem('userID', this.data)

                    this.token = response.headers.get('Token');
                    this.isAuth = true;
                    localStorage.setItem('Token', this.token)
                    sessionStorage.setItem('Token', this.token)

                    localStorage.setItem('isAuth', this.isAuth);
                    sessionStorage.setItem('isAuth', this.isAuth);
                    return response;
                }
            }, (error: HttpErrorResponse) => {
                console.log(error);
                return error;

            });

    }

    User(userID) {
        debugger;
        return this.http.get(configuration.url + 'User/GetUserById/' + userID).map((res: Response) => {
            console.log(res)
            return res;

        });
    }
    getLoggedUserDetails() {
        this.loggedUser = JSON.parse(sessionStorage.getItem('loggedUserDetails')) || JSON.parse(localStorage.getItem('loggedUserDetails'));
        this.Username = (this.loggedUser) ? this.loggedUser.FirstName : "";
        if (this.loggedUser) {
            this.selectedCompanyName = (this.loggedUser.SelectedCompany !== null && this.loggedUser.SelectedCompany !== undefined) ?
                this.loggedUser.SelectedCompany.CompanyName : "";
        }
        return this.loggedUser;
    }
    setLoggedUserDetails(userDetails) {
        debugger;
        this.loggedUser = userDetails;
        this.Username = this.loggedUser.FirstName;

        if (this.loggedUser.SelectedCompany !== null && this.loggedUser.SelectedCompany !== undefined)
            this.selectedCompanyName = this.loggedUser.SelectedCompany.CompanyName;
        else
            this.selectedCompanyName = null;

        sessionStorage.setItem('loggedUserDetails', JSON.stringify(userDetails));
        localStorage.setItem('loggedUserDetails', JSON.stringify(userDetails));


    }

}