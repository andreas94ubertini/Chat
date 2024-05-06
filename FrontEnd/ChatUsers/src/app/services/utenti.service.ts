import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Risposta } from '../models/risposta';
import { Utenti } from '../models/utenti';

@Injectable({
  providedIn: 'root',
})
export class UtentiService {
  base_url: string = 'http://localhost:5297/Utenti/profiloutente';
  constructor(private http: HttpClient) {}

  recuperaProfilo(): Observable<Risposta> {
    let contenutoToken = localStorage.getItem('ilToken');

    let headerCustom = new HttpHeaders({
      Authorization: `Bearer ${contenutoToken}`,
    });

    return this.http.get<Risposta>(this.base_url, {
      headers: headerCustom,
    });
  }
  getAllUsers(): Observable<Risposta> {
    return this.http.get<Risposta>('http://localhost:5297/Utenti/AllUsers');
  }
  modifyImg(user: Utenti) {
    let contenutoToken = localStorage.getItem('ilToken');

    let headerCustom = new HttpHeaders({
      Authorization: `Bearer ${contenutoToken}`,
    });

    return this.http.put<Risposta>(
      'http://localhost:5297/Utenti/modificaImg',
      user,
      {
        headers: headerCustom,
      }
    );
  }
}
