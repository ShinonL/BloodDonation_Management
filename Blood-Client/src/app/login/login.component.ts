import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { UserModel } from '../models/user.model';
import { RegisterComponent } from '../register/register.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  username: FormControl;
  password: FormControl;

  constructor(private dialog: MatDialog, private http: HttpClient) {
    this.username = new FormControl('', Validators.required);
    this.password = new FormControl('', Validators.required);
  }

  ngOnInit(): void {
  }

  onLogin() {
    var user = {
      username: this.username.value,
      password: this.password.value
    }

    this.http.post<UserModel>('https://localhost:44366/register/get-id', user).subscribe(
      (res) => {
        sessionStorage.setItem('userId', JSON.stringify(res.id));
        sessionStorage.setItem('role', res.role);
        location.reload();
      },
      (err) => console.log(err)
    )
  }
}
