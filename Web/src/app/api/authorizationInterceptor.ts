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
    console.log('interceptor activee');
    const loginService = this.inj.get(LoginService);
    if (request.url != '/oauth/token') {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${loginService.getToken()}`
        }
      });
    }
    return next.handle(request);
  }
}