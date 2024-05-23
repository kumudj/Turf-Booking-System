// import { Injectable } from '@angular/core';

// @Injectable({
//   providedIn: 'root'
// })
// export class HttpService {

//   constructor() { }
// }
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ITurf } from '../interfaces/turf';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { IBooking } from '../interfaces/booking';
import { DatePipe } from '@angular/common';
import { SharedService } from './shared.service';

 
 
@Injectable({
  providedIn: 'root',
})
export class HttpService {
  apiUrl = 'https://localhost:7108';
  http = inject(HttpClient);
  constructor(private sharedService:SharedService) {}

  createBooking(book:IBooking){
    return this.http.post(this.apiUrl + '/api/Booking',book);
  }
  getSlots(){
    return this.http.get(this.apiUrl + '/api/Slot');
  }
  getAllTurf() {
    //console.log('getAllEmployee', localStorage.getItem('token'));
    return this.http.get<ITurf[]>(this.apiUrl + '/api/Turf');
  }
  createTurf(turf: ITurf) {
    return this.http.post(this.apiUrl + '/api/Turf', turf);
  }
  getTurf(turfId: number) {
    return this.http.get<ITurf>(
      this.apiUrl + '/api/Turf/' + turfId
    );
  }
  updateTurf(turfId: number, turf: ITurf) {
    // Ensure the employee object has an availability property
    // The employee object should be structured like this:
    // { availability: false }
    const availability = turf.availability === 'true' ? true : false;
    return this.http.put<ITurf>(
     
       `${this.apiUrl}/api/Turf/${turfId}`,
       { availability: availability} // This is the request body
    );
   }
   
  deleteTurf(turfId: number) {
    return this.http.delete(this.apiUrl + '/api/Turf/' + turfId);
  }
  getUserBookings(userId: number): Observable<any[]> {
    const url = `${this.apiUrl}/api/Booking/user/${userId}`;
    return this.http.get<any[]>(url);
  }
  // http.service.ts
  getTurfName(turfId: number): Observable<string> {
  return this.http.get<string>(`${this.apiUrl}/api/Turfs/${turfId}/name`);
  } 
  // deleteBooking(bookingId: number): Observable<void> {
  //   const url = `${this.apiUrl}/api/bookings/${bookingId}`;
  //   return this.http.delete<void>(url);
  // }
  deleteBooking(bookingId: number) {
    return this.http.delete(this.apiUrl + '/api/Booking/' + bookingId);
  }


  login(email: string, password: string): Observable<HttpResponse<{ UserName: string; id: any; token: string;role:string }>> {
    return this.http.post<{ UserName: string; id:number; token: string ;role:string}>(this.apiUrl + '/api/User/login', {
       email: email,
       password: password,
    }, { observe: 'response' }).pipe(
       catchError(error => {
         // Handle the error here
         console.error('Login error:', error);
         // You can rethrow the error if you want to handle it further up the chain
         return throwError(error);
       })
    );
   }
  //  checkAvailability(turfId: number, date: Date, fromTime: Date, toTime: Date): Observable<boolean> {
  //   const url = `${this.apiUrl}/api/Booking/check-availability`;
  //   const body = {
  //     turfId,
  //     date: date.toISOString().split('T')[0], 
  //     fromTime: fromTime.toTimeString().slice(0, 5), 
  //     toTime: toTime.toTimeString().slice(0, 5) 
  //   };
  //   return this.http.post<boolean>(url, body);
  // }
  checkAvailability(turfId: number, formattedBookingDate: string, startTime: string, endTime: string): Observable<boolean> {
    const url = `${this.apiUrl}/api/Booking/check-availability`;
    const body = { turfId, date: formattedBookingDate, startTime, endTime };
    return this.http.post<boolean>(url, body);
  }
}
   
   
  /*googleLogin(idToken: string) {
    return this.http.post<{ token: string }>(
      this.apiUrl + '/api/Auth/google-login',
      {
        idToken: idToken,
      }
    );
  }*/

 