import { Component } from '@angular/core';
import { ChatService } from '../../../../services/chat.service';
import { Chatroom } from '../../../../models/chatroom';
import { ActivatedRoute, Router } from '@angular/router';
import {AuthserviceService} from "../../../../services/authservice.service";
import {Utenti} from "../../../../models/utenti";
import {UtentiService} from "../../../../services/utenti.service";

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css',
})
export class ChatComponent {
  chat: Chatroom | undefined;
  currentUser:string|undefined;
  constructor(
    private chatSvc: ChatService,
    private router: Router,
    private rottaAttiva: ActivatedRoute,
    private UtentiSvc:UtentiService
  ) {

    this.UtentiSvc.recuperaProfilo().subscribe(res=>{
      this.currentUser=res.data.us;
      console.log(this.currentUser)
    })

  }

  ngOnInit(): void {

    this.rottaAttiva.params.subscribe((p) => {
      let identificativo = p['cd'];
      this.pippo(identificativo);
    });


  }
  pippo(identificativo: string): void {
    this.chatSvc.recuperaRoom(identificativo).subscribe((res) => {
      this.chat = res.data;
      console.log(res.data);
    });
  }
}
