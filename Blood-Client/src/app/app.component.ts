import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { DonateComponent } from './donate/donate.component';
import { RequestComponent } from './request/request.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private router: Router, public dialog: MatDialog) {}

  title = 'Blood-Client';
  
  openLoginDialog() {
    const dialogRef = this.dialog.open(LoginComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result == 'register')
        this.dialog.open(RegisterComponent);
    });
  }

  onLogout() {
    sessionStorage.removeItem('userId');
    sessionStorage.removeItem('role');

    this.router.navigateByUrl("/home");
  }

  getSessionRole() {
    return sessionStorage.getItem('role');
  }

  getSession() {
    return sessionStorage.getItem('userId') == undefined;
  }

  onDonate() {
    const dialogRef = this.dialog.open(DonateComponent, {data: {req: 0}});
  }

  onAppointment() {
    this.router.navigateByUrl("/appointments");
  }

  onManageRequest() {
    this.router.navigateByUrl("/manage-requests");
  }

  onViewUsers() {
    this.router.navigateByUrl("/view-users");
  }

  onRequest() {
    this.router.navigateByUrl("/view-requests");
  }
}
