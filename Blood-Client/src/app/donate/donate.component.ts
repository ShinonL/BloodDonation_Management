import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HospitalModel } from '../models/hospital.model';

@Component({
  selector: 'app-donate',
  templateUrl: './donate.component.html',
  styleUrls: ['./donate.component.scss']
})
export class DonateComponent implements OnInit {
  hospitals : HospitalModel[] = [];
  hospitalId : string = '';
  date: FormControl;

  defaultValue= {hour: 13, minute: 30};

  startDateFilter = (date: Date | null): boolean => {
    const startDate = date || new Date();
    return startDate >= new Date();
  };

  timeChangeHandler(event: Event) {
    console.log(event);
  }

  constructor(private http: HttpClient, 
    @Inject(MAT_DIALOG_DATA) public data: { req: number }) { 
    this.date = new FormControl('', Validators.required)
  }

  ngOnInit(): void {
    this.http.get<HospitalModel[]>('https://localhost:44366/hospital/get-all').subscribe(
      (res) => {this.hospitals = res},
      (err) => console.log(err)
    )
  }

  onRegister() {
    var appDate = new Date(this.date.value);
    appDate.setHours(this.defaultValue.hour + 3);
    appDate.setMinutes(this.defaultValue.minute);

    var num: number = +(sessionStorage.getItem('userId') ?? 0);

    var appointment = {
      userId: num,
      appointmentDe: appDate,
      hospital: {
        id: this.hospitalId
      }
    };

    if (this.data.req == 0) {
      this.http.post('https://localhost:44366/hospital/create-appointment', appointment).subscribe(
        (res) => {},
        (err) => console.log(err)
      )
    } else {
      this.http.post('https://localhost:44366/hospital/create-app/' + this.data.req, appointment).subscribe(
        (res) => {},
        (err) => console.log(err)
      )
    }
  }
}
