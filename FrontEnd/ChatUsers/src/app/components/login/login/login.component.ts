import { Component } from '@angular/core';
import { AuthserviceService } from '../../../services/authservice.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private service: AuthserviceService, private router: Router) {
    if(localStorage.getItem("ilToken"))
      router.navigateByUrl("/profilo")
  }

  verifica(): void {
    this.service.login(this.username, this.password).subscribe((risultato) => {
      if (risultato.token) {
        localStorage.setItem('ilToken', risultato.token);
        this.router.navigateByUrl("/profilo")
      }
    });
  }
}
