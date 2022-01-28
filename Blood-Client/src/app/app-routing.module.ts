import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppointmentsComponent } from './appointments/appointments.component';
import { BloodStocksComponent } from './blood-stocks/blood-stocks.component';
import { DonateComponent } from './donate/donate.component';

import { HomePageComponent } from './home-page/home-page.component';
import { ManageRequestComponent } from './manage-request/manage-request.component';
import { ViewRequestsComponent } from './view-requests/view-requests.component';
import { ViewUsersComponent } from './view-users/view-users.component';

const routes: Routes = [
  {
    path: "",
    redirectTo: '/home', 
    pathMatch: 'full'
  },
  {
    path: "home",
    pathMatch: 'full',
    component: HomePageComponent
  },
  {
    path: "bloodStocks",
    pathMatch: "full",
    component: BloodStocksComponent
  },
  {
    path: "appointments",
    pathMatch: "full",
    component: AppointmentsComponent
  }, 
  {
    path: "manage-requests",
    pathMatch: "full",
    component: ManageRequestComponent
  }, 
  {
    path: "view-users",
    pathMatch: "full",
    component: ViewUsersComponent
  }, 
  {
    path: "view-requests",
    pathMatch: "full",
    component: ViewRequestsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
