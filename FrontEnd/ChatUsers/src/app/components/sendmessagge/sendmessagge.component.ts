import { Component } from '@angular/core';
import { SendmessageService } from '../../services/sendmessage.service';
import { ActivatedRoute, Router } from '@angular/router';
import {UtentiService} from "../../services/utenti.service";
import {Utenti} from "../../models/utenti";

@Component({
  selector: 'app-sendmessagge',
  templateUrl: './sendmessagge.component.html',
  styleUrl: './sendmessagge.component.css',
})
export class SendmessaggeComponent {
  messageContent: string = '';
  identificativo!: string;
  currentUser!:Utenti;
  constructor(
    private messageService: SendmessageService,
    private router: Router,
    private rottaAttiva: ActivatedRoute,
    private UtenteSvc : UtentiService
  ) {}
  ngOnInit(): void {
    this.rottaAttiva.params.subscribe((p) => {
      this.identificativo = p['cd'];
    });
    this.UtenteSvc.recuperaProfilo().subscribe(res=>{
      this.currentUser = res.data;
    })
  }

  sendMessage() {

    this.messageService
      .sendMessage(this.identificativo, this.messageContent, this.currentUser.pi!)
      .subscribe(
        (response) => {
          console.log('Messaggio inviato con successo:', response);
        },
        (error) => {
          console.error("Errore durante l'invio del messaggio:", error);
        }
      );
    this.messageContent = '';
  }
}
