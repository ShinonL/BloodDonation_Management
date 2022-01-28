import { BloodTypeModel } from "./bloodType.model";

export interface PatientModel
{
    id: number,
    firstName: string,
    lastName: string,
    email: string,
    cnp: string,
    phone: string,
    blood: BloodTypeModel,
    bloodId: number,
    password: string,
    username: string
}