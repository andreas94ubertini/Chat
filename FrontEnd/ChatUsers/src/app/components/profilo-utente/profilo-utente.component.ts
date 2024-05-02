import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {UtentiService} from "../../services/utenti.service";

@Component({
  selector: 'app-profilo-utente',
  templateUrl: './profilo-utente.component.html',
  styleUrl: './profilo-utente.component.css'
})
export class ProfiloUtenteComponent {
  constructor(private profileSvc:UtentiService) {
  }
  ngOnInit(){
    this.profileSvc.recuperaProfilo().subscribe(res=>{
      console.log(res.data)
    })
  }
}
