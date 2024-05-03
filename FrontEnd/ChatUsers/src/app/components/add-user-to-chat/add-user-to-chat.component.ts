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
  allUser!:Utenti[];
  selected!: string;
  roomId!:string
  constructor(private UtenteSvc:UtentiService, private rottaAttiva: ActivatedRoute, private ChatSvc:ChatService) {
  }
  ngOnInit(){
    this.rottaAttiva.params.subscribe((p) => {
      this.roomId = p['cd'];
    });
    this.UtenteSvc.getAllUsers().subscribe(res=>{
      this.allUser = res.data;
    })

  }


  convertToString(lista:Utenti[]):string[]{
    let listaus:string[]= [];
    for (let i:number = 0; i<this.allUser.length;i++){
      listaus.push(this.allUser[i].us!)
    }
    return listaus;
  }

  addToChat() {

      this.ChatSvc.InsertUserToChat(this.roomId,this.selected).subscribe(res=>{
        console.log(res.data)
      })

  }
}
