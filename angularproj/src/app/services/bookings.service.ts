import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class BookingsService {

  private apiUrl = 'https://localhost:7086/api/Booking'; // Replace with your API URL

  constructor(private http: HttpClient) { }

  createBooking(booking: any): Observable<any> {
    return this.http.post(`${this.apiUrl}`, booking);

  }
}
