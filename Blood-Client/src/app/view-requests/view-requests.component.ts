import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BloodTypeServiceService } from '../common/blood-type-service.service';
import { DonateComponent } from '../donate/donate.component';
import { RequestModel } from '../models/request.model';

@Component({
  selector: 'app-view-requests',
  templateUrl: './view-requests.component.html',
  styleUrls: ['./view-requests.component.scss']
})
export class ViewRequestsComponent implements OnInit {

  dataSource: RequestModel[] = [];
  displayedColumns = ['name', 'date', 'tname', 'illness', 'blood', 'actions']

  constructor(
    private http: HttpClient, 
    public dialog: MatDialog, 
    public bloodTypeService: BloodTypeServiceService) { 
      this.http.get<RequestModel[]>('https://localhost:44366/request/get-all').subscribe(
      (res) => { this.dataSource = res },
      (err) => console.log(err)
    )
    }

  ngOnInit(): void {
  }

  openDialog(id: number) {
    this.dialog.open(DonateComponent, {data: {req: id}})
  }

}
