import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Turf } from '../models/turflist';

@Injectable({
  providedIn: 'root'
})
export class TurfsService {
  private apiUrl = 'https://localhost:7086/api/Turf';

  constructor(private http: HttpClient) { }

  getTurfs(): Observable<Turf[]> {
    return this.http.get<Turf[]>(this.apiUrl);
  }
}