import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login/login.component';
import { ChatComponent } from './components/login/login/chat/chat.component';
import {ProfiloUtenteComponent} from "./components/profilo-utente/profilo-utente.component";

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'chat/:cd', component: ChatComponent },
  { path: 'profilo', component: ProfiloUtenteComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
