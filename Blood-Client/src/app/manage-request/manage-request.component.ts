import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { BloodTypeServiceService } from '../common/blood-type-service.service';
import { RequestModel } from '../models/request.model';
import { RequestComponent } from '../request/request.component';

@Component({
  selector: 'app-manage-request',
  templateUrl: './manage-request.component.html',
  styleUrls: ['./manage-request.component.scss']
})
export class ManageRequestComponent implements OnInit {

  displayedColumns = ['name', 'date', 'bloodType', 'confirmed', 'button', 'actions'];

  dataSource: RequestModel[] = [];

  constructor(
    private http: HttpClient, 
    public dialog: MatDialog, 
    public bloodTypeService: BloodTypeServiceService
    ) { 
    this.http.get<RequestModel[]>('https://localhost:44366/request/get-all/' + sessionStorage.getItem('userId')).subscribe(
      (res) => { this.dataSource = res },
      (err) => console.log(err)
    )
  }

  ngOnInit(): void {
  }

  getSessionRole() {
    return sessionStorage.getItem('role');
  }

  onRequest() {
    this.dialog.open(RequestComponent);
  }

  onConfirm(reqId: number) {
    this.http.post('https://localhost:44366/request/confirm', reqId).subscribe(
      () => location.reload()
    )
  }

  onDelete(id: number) {
    this.http.get('https://localhost:44366/request/delete/' + id).subscribe(
      () => location.reload()
    )
  }
}
