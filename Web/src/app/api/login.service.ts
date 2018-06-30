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

  private _isLoggedIn: boolean = false;
  private _token: string;
  private _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;  
    this._token = localStorage.getItem("token");
    if (this._token != null) {
      this._isLoggedIn = true;
    }
  }

  login(username: string, password: string): Observable<boolean> {
    return this._http
    .post<LoginResponse>(
      environment.baseUrl + "api/security/account/login",
      new LoginModel(username, password)
    )
    .map(response => {
      this._token = response.token;
      localStorage.setItem("token", this._token);
      this._isLoggedIn = true;
      return true;
    })
    .catch(err => {
      return Observable.of(false);
    });
  }
  
  signOff() {
    localStorage.removeItem("token");
    this._token = null;
    this._isLoggedIn = false;
}

  isLoggedIn(): boolean {
    return this._isLoggedIn;
  }

  getToken() {
    return this._token;
  }
}
