// import { Injectable } from '@angular/core';

// @Injectable({
//   providedIn: 'root'
// })
// export class AuthService {

//   constructor() { }
// }
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
 
@Injectable({
 providedIn: 'root'
})
export class AuthService {
 private unauthorizedSource = new Subject<void>();
 unauthorized$ = this.unauthorizedSource.asObservable();
 
 constructor() { }
 
 triggerUnauthorized() {
    this.unauthorizedSource.next();
 }
}
