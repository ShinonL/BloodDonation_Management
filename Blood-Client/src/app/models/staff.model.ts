import { BloodTypeModel } from "./bloodType.model";
import { HospitalModel } from "./hospital.model";

export interface StaffModel
{
    id: number,
    firstName: string,
    lastName: string,
    role: string,
    phoneNumber: string,
    hospital: HospitalModel
}