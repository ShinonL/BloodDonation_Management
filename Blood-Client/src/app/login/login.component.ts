import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { RegisterComponent } from '../register/register.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  username: FormControl;
  password: FormControl;

  constructor(private dialog: MatDialog) {
    this.username = new FormControl('', Validators.required);
    this.password = new FormControl('', Validators.required);
  }

  ngOnInit(): void {
  }
}
