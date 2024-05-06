import { Component } from '@angular/core';
import { AuthserviceService } from '../../services/authservice.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  username: string = '';
  password: string = '';
  agree!: boolean;
  constructor(private service: AuthserviceService, private router: Router) {}

  registrazione(): void {
    this.service
      .registra(this.username, this.password)
      .subscribe((risultato) => {
        this.service.login(this.username, this.password).subscribe(res=>{
          if (res.token) {
            localStorage.setItem('ilToken', res.token);
            this.router.navigateByUrl("/profilo")
          }
        });
      });
  }
}
