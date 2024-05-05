import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Risposta} from "../models/risposta";

@Injectable({
  providedIn: 'root'
})
export class MessaggeService {

  constructor(private http:HttpClient) { }

  deleteMessage(messageId:string){
    let contenutoToken = localStorage.getItem('ilToken');

    let headerCustom = new HttpHeaders({
      Authorization: `Bearer ${contenutoToken}`,
    });

    return this.http.delete<Risposta>(`http://localhost:5297/Message/eliminaMessaggio/${messageId}`, {
      headers: headerCustom,
    });
  }
}
