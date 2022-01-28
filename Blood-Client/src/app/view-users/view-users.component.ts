import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BloodTypeServiceService } from '../common/blood-type-service.service';
import { PatientModel } from '../models/patient.model';

@Component({
  selector: 'app-view-users',
  templateUrl: './view-users.component.html',
  styleUrls: ['./view-users.component.scss']
})
export class ViewUsersComponent implements OnInit {

  displayedColumns = ['name', 'email', 'phone', 'cnp', 'bloodType'];

  dataSource: PatientModel[] = [];

  constructor(private http: HttpClient, public bloodTypeService: BloodTypeServiceService) { 
    this.http.get<PatientModel[]>('https://localhost:44366/register/get-all').subscribe(
      (res) => { this.dataSource = res },
      (err) => console.log(err)
    )
  }

  ngOnInit(): void {
  }

}
