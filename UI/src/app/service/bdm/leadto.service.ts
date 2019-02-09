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

const API_URL = configuration.url;

@Injectable()
export class LeadToService {
    clearAll(): any {
        throw new Error("Method not implemented.");
    }
    token: any;
    constructor(private http: Http) {
        debugger;
        this.token = localStorage.getItem('Token');
    }

    getService(objGetServiceDTO) {
        return this.http.post(API_URL + 'ServiceMaster/GetAllServices', objGetServiceDTO).map((res: Response) => {
            return res.json();
        })
    }    

    getOldLeadList(objGetEmpDTO) {
        return this.http.post(API_URL + 'ClientLeadChange/GetOldEmployeeList', objGetEmpDTO).map((res: Response) => {
            return res.json();
        })
    }

    getNewLeadList(objGetDesDTO) {
        return this.http.post(API_URL + 'ClientLeadChange/GetNewEmployeeList', objGetDesDTO).map((res: Response) => {
            return res.json();
        })
    }
  
   
    getClientByEmpId(objEmpDTO) {
        return this.http.post(API_URL + 'ClientLeadChange/GetAllClientByEmployee', objEmpDTO).map((res: Response) => {
            return res.json();
        })
    }


    saveChangeLead(objChangeLeadDTO) {
        return this.http.post(API_URL + 'ClientLeadChange/ChangeLead', objChangeLeadDTO).map((res: Response) => {
            return res.json();
        })
    }
}