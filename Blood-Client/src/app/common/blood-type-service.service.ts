import { Injectable } from '@angular/core';
import { BloodTypeModel } from '../models/bloodType.model';

@Injectable({
  providedIn: 'root'
})
export class BloodTypeServiceService {

  constructor() { }

  convertToString(bloodType: BloodTypeModel) {
    return bloodType.blood + (bloodType.rh ? " +" : " -");
  }
}
