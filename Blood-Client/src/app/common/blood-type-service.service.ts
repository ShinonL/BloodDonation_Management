import { Injectable } from '@angular/core';
import { BloodType } from '../models/BloodType';

@Injectable({
  providedIn: 'root'
})
export class BloodTypeServiceService {

  constructor() { }

  convertToString(bloodType: BloodType) {
    return bloodType.blood + (bloodType.rh ? " +" : " -");
  }
}
