import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './components/login/login/login.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ChatComponent } from './components/chat/chat.component';
import { ProfiloUtenteComponent } from './components/profilo-utente/profilo-utente.component';
import { SendmessaggeComponent } from './components/sendmessagge/sendmessagge.component';
import { RegisterComponent } from './components/register/register.component';
import { CreateChatRoomComponent } from './components/create-chat-room/create-chat-room.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ChatComponent,
    ProfiloUtenteComponent,
    SendmessaggeComponent,
    RegisterComponent,
    CreateChatRoomComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
