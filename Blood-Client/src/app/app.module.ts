import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient, HttpClientModule } from '@angular/common/http'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input'
import { MatSelectModule } from '@angular/material/select';
import {MatTableModule} from '@angular/material/table';
import { MatTimepickerModule } from 'mat-timepicker';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatCardModule} from '@angular/material/card';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatListModule} from '@angular/material/list';
import {MatDividerModule} from '@angular/material/divider';

import { HomePageComponent } from './home-page/home-page.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { BloodStocksComponent } from './blood-stocks/blood-stocks.component';
import { DonateComponent } from './donate/donate.component';
import { AppointmentsComponent } from './appointments/appointments.component';
import { RequestComponent } from './request/request.component';
import { ManageRequestComponent } from './manage-request/manage-request.component';
import { ViewUsersComponent } from './view-users/view-users.component';
import { AddBloodtestComponent } from './add-bloodtest/add-bloodtest.component';
import { ViewBloodtestComponent } from './view-bloodtest/view-bloodtest.component';
import { ViewRequestsComponent } from './view-requests/view-requests.component';
import { RegisterStaffComponent } from './register-staff/register-staff.component';


const MaterialModules = [
  MatDatepickerModule,
  MatTimepickerModule,
  MatNativeDateModule,
  MatIconModule,
  MatToolbarModule,
  MatButtonModule,
  MatDialogModule,
  MatSelectModule,
  MatInputModule,
  MatFormFieldModule,
  MatTableModule,
  MatCardModule,
  MatGridListModule,
  MatListModule,
  FlexLayoutModule,
  MatDividerModule
]

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    LoginComponent,
    RegisterComponent,
    BloodStocksComponent,
    DonateComponent,
    AppointmentsComponent,
    RequestComponent,
    ManageRequestComponent,
    ViewUsersComponent,
    AddBloodtestComponent,
    ViewBloodtestComponent,
    ViewRequestsComponent,
    RegisterStaffComponent
  ],
  imports: [
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialModules,
    MatCheckboxModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [MaterialModules]
})
export class AppModule { }
