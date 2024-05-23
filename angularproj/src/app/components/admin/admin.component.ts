import { Component, inject } from '@angular/core';
import { HttpService } from '../../services/http.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { ITurf } from '../../interfaces/turf';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent {
  router = inject(Router);
  turfList: ITurf[] = [];
  httpService = inject(HttpService);
  //toaster = inject(ToastrService);
  displayedColumns: string[] = [
    'id',
    'name',
    'location',
    'avaliability',
    'action'
  ];
  ngOnInit() {
    this.getTurfFromServer();
 
  }
  navigateToAddTurf() {
    this.router.navigateByUrl('create-turf')
  }
    getTurfFromServer() {
      this.httpService.getAllTurf().subscribe((result) => {
        this.turfList = result;
        console.log(this.turfList);
        return this.turfList;
      });
    }
   
    edit(id: number) {
      console.log(id);
      this.router.navigateByUrl('/employee/' + id);
    }
    delete(id: number) {
      this.httpService.deleteTurf(id).subscribe(() => {
        console.log('deleted');
        // this.employeeList=this.employeeList.filter(x=>x.id!=id);
        this.getTurfFromServer();
        alert('Record deleted sucessfully');
      });
    }
  }
 
 
 


