import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login/login.component';
import { ChatComponent } from './components/chat/chat.component';
import { ProfiloUtenteComponent } from './components/profilo-utente/profilo-utente.component';
import { RegisterComponent } from './components/register/register.component';
import {CreateChatRoomComponent} from "./components/create-chat-room/create-chat-room.component";

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'chat/:cd', component: ChatComponent },
  { path: 'profilo', component: ProfiloUtenteComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'createNewRoom', component: CreateChatRoomComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
