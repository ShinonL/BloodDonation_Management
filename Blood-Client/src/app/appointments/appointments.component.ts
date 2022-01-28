import { HttpClient } from '@angular/common/http';
import { COMPILER_OPTIONS, Component, OnInit } from '@angular/core';
import { AppointmentModel } from '../models/appointment.model';
import { DatePipe } from '@angular/common';
import { BloodTestModel } from '../models/bloodTest.model';
import { MatDialog } from '@angular/material/dialog';
import { ViewBloodtestComponent } from '../view-bloodtest/view-bloodtest.component';

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.scss'],
})
export class AppointmentsComponent implements OnInit {

  dataSource: AppointmentModel[] = [];
  displayedColumns = ['name', 'date', 'confirmed', 'actions']

  constructor(private http: HttpClient, private dialog: MatDialog) { 
    this.http.get<AppointmentModel[]>('https://localhost:44366/hospital/get-appointments/' + sessionStorage.getItem('userId')).subscribe(
      (res) => { this.dataSource = res },
      (err) => console.log(err)
    )
  }

  ngOnInit(): void {
  }

  openDialog(bloodTest: BloodTestModel) {
    this.dialog.open(ViewBloodtestComponent, {data: {bloodTest: bloodTest}});
  }
}
