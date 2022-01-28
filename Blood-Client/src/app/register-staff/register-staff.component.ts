import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { HospitalModel } from '../models/hospital.model';
import { AuthorizationModel } from '../models/role.model';

@Component({
  selector: 'app-register-staff',
  templateUrl: './register-staff.component.html',
  styleUrls: ['./register-staff.component.scss']
})
export class RegisterStaffComponent implements OnInit {
  username: FormControl;
  password: FormControl;
  firstName: FormControl;
  lastName: FormControl;
  phone: FormControl;
  hospitalId: string = '';
  roleId: string = '';

  hosppitals: HospitalModel[] = [];
  roles: AuthorizationModel[] = [];

  constructor(private http: HttpClient) {
    this.username = new FormControl('', Validators.required);
    this.password = new FormControl('', Validators.required);
    this.firstName = new FormControl('', Validators.required);
    this.lastName = new FormControl('', Validators.required);
    this.phone = new FormControl('', Validators.required);
  }

  ngOnInit(): void {
    this.http
      .get<HospitalModel[]>('https://localhost:44366/hospital/get-all')
      .subscribe((res) => {
        this.hosppitals = res;
      });

      this.http
      .get<AuthorizationModel[]>('https://localhost:44366/hospital/get-roles')
      .subscribe((res) => {
        this.roles = res;
      });
  }

  onRegister() {
    var user = {
      username : this.username.value,
      password : this.password.value,
      firstName : this.firstName.value,
      lastName : this.lastName .value,
      phoneNumber : this.phone.value,
      authorizationId : this.roleId,
      hospitalId : this.hospitalId
    }

    this.http.post('https://localhost:44366/hospital/create-staff', user)
      .subscribe( () => location.reload()
      );
  }

}
