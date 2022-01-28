import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { BloodTypeServiceService } from '../common/blood-type-service.service';
import { BloodTypeModel } from '../models/bloodType.model';
import { HospitalModel } from '../models/hospital.model';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.scss']
})
export class RequestComponent implements OnInit {
  illness: FormControl;
  targetFirstName: FormControl;
  targetLastName: FormControl;
  
  bloodTypeId: string = '';

  bloodTypes: BloodTypeModel[] = [];

  defaultValue= {hour: 13, minute: 30};

  timeChangeHandler(event: Event) {
    console.log(event);
  }

  constructor(private http: HttpClient, public bloodTypeService: BloodTypeServiceService) { 
    this.targetFirstName = new FormControl('', Validators.required);
    this.targetLastName = new FormControl('', Validators.required);
    this.illness = new FormControl('', Validators.required);
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
    var num: number = +(sessionStorage.getItem('userId') ?? 0);

    var request = {
      staffId: num,
      targetFirstName: this.targetFirstName.value,
      targetLastName: this.targetLastName.value,
      illness: this.illness.value,
      bloodId: this.bloodTypeId
    };

    this.http.post('https://localhost:44366/request/create', request).subscribe(
      () => location.reload(),
      (err) => console.log(err)
    )
  }
}
