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

const API_URL = configuration.url;

@Injectable({
  providedIn: "root"
})
export class ContractMasterService {
  constructor(private _httpClient: HttpClient) { }

  addContract(element) {
    return this._httpClient
      .post(API_URL + "ContractMaster/CreateContractMaster", element)
      .pipe(catchError(this.handleError));
  }
  modifyContract(element) {
    return this._httpClient
      .post(API_URL + "ContractMaster/UpdateContractMaster", element)
      .pipe(catchError(this.handleError));
  }
  getAllContract(element) {
    return this._httpClient
      .post(API_URL + "ContractMaster/GetAllContractMasters", element)
      .pipe(catchError(this.handleError));
  }
  getAllSuccessCustomer(element) {
    return this._httpClient
      .post(API_URL + "Customer/GetAllCustomers", element)
      .pipe(catchError(this.handleError));
  }
  removeContract(element) {
    return this._httpClient
      .post(API_URL + "ContractMaster/RemoveContractMasterById", element)
      .pipe(catchError(this.handleError));
  }
  handleError(error: HttpErrorResponse) {
    return throwError(error);
  }
}
