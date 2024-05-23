import { Component , OnInit} from '@angular/core';
import { TurfsService } from '../../services/turfs.service';
import { Turf } from '../../models/turflist';
import { Router } from '@angular/router';
import { SharedService } from '../../services/shared.service';
import { inject } from '@angular/core';

@Component({
  selector: 'app-turflist',
  templateUrl: './turflist.component.html',
  styleUrl: './turflist.component.css'
})
export class TurflistComponent implements OnInit{
  sharedservice= inject(SharedService);
  turfs: Turf[] = [];
  turfId: number=0;

  constructor(private turfService: TurfsService,private router:Router) { }

  ngOnInit(): void {
    this.getTurfs();
  }

  getTurfs(): void {
    this.turfService.getTurfs()
      .subscribe(
        turfsData => {
          this.turfs = turfsData.map(turfData => new Turf(turfData));
        },
        error => {
          console.error('Error fetching turfs:', error);
          // Handle error if needed
        }
      );
  }
//   bookTurf(turfId: number): void {
  
//     console.log(`Booking turf with ID: ${turfId}`);
//     this.sharedservice.setTurfId(turfId);
//     console.log('turfid ${this.sharedservice.getTurfId()}');
//     this.router.navigate(['/bookings'], { queryParams: { turfId: turfId } });
// }
bookTurf(turfId: number): void {
  console.log(`Booking turf with ID: ${turfId}`);
  this.sharedservice.setTurfId(turfId);
  console.log(`turfid ${this.sharedservice.getTurfId()}`);
  this.router.navigate(['/bookings', turfId]);
}

showUnavailableAlert(): void {
  alert('Turf is not available');
}
}
