import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddBloodtestComponent } from '../add-bloodtest/add-bloodtest.component';
import { BloodTypeServiceService } from '../common/blood-type-service.service';
import { AppointmentModel } from '../models/appointment.model';
import { BloodTypeModel } from '../models/bloodType.model';
import { StaffModel } from '../models/staff.model';
import { RegisterStaffComponent } from '../register-staff/register-staff.component';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {
  unconfirmed: AppointmentModel[] = [];
  confirmed: AppointmentModel[] = [];
  staff: StaffModel[] = [];
  displayedColumns = ['name', 'role', 'hospital', 'phone', 'actions'];

  constructor(private http: HttpClient, public bloodTypeService: BloodTypeServiceService, private dialog: MatDialog) { }

  ngOnInit(): void {
    if (this.getSessionRole() == 'Nurse' || this.getSessionRole() == 'Doctor') {
      this.http.get<AppointmentModel[]>('https://localhost:44366/hospital/get-unconfirmed-appointments/' + sessionStorage.getItem('userId'))
        .subscribe((res) => {
          res.forEach(element => {
            this.unconfirmed.push(element);
          });
        });

      this.http.get<AppointmentModel[]>('https://localhost:44366/hospital/get-confirmed-appointments/' + sessionStorage.getItem('userId'))
        .subscribe((res) => {
          res.forEach(element => {
            this.confirmed.push(element);
          });
        });
    } else if (this.getSessionRole() == 'Administrator') {
      this.http.get<StaffModel[]>('https://localhost:44366/hospital/get-staff')
        .subscribe((res) => {
          this.staff = res;
          });
    }
  }

  getSessionRole() {
    return sessionStorage.getItem('role');
  }

  convertToString(bloodType: BloodTypeModel) {
    return this.bloodTypeService.convertToString(bloodType);
  }

  onConfirm(id: number) {
    this.http.post('https://localhost:44366/hospital/confirm-appointment', id)
      .subscribe(() => location.reload());
  }

  onAdd(id: number) {
    const dialogRef = this.dialog.open(AddBloodtestComponent, {data : {appId: id}});

    dialogRef.afterClosed().subscribe(() => {
      location.reload();
    });
  }

  onRegisterStaff() {
    const dialogRef = this.dialog.open(RegisterStaffComponent);

    dialogRef.afterClosed().subscribe(() => {
      location.reload();
    });
  }

  onDelete(id: number) {
    this.http.get('https://localhost:44366/hospital/delete/' + id).subscribe(
      () => location.reload()
    )
  }
}
