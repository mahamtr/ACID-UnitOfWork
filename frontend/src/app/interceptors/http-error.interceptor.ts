import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpErrorResponse,
} from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';

import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { TokenStorage } from './token.storage'

@Injectable()
export class CatchErrorInterceptor implements HttpInterceptor {
  constructor(private snackBar: MatSnackBar, private router: Router, private authService :TokenStorage) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(this.showSnackBar));
  }

  private showSnackBar = (response: HttpErrorResponse): Observable<never> => {
    const text: string | undefined = response.error;
    if (text) {
      this.snackBar.open(text, 'Close', {
        duration: 2000,
      });
    }
    if(response.status === 401) {
      this.authService.signOut()
      this.router.navigateByUrl('/auth/login')

    };
    return throwError(response);
  };
}
