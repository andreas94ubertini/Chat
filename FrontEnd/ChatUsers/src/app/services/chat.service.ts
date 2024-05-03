import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Risposta } from '../models/risposta';
import {AuthserviceService} from "./authservice.service";
import {UtentiService} from "./utenti.service";
import {Utenti} from "../models/utenti";
import {Chatroom} from "../models/chatroom";

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

  CreateChatRoom(roomName:string,roomDesc:string):Observable<Risposta>{
    let chat:Chatroom = new Chatroom();
    chat.roN = roomName;
    chat.des = roomDesc;
    let contenutoToken = localStorage.getItem('ilToken');

    let headerCustom = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${contenutoToken}`
    });
    return this.http.post<Risposta>("http://localhost:5297/Room", chat, {headers: headerCustom})
  }

  InsertUserToChat(id:string, username:string):Observable<Risposta>{
    return this.http.post<Risposta>(`http://localhost:5297/Room/chat/addUser/${id}?username=${username}`, username)
  }

  getAllUsersByChat(id:string):Observable<Risposta>{
    return this.http.get<Risposta>(`http://localhost:5297/Room/userPerRoom/${id}`)
  }
}
