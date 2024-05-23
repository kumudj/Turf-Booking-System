// import { HttpClient } from '@angular/common/http';
// import { Component, OnInit } from '@angular/core';
// import { Router } from '@angular/router';
// import { FormsModule } from '@angular/forms';

// @Component({
//   selector: 'app-login',
//   templateUrl: './login.component.html',
//   styleUrl: './login.component.css'
// })
// export class LoginComponent implements OnInit {
//   email : string ="";
//   password: string="";
 
//   adminlogin()
//   {
//       this.router.navigateByUrl('/adminlogin');
//   }
 
//   constructor(private router:Router ,private http:HttpClient) { }
 
//   ngOnInit(): void {
//   }
 
//   login()
//   {
//     let bodyData={
//     "email": this.email,
//     "password":this.password
//     };
//    this.http.post("https://localhost:7086/api/User/Login",bodyData,{responseType: 'text'}).subscribe((resultData:any)=>
//    {
//      console.log(resultData);
     
    

//      if(resultData=="Invalid Username or password or Token ID is null")
//      {
//       alert('Invalid Password or email');
//      }
//      else{
     
//       console.log(resultData);
//       alert('Logged In');
//       this.router.navigate(['/turflist']);
//     }
     
     
//     });
//   }
 
 
// }

import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpService } from '../../services/http.service';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { SharedService } from '../../services/shared.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginForm = this.builder.group({
    email: ['', Validators.required],
    password: ['', Validators.required],
  });
  showUnauthorizedMessage = false;

  constructor(
    private builder: FormBuilder,
    private httpService: HttpService,
    private router: Router,
    private authService: AuthService,
    private sharedService: SharedService
  ) {
    this.authService.unauthorized$.subscribe(() => {
      this.showUnauthorizedMessage = true;
      alert('Invalid username and password');
    });
  }

  loginUser(userId: number) {
    this.sharedService.setUserId(userId);
    // Navigate to the main page or perform other actions
  }

  onLogin() {
    const email = this.loginForm.value.email!;
    const password = this.loginForm.value.password!;
    this.httpService.login(email, password).subscribe(
      (response) => {
        console.log('Login successful:', response.body?.role);
        localStorage.setItem('token', String(response.body?.token));
        alert('Successfully Logged In');
        this.loginUser(Number(response.body?.id));
        localStorage.setItem("userId",response.body?.id)
        this.router.navigateByUrl('/turflist');
        if (response.body?.role === "Admin") {
          this.router.navigateByUrl('/admin');
        } else {
          this.router.navigateByUrl('/turflist');
        }
      },
      (error) => {
        console.error('Login failed:', error);
        alert('Invalid username and password');
      }
    );
  }
}
