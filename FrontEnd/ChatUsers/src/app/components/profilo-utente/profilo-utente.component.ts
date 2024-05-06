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
  img!: string;
  constructor(private profileSvc:UtentiService, private router:Router) {
    if(!localStorage.getItem("ilToken")){
      this.router.navigateByUrl("")
    }

  }
  ngOnInit(){
    this.getProfile()
  }

  LogOut() {
    localStorage.removeItem("ilToken")
    this.router.navigateByUrl("")
  }

getProfile(){
    this.profileSvc.recuperaProfilo().subscribe(res=>{
        this.user=res.data;
        console.log(this.user)
        console.log(this.user?.pI)
    })
}

  changeImg() {
    this.user!.pI = this.img
    this.profileSvc.modifyImg(this.user!).subscribe(res=>{
      console.log(res.status)
    })

  }

  protected readonly localStorage = localStorage;
}
