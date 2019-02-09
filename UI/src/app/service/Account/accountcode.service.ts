import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers, Jsonp } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import { HttpHeaders } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators/map';
import { tap } from 'rxjs/operators/tap';
import { configuration } from '../../common/configuration/config';
import { MenuItems } from '../../layout/admin/menuitems/menuitem';


@Injectable()
export class AccountCodeService {
    clearAll(): any {
        throw new Error("Method not implemented.");
    }
    token: any;
    constructor(private http: Http) {
        debugger;
        this.token = localStorage.getItem('Token');
    }


    getallAccountCode() {
        debugger;
        const headers = new Headers();
        headers.append('Token', this.token);
        return this.http.get(configuration.url + 'AccountCode/GetAllAccountCode', { headers: headers }).map((res: Response) => {
            return res.json();
        })
    }

    createAccountCode(acc) {

        const headers = new Headers();
        headers.append('Token', this.token);
        return this.http.post(configuration.url + 'AccountCode/Create', acc, { headers: headers }).map((res: Response) => {

            return res.json();
        })
    }
}