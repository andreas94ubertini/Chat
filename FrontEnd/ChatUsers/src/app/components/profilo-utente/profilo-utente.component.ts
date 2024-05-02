import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {UtentiService} from "../../services/utenti.service";
import {Utenti} from "../../models/utenti";
import {Router} from "@angular/router";

@Component({
  selector: 'app-profilo-utente',
  templateUrl: './profilo-utente.component.html',
  styleUrl: './profilo-utente.component.css'
})
export class ProfiloUtenteComponent {

  user: Utenti | undefined;
  constructor(private profileSvc:UtentiService, private router:Router) {
    if(!localStorage.getItem("ilToken")){
      this.router.navigateByUrl("")
    }
  }
  ngOnInit(){
    this.profileSvc.recuperaProfilo().subscribe(res=>{
      this.user=res.data;
    })
  }

  LogOut() {
    localStorage.removeItem("ilToken")
    this.router.navigateByUrl("")
  }
}
