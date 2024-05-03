import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Risposta } from '../models/risposta';
import {AuthserviceService} from "./authservice.service";
import {UtentiService} from "./utenti.service";
import {Utenti} from "../models/utenti";

@Injectable({
  providedIn: 'root',
})
export class ChatService {

  constructor(private http: HttpClient, private UtentiSvc:UtentiService ) {
  }

  recuperaRoom(id: string): Observable<Risposta> {
    // let headerCustom = new HttpHeaders({
    //   Authorization: `Bearer ${contenutoToken}`,
    // });

    return this.http.get<Risposta>(`http://localhost:5297/Room/chat/${id}`, {
      // headers: headerCusto
    });
  }
}
