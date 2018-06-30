import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs/Observable";

@Injectable()
export class LoginService {

  private _isLoggedIn: boolean = false;
  private _token: string;

  constructor(http: HttpClient) {
  }

  login(username: string, password: string): Observable<boolean> {
    return Observable.of("token").map(t => {
      console.log(`${username} ${password}`);
      this._isLoggedIn = true;
      this._token = t;
      return this._isLoggedIn;
    })
  }

  isLoggedIn(): boolean {
    return this._isLoggedIn;
  }

  getToken() {
  }
}
