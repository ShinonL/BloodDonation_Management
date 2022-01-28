import { BloodTypeModel } from "./bloodType.model";
import { HospitalModel } from "./hospital.model";

export interface RequestModel 
{
    staffId: number,
    targetFirstName: string,
    targetLastName: string,
    illness: string,
    CNP: string,
    requestDate: Date,
    confirmed: boolean,
    bloodId: number,
    blood: BloodTypeModel,
    hospital: HospitalModel
}