import { Component,inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedService } from '../../services/shared.service';
import { HttpService } from '../../services/http.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule } from '@angular/material/core';
import { ActivatedRoute, Router } from '@angular/router';
import { response } from 'express';
import { CommonModule } from '@angular/common';
@Component({
 selector: 'app-date-range',
 templateUrl: './bookings.component.html',
 styleUrls: ['./bookings.component.css'],
//  standalone:true,
//  imports:[ReactiveFormsModule,MatFormFieldModule,MatInputModule,MatSelectModule,MatDatepickerModule,MatNativeDateModule,MatButtonModule,MatOptionModule,FormsModule,CommonModule]
 
 
})
export class BookingsComponent implements OnInit {
   userId!: number ;
   turfId!: any;
   blogId?:any;
   date:any;
   timeSlots: string[] = [];
   constructor(private route:ActivatedRoute){}
   router = inject(Router);
   httpService = inject(HttpService);
   sharedService = inject(SharedService);
   dateRangeForm = new FormGroup({
      fromDate: new FormControl(''),
      // fromTime: new FormControl(''),
      // toDate: new FormControl(''),
      // toTime: new FormControl('')
   });
 
   ngOnInit() {
      // Generate time slots for the day
      this.getAllSlots();
      const id=this.route.snapshot.paramMap.get('id');
      this.turfId=id;
     
     
      this.userId = Number(localStorage.getItem("userId"));
   
      console.log(this.turfId);
      console.log(this.userId);
     
   }
   slots:any=[];
   getAllSlots(){
      this.httpService.getSlots().subscribe((res:any)=>{
         console.log(res);
        this.slots=res;
      })
   }
 
   onSubmit() {
      const userid = this.userId;
      const turfId = this.turfId;
      const slotId=this.blogId;
      console.log("slotId=>"+slotId);
      console.log("date=>"+this.date);
      console.log("userId=>"+this.userId);
      console.log("turfId=>"+this.turfId);
 
   
   const IBooking = {
     date: this.date,
     slotId:slotId,
     userId: userid,
     turfId: turfId
   };
 
   console.log(IBooking);
   this.httpService.createBooking(IBooking).subscribe(response => {
       alert("Slot Booked successfully");
      },(error)=>{
         if(error.status==400){
            alert("Slot Already booked");
         }
      });
   
   this.router.navigateByUrl('/turflist');
}
 
}

