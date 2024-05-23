import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  userName : string ="";
  email: string = "";
  password: string="";
  phone: string="";


 constructor(private router:Router,private http:HttpClient){

 }

 save(){
  if (!this.userName || !this.email || !this.password || !this.phone) {
    alert("Please fill in all required fields.");
    return;
  }
   let bodyData={
     "name": this.userName,
     "email":this.email,
     "password":this.password,
     "phone":this.phone
   };
    this.http.post("https://localhost:7086/api/User",bodyData,{responseType: 'text'}).subscribe((resultData:any)=>
    {
      console.log(resultData);
      //if(resultData == "User Registration Successfull!!")
      //{
         alert("Registered successfully");
         this.router.navigateByUrl('login');
      //}
      //else
      //{
         //alert("User already Exists")
      //}
      // this.router.navigateByUrl('/booking');
    });

 }
}


