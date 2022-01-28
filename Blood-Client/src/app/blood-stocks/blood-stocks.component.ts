import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BloodTypeServiceService } from '../common/blood-type-service.service';
import { StockModel } from '../models/stock.model';

@Component({
  selector: 'app-blood-stocks',
  templateUrl: './blood-stocks.component.html',
  styleUrls: ['./blood-stocks.component.scss']
})
export class BloodStocksComponent implements OnInit {
  columns = [
    {
      columnDef: 'name',
      header: 'Hospital Name',
      cell: (element: StockModel) => `${element.hospital.name}`,
    },
    {
      columnDef: 'bloodType',
      header: 'Blood Type',
      cell: (element: StockModel) => `${this.bloodTypeService.convertToString(element.bloodType)}`,
    },
    {
      columnDef: 'quantity',
      header: 'Quantity',
      cell: (element: StockModel) => `${element.quantity}`,
    },
    {
      columnDef: 'address',
      header: 'Hospital Address',
      cell: (element: StockModel) => `${element.hospital.address}`
    },
    {
      columnDef: 'phone',
      header: 'Hospital Phone',
      cell: (element: StockModel) => `${element.hospital.phoneNumber}`
    }
  ];

  dataSource : StockModel[] = [];
  displayedColumns = this.columns.map(c => c.columnDef);

  constructor(private http: HttpClient, public bloodTypeService: BloodTypeServiceService) { 
    this.http.get<StockModel[]>('https://localhost:44366/stocks/get-stock').subscribe(
      (res) => { this.dataSource = res },
      (err) => console.log(err)
    )
  }

  ngOnInit(): void {
  }

}
