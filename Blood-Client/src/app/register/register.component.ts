import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { BloodTypeServiceService } from '../common/blood-type-service.service';
import { BloodType } from '../models/BloodType';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  username: FormControl;
  password: FormControl;
  firstName: FormControl;
  lastName: FormControl;
  phone: FormControl;
  email: FormControl;
  CNP: FormControl;
  bloodTypeId: string = '';

  bloodTypes: BloodType[] = [];

  constructor(private http: HttpClient, public bloodTypeService: BloodTypeServiceService) {
    this.username = new FormControl('', Validators.required);
    this.password = new FormControl('', Validators.required);
    this.firstName = new FormControl('', Validators.required);
    this.lastName = new FormControl('', Validators.required);
    this.phone = new FormControl('', Validators.required);
    this.email = new FormControl('', Validators.required);
    this.CNP = new FormControl('', Validators.required);
  }

  ngOnInit(): void {
    this.http
      .get<BloodType[]>('https://localhost:44366/register/getBloodTypes')
      .subscribe((res) => {
        this.bloodTypes = res;
      });
  }

  convertToString(bloodType: BloodType) {
    return this.bloodTypeService.convertToString(bloodType);
  }
}
