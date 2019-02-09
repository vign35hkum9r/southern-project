import { Injectable } from "@angular/core";
import {
  HttpClient,
  HttpHeaders,
  HttpErrorResponse
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { configuration } from '../../common/configuration/config';

const API_URL = configuration.url;

@Injectable({
  providedIn: "root"
})
export class EmployeeMasterService  {
    
  constructor(private _httpClient: HttpClient) { }

  addEmployee(element) {
    return this._httpClient
      .post(API_URL + "Employee/CreateEmployee", element)
      .pipe(catchError(this.handleError));
  }
  modifyEmployee(element) {
    return this._httpClient
      .post(API_URL + "Employee/UpdateEmployee", element)
      .pipe(catchError(this.handleError));
  }
  getAllEmployee(element) {
    return this._httpClient
      .post(API_URL + "Employee/GetAllEmployeeDetail", element)
      .pipe(catchError(this.handleError));
  }
  removeEmployee(element) {
    return this._httpClient
      .post(API_URL + "Employee/RemoveEmployee", element)
      .pipe(catchError(this.handleError));
  }

  addBank(element) {
    return this._httpClient
      .post(API_URL + "Employee/CreateEmployeeBankDtl", element)
      .pipe(catchError(this.handleError));
  }
  modifybank(element) {
    return this._httpClient
      .post(API_URL + "Employee/UpdateEmployeeBankDtl", element)
      .pipe(catchError(this.handleError));
  }
  getBankDetail(element) {
    return this._httpClient
      .get(API_URL + "Employee/GetEmployeeBankDtlById")
      .pipe(catchError(this.handleError));
  }
  removebank(element) {
    return this._httpClient
      .post(API_URL + "Employee/RemoveEmployeeBankDtl", element)
      .pipe(catchError(this.handleError));
  }
  getCompany(element): Observable<any> {
    debugger;
    return this._httpClient.post<any>(API_URL + "Company/GetAllCompanies",element)
      .pipe(catchError(this.handleError));
  }

  getDesignation(element): Observable<any> {
    return this._httpClient.post<any>(API_URL + "Designation/GetAllDesignations",element)
      .pipe(catchError(this.handleError));
  }
  getState(element): Observable<any> {
    return this._httpClient.post<any>(API_URL + "State/AllState",element)
      .pipe(catchError(this.handleError));
  }

  getCity(element): Observable<any> {
    return this._httpClient.post<any>(API_URL + "CityMaster/GetActiveCity",element)
      .pipe(catchError(this.handleError));
  }
  getBloodGroup(element): Observable<any> {
    return this._httpClient.post<any>(API_URL + "CityMaster/GetActiveCity",element)
      .pipe(catchError(this.handleError));
  }
  getReport(element): Observable<any> {
    return this._httpClient.post<any>(API_URL + "CityMaster/GetActiveCity",element)
      .pipe(catchError(this.handleError));
  }
  handleError(error: HttpErrorResponse) {
    return throwError(error);
  }
}