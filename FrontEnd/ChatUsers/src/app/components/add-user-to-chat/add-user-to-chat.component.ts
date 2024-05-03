import { Component } from '@angular/core';
import {UtentiService} from "../../services/utenti.service";
import {Utenti} from "../../models/utenti";
import {ActivatedRoute} from "@angular/router";
import {ChatService} from "../../services/chat.service";
import {log} from "@angular-devkit/build-angular/src/builders/ssr-dev-server";

@Component({
  selector: 'app-add-user-to-chat',
  templateUrl: './add-user-to-chat.component.html',
  styleUrl: './add-user-to-chat.component.css'
})
export class AddUserToChatComponent {
  users!:Utenti[]
  selected!: string;
  constructor(private UtenteSvc:UtentiService, private rottaAttiva: ActivatedRoute, private ChatSvc:ChatService) {
  }
  ngOnInit(){
    this.UtenteSvc.getAllUsers().subscribe(res=>{
      this.users = res.data
      console.log(this.users)
    })

  }

  addToChat() {
    this.rottaAttiva.params.subscribe((p) => {
      let identificativo = p['cd'];
      console.log(identificativo, this.selected)

      this.ChatSvc.InsertUserToChat(identificativo,this.selected).subscribe(res=>{
        console.log(res.data)
      })
    });
  }
}
