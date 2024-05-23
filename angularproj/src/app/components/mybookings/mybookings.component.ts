import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../services/http.service';

@Component({
  selector: 'app-my-bookings',
  templateUrl: './my-bookings.component.html',
  styleUrls: ['./my-bookings.component.css']
})
export class MyBookingsComponent implements OnInit {
  bookings: any[] = [];


  constructor(private httpService: HttpService) { }

  ngOnInit() {
    const userId = localStorage.getItem('userId');
    this.fetchUserBookings(userId);
  }

  fetchUserBookings(userId: number) {
    this.httpService.getUserBookings(userId).subscribe(
      bookings => {
        this.bookings = bookings;
      },
      error => {
        console.error('Error fetching user bookings:', error);
      }
    );
  }
}