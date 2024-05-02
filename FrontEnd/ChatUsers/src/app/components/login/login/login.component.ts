import { Component } from '@angular/core';
import { AuthserviceService } from '../../../services/authservice.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  user: string = '';
  pass: string = '';

  constructor(private service: AuthserviceService, private router: Router) {}

  verifica(): void {
    this.service.login(this.user, this.pass).subscribe((risultato) => {
      if (risultato.token) {
        localStorage.setItem('ilToken', risultato.token);
        this.router.navigateByUrl('/profilo');
      }
    });
  }
}
