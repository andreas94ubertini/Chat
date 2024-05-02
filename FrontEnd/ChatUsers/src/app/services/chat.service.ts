import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Risposta } from '../models/risposta';

@Injectable({
  providedIn: 'root',
})
export class ChatService {
  constructor(private http: HttpClient) {}

  recuperaRoom(id: string): Observable<Risposta> {
    // let headerCustom = new HttpHeaders({
    //   Authorization: `Bearer ${contenutoToken}`,
    // });

    return this.http.get<Risposta>(`http://localhost:5297/Room/chat/${id}`, {
      // headers: headerCustom,
    });
  }
}
