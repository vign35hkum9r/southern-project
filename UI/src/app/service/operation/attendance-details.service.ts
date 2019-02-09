import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpHeaders,
  HttpErrorResponse
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { configuration } from '../../common/configuration/config';
import { environment } from 'src/environments/environment';

 const API_URL = configuration.url;

@Injectable({
  providedIn: 'root'
})
export class AttendanceDetailsService {

  constructor(private _httpClient: HttpClient) { }

  listAttendance(element) {
    return this._httpClient.post(API_URL + 'api/ManpowerAttendance/getAttendance', element)
    .pipe(catchError(this.handleError));
  }

  listCustomer(element) {
    return this._httpClient.post(API_URL + 'api/OverAllAttendance/getAllManpowerCustomer', element)
    .pipe(catchError(this.handleError));
  }

  listBranch(element) {
    return this._httpClient.post(API_URL + 'api/OverAllAttendance/getAllBranchManpower', element)
    .pipe(catchError(this.handleError));
  }

  listSite(element) {
    return this._httpClient.post(API_URL + 'api/OverAllAttendance/getAllSiteManpower', element)
    .pipe(catchError(this.handleError));
  }

  listManpower(element) {
    return this._httpClient.post(API_URL + 'api/OverAllAttendance/getAllSiteManpower', element)
    .pipe(catchError(this.handleError));
  }

  saveAttendance(element) {
    const headers = new Headers();    
    return this._httpClient.post(API_URL + 'api/ManpowerAttendance/InsertAttendanceHistory', element)
    .pipe(catchError(this.handleError));
  }

  getStatusMaster(element) {
    return this._httpClient.post(API_URL + 'api/ManpowerAttendance/getAllStatus', element)
    .pipe(catchError(this.handleError));
  }
  
  modifyAttendance(element) {
    debugger;
    const headers = new Headers();    
    return this._httpClient.post(API_URL + 'api/ManpowerAttendance/UpdateAttendance', element)
    .pipe(catchError(this.handleError));
  }

  // listParentDepartmentDetails(): Observable<any> {
  //   debugger;
  //   const headers = new Headers();
  //   headers.append('Token', this._headerStorage.getToken());
  //   const dataUrl = API_URL + 'Department/GetDepartmentId';
  //   return this._httpClient.get(dataUrl, { headers: headers })
  // }

  // generateSummary(reportParams?): Observable<string> {
  //   this.API_URL =  this._headerStorage.getApiUrl();
  //   const headers = new HttpHeaders().append("Token", this._headerStorage.getToken());
  //   return this._httpClient.post<string>(this.API_URL + "Permission/PermissionReportSummary",
  //       reportParams, { headers: headers }).pipe(catchError(this.handleError));
  // }

  handleError(error: HttpErrorResponse) {
    return throwError(error);
  }
}
