import { Component } from '@angular/core';
import {ChatService} from "../../services/chat.service";
import {Router} from "@angular/router";
import {log} from "@angular-devkit/build-angular/src/builders/ssr-dev-server";

@Component({
  selector: 'app-create-chat-room',
  templateUrl: './create-chat-room.component.html',
  styleUrl: './create-chat-room.component.css'
})
export class CreateChatRoomComponent {
  roN!:string;
  des!:string;
  constructor(private ChatSvc:ChatService, private router:Router) {

  }

  create() {
    this.ChatSvc.CreateChatRoom(this.roN,this.des).subscribe(res=>
    {
      console.log(res.data)
      this.router.navigateByUrl("/profilo")
    })
  }
}
