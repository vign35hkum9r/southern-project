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
export class AttendanceMasterService {

  constructor(private _httpClient: HttpClient) { }

  addAssignManpower(element?): Observable<string> {
    return this._httpClient.post<string>(API_URL + "TestingController/AddTestingMethod", element)
      .pipe(catchError(this.handleError));
  }

  removeAssignManpower(element?): Observable<string> {
    return this._httpClient.post<string>(API_URL + "TestingController/ModifyTestingMethod", element)
      .pipe(catchError(this.handleError));
  }

  getCustomers(element): Observable<any> {
    return this._httpClient.post<any>(API_URL + "ManpowerAttendance/getAllCustomer", element)
      .pipe(catchError(this.handleError));
  }

  getStatus(element): Observable<any> {
    return this._httpClient.post<any>(API_URL + "ManpowerAttendance/getAllStatus", element)
      .pipe(catchError(this.handleError));
  }

  getArea(element): Observable<any> {
    return this._httpClient.post<any>(API_URL + "ManpowerAttendance/getAllBranch", element)
      .pipe(catchError(this.handleError));
  }

  getSite(element): Observable<any> {
    return this._httpClient.post<any>(API_URL + "ManpowerAttendance/getAllSite", element)
      .pipe(catchError(this.handleError));
  }

  getAssignManpowers(element): Observable<any> {
    return this._httpClient.post<any>(API_URL + "AssignManpower/getAllAssignManpower", element)
      .pipe(catchError(this.handleError));
  }

  getClassification(element): Observable<any> {
    return this._httpClient.post<any>(API_URL + "AssignManpower/getAllClassification", element)
      .pipe(catchError(this.handleError));
  }

  getService(element): Observable<any> {
    return this._httpClient.post<any>(API_URL + "AssignManpower/getAllService", element)
      .pipe(catchError(this.handleError));
  }

  getManpower(element): Observable<any> {
    return this._httpClient.post<any>(API_URL + "ManpowerAttendance/getAllEmployee", element)
      .pipe(catchError(this.handleError));
  }

  getShiftMaster(element): Observable<any> {
    return this._httpClient.post<any>(API_URL + "ShiftMapping/GetAllShiftByContract", element)
      .pipe(catchError(this.handleError));
  }

  // getPayment(): Observable<any> {
  //   return this._httpClient.get<any>("TestingController/TestingMethod")
  //     .pipe(catchError(this.handleError));
  // }

  handleError(error: HttpErrorResponse) {
    return throwError(error);
  }
}
