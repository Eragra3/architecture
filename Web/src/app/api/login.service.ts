import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {LoginResponse} from "./models/loginResponse";
import {LoginModel} from "./models/loginModel";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";

@Injectable()
export class LoginService {

  private _http: HttpClient;
  
  private _token: string;
  private _expirationDate: Date;

  constructor(http: HttpClient) {
    this._http = http;  
    this._token = localStorage.getItem("token");
    this._expirationDate = new Date(localStorage.getItem("expirationDate"));
  }

  login(username: string, password: string): Observable<boolean> {
    return this._http
    .post<LoginResponse>(
      environment.baseUrl + "api/security/account/login",
      new LoginModel(username, password)
    )
    .map(response => {
      this._token = response.token;
      this._expirationDate = new Date(response.expirationDate);
      localStorage.setItem("token", this._token);
      localStorage.setItem("expirationDate", this._expirationDate.toString());
      return true;
    })
    .catch(err => {
      return Observable.of(false);
    });
  }

  refreshToken(): Observable<boolean> {
    return this._http
    .post<LoginResponse>(
      environment.baseUrl + "api/security/account/refreshToken",
      null
    )
    .map(response => {
      this._token = response.token;
      this._expirationDate = new Date(response.expirationDate);
      localStorage.setItem("token", this._token);
      localStorage.setItem("expirationDate", this._expirationDate.toString());
      return true;
    })
    .catch(err => {
      return Observable.of(false);
    });
  }
  
  signOff() {
    localStorage.removeItem("token");
    localStorage.removeItem("expirationDate");
    this._token = null;
    this._expirationDate = null;
  }

  isLoggedIn(): boolean {
    return this._token != null && !this.isTokenExpired();
  }

  isTokenExpired(): boolean {
    return this._expirationDate < new Date();
  }

  getExpirationDate() {
    return this._expirationDate;
  }

  getToken() {
    return this._token;
  }
}
