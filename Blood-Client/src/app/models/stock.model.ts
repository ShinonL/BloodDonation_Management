import { BloodTypeModel } from "./bloodType.model";
import { HospitalModel } from "./hospital.model";

export interface StockModel
{
    id: number;
    hospital: HospitalModel,
    bloodType: BloodTypeModel,
    quantity: number
}