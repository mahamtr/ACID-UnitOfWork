import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class TokenStorage {
  private tokenKey = 'authToken';
  private tokenRefreshKey = 'refreshToken';
  private userIdKey = 'userId';
  private userNameKey = 'userName';
  private userRoleKey = 'userRole';
  private userEmailKey = 'userEmailRole';

  signOut(): void {
    localStorage.clear();
  }

  saveToken(token?: string): void {
    if (!token) return;
    localStorage.setItem(this.tokenKey, token);
  }




  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }


}
