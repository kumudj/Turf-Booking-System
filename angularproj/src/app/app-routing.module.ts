import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { TurflistComponent } from './components/turflist/turflist.component';
import { BookingsComponent } from './components/bookings/bookings.component';
import { AdminComponent } from './components/admin/admin.component';
import { TurfformComponent } from './components/turfform/turfform.component';
//import { MybookingsComponent } from './components/mybookings/mybookings.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'turflist',component: TurflistComponent},
  { path: 'bookings/:id', component: BookingsComponent },
  { path: 'admin' ,component: AdminComponent},
  { path: 'create-turf',component:TurfformComponent},
  { path: 'employee/:id',component:TurfformComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
