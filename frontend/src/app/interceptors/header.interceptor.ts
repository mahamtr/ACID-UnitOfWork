import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';
import { TokenStorage } from './token.storage'


@Injectable()
export class AuthHeaderInterceptor implements HttpInterceptor {
  constructor(private token: TokenStorage) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var token  = this.token.getToken();
    
    req = req.clone({
      setHeaders: this.setHeaders(token),
    });
    
    return next.handle(req);
  }

  private setHeaders(token){
    return { Authorization: `Bearer ${token}` };
  }
}
