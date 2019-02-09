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
export class Led_SubledService {
    
    clearAll(): any {
        throw new Error("Method not implemented.");
    }
    token: any;
    constructor(private http: Http) {
        debugger;
        this.token = localStorage.getItem('Token');
    }


    getallLedger() {

        const headers = new Headers();
        headers.append('Token', this.token);
        return this.http.get(configuration.url + 'Led_Subled/GetAllLedger', { headers: headers }).map((res: Response) => {
            return res.json();
        })
    }

    getLedgerCode(AccountCodeId) {

        const headers = new Headers();
        headers.append('Token', this.token);
        return this.http.get(configuration.url + 'Led_Subled/GetLedgerCode/' + AccountCodeId, { headers: headers }).map((res: Response) => {
            return res.json();
        })
    }

    createLedger(led) {

        const headers = new Headers();
        headers.append('Token', this.token);
        return this.http.post(configuration.url + 'Led_Subled/CreateLedger', led, { headers: headers }).map((res: Response) => {

            return res.json();
        })
    }

    createSubLedger(led) {

        const headers = new Headers();
        headers.append('Token', this.token);
        return this.http.post(configuration.url + 'Led_Subled/CreateSubLedger', led, { headers: headers }).map((res: Response) => {

            return res.json();
        })
    }

    //     updateGroup(grp){
    //         const headers = new Headers();
    //         headers.append('Token', this.token);
    //         return this.http.put(configuration.url + 'GroupandSubgroup/Update', grp, { headers: headers }).map((res: Response) => {
    //             return res.json();
    //         })
    //     }
}