import { BloodTestModel } from "./bloodTest.model";
import { HospitalModel } from "./hospital.model";
import { PatientModel } from "./patient.model";

export interface AppointmentModel 
{
    userId: number,
    hospital: HospitalModel,
    appointmentDe: Date,
    confirmed: boolean,
    user: PatientModel,
    requestId: number,
    id: number,
    hasResults: boolean,
    bloodTest: BloodTestModel
}