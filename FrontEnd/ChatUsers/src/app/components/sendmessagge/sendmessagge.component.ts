import { Component } from '@angular/core';
import { SendmessageService } from '../../services/sendmessage.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-sendmessagge',
  templateUrl: './sendmessagge.component.html',
  styleUrl: './sendmessagge.component.css',
})
export class SendmessaggeComponent {
  messageContent: string = '';
  identificativo!: string;
  constructor(
    private messageService: SendmessageService,
    private router: Router,
    private rottaAttiva: ActivatedRoute
  ) {}
  ngOnInit(): void {
    this.rottaAttiva.params.subscribe((p) => {
      this.identificativo = p['cd'];
    });
  }

  sendMessage() {

    this.messageService
      .sendMessage(this.identificativo, this.messageContent)
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
