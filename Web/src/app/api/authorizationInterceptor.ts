import {Injectable, Injector} from '@angular/core';
import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';
import { LoginService } from './login.service';

@Injectable()
export class AuthorizationInterceptor implements HttpInterceptor {
  constructor(private inj: Injector) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    //required to avoid cyclic dependency
    const loginService = this.inj.get(LoginService);

    if (
        !request.url.endsWith("account/refreshToken") &&
        loginService.getToken() != null &&
        loginService.getExpirationDate() < new Date(new Date().getTime() + 5 * 60000)
       ) {
        loginService.refreshToken().subscribe(success => {
            if (!success) {
                console.error("Failed to refresh token");
            }
        });
    }

    const token = loginService.getToken();
    if (token != null) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }
    return next.handle(request);
  }
}