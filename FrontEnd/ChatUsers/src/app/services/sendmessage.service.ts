import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Risposta } from '../models/risposta';

@Injectable({
  providedIn: 'root',
})
export class SendmessageService {
  constructor(private http: HttpClient) {}

  sendMessage(id: string, messageContent: string) {
    const url = `http://localhost:5297/Message/sendMessage/${id}`;

    // Headers
    const headers = new HttpHeaders({

    });

    // Body
    const body = JSON.stringify({
      text: messageContent,
    });
    let contenutoToken = localStorage.getItem('ilToken');

    let headerCustom = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${contenutoToken}`
    });
    // Effettua la richiesta POST
    return this.http.post(url, body, { headers: headerCustom });
  }
}
