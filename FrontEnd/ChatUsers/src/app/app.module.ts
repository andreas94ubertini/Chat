import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './components/login/login/login.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ChatComponent } from './components/login/login/chat/chat.component';
import {ProfiloUtenteComponent} from "./components/profilo-utente/profilo-utente.component";

@NgModule({
  declarations: [AppComponent, LoginComponent, ChatComponent, ProfiloUtenteComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}