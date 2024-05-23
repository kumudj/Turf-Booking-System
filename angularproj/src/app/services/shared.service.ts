// import { Injectable } from '@angular/core';

// @Injectable({
//   providedIn: 'root'
// })
// export class SharedService {

//   constructor() { }
// }
import { Injectable } from '@angular/core';
 
@Injectable({
 providedIn: 'root'
})
export class SharedService {
 private userId: number = 0;
 private turfId: number = 0;
 
 constructor() { }
 
 setUserId(userId: number): void {
    this.userId = userId;
 }
 
 getUserId(): number {
    return this.userId;
 }
 
 setTurfId(turfId: number): void {
    this.turfId = turfId;
 }
 
 getTurfId(): number {
    return this.turfId;
 }
}