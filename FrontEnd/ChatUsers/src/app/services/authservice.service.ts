import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RisToken } from '../models/ris-token';
@Injectable({
  providedIn: 'root',
})
export class AuthserviceService {
  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<RisToken> {
    let headerCustom = new HttpHeaders();
    headerCustom.set('Content-Type', 'application/json');

    let invio = {
      username,
      password,
    };

    return this.http.post<any>('http://localhost:5297/Auth/login', invio, {
      headers: headerCustom,
    });
  }
}
