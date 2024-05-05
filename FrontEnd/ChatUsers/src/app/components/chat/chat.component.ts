import { Component } from '@angular/core';
import { ChatService } from '../../services/chat.service';
import { Chatroom } from '../../models/chatroom';
import { ActivatedRoute, Router } from '@angular/router';
import {AuthserviceService} from "../../services/authservice.service";
import {Utenti} from "../../models/utenti";
import {UtentiService} from "../../services/utenti.service";
import {formatDate} from "@angular/common";
import {MessaggeService} from "../../services/message.service";

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css',
})
export class ChatComponent {
  chat: Chatroom | undefined;
  currentUser:string|undefined;
  idChat!:string;
  handleInterval:any;
  showOptions: boolean = false;
  constructor(
    private chatSvc: ChatService,
    private router: Router,
    private rottaAttiva: ActivatedRoute,
    private UtentiSvc:UtentiService,
    private MessageSvc: MessaggeService
  ) {

    this.UtentiSvc.recuperaProfilo().subscribe(res=>{
      this.currentUser=res.data.us;
      console.log(this.currentUser)
    })

  }

  ngOnInit(): void {

    this.rottaAttiva.params.subscribe((p) => {
      let identificativo = p['cd'];
      this.idChat = identificativo
      this.pippo(identificativo);
    });
    this.handleInterval = setInterval(() => {
      this.pippo(this.idChat);
    }, 1000)

  }
  ngOnDestroy(): void {
    clearInterval(this.handleInterval);
  }
  pippo(identificativo: string): void {
    this.chatSvc.recuperaRoom(identificativo).subscribe((res) => {
      this.chat = res.data;
      console.log(res.data);
    });
  }

  addtrigger() {
      this.showOptions = !this.showOptions
  }

  protected readonly formatDate = formatDate;

  delete(messageId:string) {
    this.MessageSvc.deleteMessage(messageId).subscribe(res=>{
      console.log(res.status)
    })
  }
}
