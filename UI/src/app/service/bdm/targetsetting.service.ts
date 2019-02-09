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
export class TargetSettingService {
    clearAll(): any {
        throw new Error("Method not implemented.");
    }
    token: any;
    constructor(private http: Http) {
        debugger;
        this.token = localStorage.getItem('Token');
    }


    getAllEmployeeByReportTo(objGetEmployee) {
        return this.http.post(API_URL + 'Target/GetAllEmployeeByReportTo', objGetEmployee).map((res: Response) => {
            return res.json();
        })
    }

    getDetailByMonth(objGetDetail) {
        return this.http.post(API_URL + 'Target/GetAllEmployeeByMonth', objGetDetail).map((res: Response) => {
            return res.json();
        })
    }

    getByEmployeeTarget(objGetDetail) {
        return this.http.post(API_URL + 'Target/GetAllTargetGraphByEmployeeId', objGetDetail).map((res: Response) => {
            return res.json();
        })
    }
   
    getTargetForGrid(objGetDetail) {
        return this.http.post(API_URL + 'Target/GetAllTargetforGrid', objGetDetail).map((res: Response) => {
            return res.json();
        })
    }

    getTargetForGridByEmployeeId(objGetDetail) {
        return this.http.post(API_URL + 'Target/GetAllTargetByEmployeeId', objGetDetail).map((res: Response) => {
            return res.json();
        })
    }

    AddEmployeeTarget(objAddTarget) {
        return this.http.post(API_URL + 'Target/CreateTarget', objAddTarget).map((res: Response) => {
            return res.json();
        })
    }

    getAllTargets(objGetTarget) {
        return this.http.post(API_URL + 'Target/GetAllTarget', objGetTarget).map((res: Response) => {
            return res.json();
        })
    }

    getMyTarget(objGetTarget) {
        return this.http.post(API_URL + 'Target/GetAllTargetGraph', objGetTarget).map((res: Response) => {
            return res.json();
        })
    }
  
    RemoveEmployeeTarget(objGetTarget) {
        return this.http.post(API_URL + 'Target/RemoveTarget', objGetTarget).map((res: Response) => {
            return res.json();
        })
    }

    getMyTargetList(objGetTarget) {
        return this.http.post(API_URL + 'Target/GetMyTargetList', objGetTarget).map((res: Response) => {
            return res.json();
        })
    }

    getAllEmployee(objGetEmpDTO) {
        return this.http.post(API_URL + 'Employee/GetAllEmployees', objGetEmpDTO).map((res: Response) => {
            return res.json();
        })
    }
}