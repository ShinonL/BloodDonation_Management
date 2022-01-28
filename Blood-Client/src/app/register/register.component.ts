import { HttpClient } from '@angular/common/http';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { BloodTypeServiceService } from '../common/blood-type-service.service';
import { BloodTypeModel } from '../models/bloodType.model';

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

  bloodTypes: BloodTypeModel[] = [];

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
      .get<BloodTypeModel[]>('https://localhost:44366/blood/getBloodTypes')
      .subscribe((res) => {
        this.bloodTypes = res;
      });
  }

  convertToString(bloodType: BloodTypeModel) {
    return this.bloodTypeService.convertToString(bloodType);
  }

  onRegister() {
    console.log(this.bloodTypeId);

    var user = {
      username : this.username.value,
      password : this.password.value,
      firstName : this.firstName.value,
      lastName : this.lastName .value,
      phone : this.phone.value,
      email : this.email.value,
      cnp : this.CNP.value,
      bloodId : this.bloodTypeId
    }

    this.http.post('https://localhost:44366/register/create', user)
      .subscribe(
        (res) => {
          sessionStorage.setItem('username', this.username.value);
          sessionStorage.setItem('password', this.password.value);
        }, 
        (err) => console.log(err)
      );
  }
}
