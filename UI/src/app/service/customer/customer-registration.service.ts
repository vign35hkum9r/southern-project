import { Injectable } from "@angular/core";
import {
  HttpClient,
  HttpHeaders,
  HttpErrorResponse
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { configuration } from '../../common/configuration/config';
import { environment } from 'src/environments/environment';
import { Http } from "@angular/http";

 const API_URL = configuration.url;
@Injectable({
  providedIn: "root"
})
export class CustomerRegistrationService {
  constructor(private _httpClient: HttpClient) {}

  addCustomer(element) {
    return this._httpClient
      .post(API_URL + "Customer/CreateCustomer", element)
      .pipe(catchError(this.handleError));
  }
  modifyCustomer(element) {
    return this._httpClient
      .post(API_URL + "Customer/UpdateCustomer", element)
      .pipe(catchError(this.handleError));
  }
  getAllCustomer(element?: any) {
    debugger;
    return this._httpClient
      .post(API_URL + "Customer/GetAllCustomers", element)
      .pipe(catchError(this.handleError));
  }
  removeCustomer(element?: any) {
    debugger;
    return this._httpClient
      .post(API_URL + "Customer/RemoveCustomerById", element)
      .pipe(catchError(this.handleError));
  }
  getAllSuccessCustomer(element?: any) {
    debugger;
    return this._httpClient
      .post(API_URL + "Customer/GetAllSuccessCustomers", element)
      .pipe(catchError(this.handleError));
  }

  getCompany(element?: any) {
    debugger;
    return this._httpClient
      .get(API_URL + "Company/AllCompany", element)
      .pipe(catchError(this.handleError));
  }
  getState(element?: any) {
    debugger;
    return this._httpClient
      .get(API_URL + "State/AllState", element)
      .pipe(catchError(this.handleError));
  }
  getCity(element?: any) {
    return this._httpClient
      .get(API_URL + "City/GetCityByStateId/" + element)
      .pipe(catchError(this.handleError));
  }
  handleError(error: HttpErrorResponse) {
    return throwError(error);
  }
}
