import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UtentiService {
  base_url: string = 'https://localhost:5297/utenti';
  constructor(private http: HttpClient) {}
}
