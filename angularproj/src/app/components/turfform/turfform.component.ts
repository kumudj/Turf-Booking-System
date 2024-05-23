import { Component ,inject } from '@angular/core';
import { HttpService } from '../../services/http.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { ITurf } from '../../interfaces/turf';



@Component({
  selector: 'app-turfform',
  templateUrl: './turfform.component.html',
  styleUrl: './turfform.component.css'
})
export class TurfformComponent {
  formBuilder = inject(FormBuilder);
  httpService = inject(HttpService);
  router = inject(Router);
  route = inject(ActivatedRoute);
  //toaster=inject(ToastrService);
  employeeForm = this.formBuilder.group({
    id:[0],
    name: ['', [Validators.required]],
    location: ['', [Validators.required]],
    availability: ['', []],
  });
  id!: number;
  isEdit = false;
  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    if (this.id) {
      this.isEdit = true;
      this.httpService.getTurf(this.id).subscribe((result) => {
        console.log(result);
        this.employeeForm.patchValue(result);
      });
    }
  }
  save() {
    console.log(this.employeeForm.value);
    const employee: ITurf = {
      name: this.employeeForm.value.name!,
      location: this.employeeForm.value.location!,
      availability: this.employeeForm.value.availability!,
      id: 0
    };
    if (this.isEdit) {
      this.httpService
        .updateTurf(this.id, employee)
        .subscribe(() => {
          console.log('success');
          alert("Record updated sucessfully.");
          this.router.navigateByUrl('admin');
        },);
    } else {
      this.httpService.createTurf(employee).subscribe(() => {
        console.log('success');
        alert("Record added sucessfully.");
        this.router.navigateByUrl('admin');
      });
    }
  }
}




