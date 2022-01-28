import { HttpClient } from '@angular/common/http';
import { APP_ID, Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-add-bloodtest',
  templateUrl: './add-bloodtest.component.html',
  styleUrls: ['./add-bloodtest.component.scss']
})
export class AddBloodtestComponent implements OnInit {
  aids: string = '';
  leukemia: string = '';
  hepatitisB: string = '';
  hepatitisC: string = '';
  pox: string = '';

  thrombocytes: FormControl;
hemoglobin: FormControl;
cholesterol: FormControl;
leukocytes: FormControl;

  constructor(private http: HttpClient, 
    @Inject(MAT_DIALOG_DATA) public data: { appId: number }) {
        this.thrombocytes = new FormControl('', Validators.required);
        this.hemoglobin = new FormControl('', Validators.required);
        this.cholesterol = new FormControl('', Validators.required);
        this.leukocytes = new FormControl('', Validators.required);
   }

  ngOnInit(): void {
  }

  onAdd() {
    var bloodTest = {
      appointmentId: this.data.appId,
      aids: (this.aids == 'true') ? true : false,
      leukemia: (this.leukemia == 'true') ? true : false,
      hepatitisB: (this.hepatitisB == 'true') ? true : false,
      hepatitisC: (this.hepatitisC == 'true') ? true : false,
      pox: (this.pox == 'true') ? true : false,
      thrombocytes: this.thrombocytes.value,
      hemoglobin: this.hemoglobin.value,
      cholesterol: this.cholesterol.value,
      leukocytes: this.leukocytes.value
    }

    this.http.post('https://localhost:44366/hospital/add-blood-test', bloodTest).subscribe(
      (res) => {
        location.reload();
      },
      (err) => console.log(err)
    )
  }

}
