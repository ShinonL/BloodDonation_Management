using BloodServer.DTO;
using BloodServer.DTO.Models;
using BloodServer.Repository.Interfaces;
using BloodServer.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloodServer.Service
{
    public class HospitalService : IHospitalService
    {
        IHospitalRepository _hospitalRepository;
        IBloodTypeService _bloodService;
        public HospitalService(IHospitalRepository hospitalRepository, IBloodTypeService bloodService)
        {
            _hospitalRepository = hospitalRepository;
            _bloodService = bloodService;
        }

        public IEnumerable<HospitalDTO> GetAll()
        {
            var hospitals = _hospitalRepository.GetAll().Select(
                hospital =>
                {
                    var hospitalDTO = new HospitalDTO
                    {
                        Id = hospital.Id,
                        Name = hospital.Name,
                        Address = hospital.Address,
                        PhoneNumber = hospital.PhoneNumber
                    };
                    return hospitalDTO;
                });
            return hospitals;
        }

        public IEnumerable<AuthorizationDTO> GetRoles()
        {
            var roles = _hospitalRepository.GetRoles().Select(
                role =>
                {
                    var roleDTO = new AuthorizationDTO
                    {
                        Id = role.Id,
                        Role = role.Role
                    };
                    return roleDTO;
                }).ToList();
            return roles;
        }

        public IEnumerable<StaffDTO> GetStaff()
        {
            var staffs = _hospitalRepository.GetStaff().Select(
                staff =>
                {
                    var staffDTO = new StaffDTO
                    {
                        Id = staff.Id,
                        FirstName = staff.FirstName,
                        LastName = staff.LastName,
                        PhoneNumber = staff.PhoneNumber,
                        Role = staff.Authorization.Role,
                        Hospital = new HospitalDTO
                        {
                            Id = staff.Hospital.Id,
                            Name = staff.Hospital.Name,
                            Address = staff.Hospital.Address,
                            PhoneNumber = staff.Hospital.PhoneNumber
                        }
                    };
                    return staffDTO;
                });
            return staffs;
        }
        public void CreateStaff(StaffDTO staffDTO)
        {
            var staff = new staff
            {
                FirstName = staffDTO.FirstName,
                LastName = staffDTO.LastName,
                PhoneNumber = staffDTO.PhoneNumber,
                HospitalId = staffDTO.HospitalId,
                AuthorizationId = staffDTO.AuthorizationId,
                Username = staffDTO.Username,
                Password = staffDTO.Password
            };
            _hospitalRepository.CreateStaff(staff);
        }
        public void Delete(int id)
        {
            _hospitalRepository.Delete(id);
        }

        public HospitalDTO GetById(int id)
        {
            var model = _hospitalRepository.GetById(id);
            return new HospitalDTO
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber
            };
        }

        public void CreateAppointment(AppointmentDTO appointment)
        {
            var app = new Appointment
            {
                HospitalId = appointment.Hospital.Id,
                UserId = appointment.UserId,
                AppointmentDe = appointment.AppointmentDe,
                Confirmed = false
            };

            _hospitalRepository.CreateAppointment(app);
        }

        public void CreateAppointmentWithRequest(AppointmentDTO appointment, int id)
        {
            var app = new Appointment
            {
                HospitalId = appointment.Hospital.Id,
                UserId = appointment.UserId,
                AppointmentDe = appointment.AppointmentDe,
                Confirmed = false,
                RequestId = id
            };
            _hospitalRepository.CreateAppointment(app);
        }

        public IEnumerable<AppointmentDTO> GetAppointments(int id)
        {
            var appointments = _hospitalRepository.GetAppointments(id);
                
                var test = appointments.Select(
                appointment =>
                {
                    var appointmentDTO = new AppointmentDTO
                    {
                        Id = appointment.Id,
                        Hospital = GetById(appointment.HospitalId ?? 0),
                        AppointmentDe = appointment.AppointmentDe ?? DateTime.Now,
                        Confirmed = appointment.Confirmed,
                        BloodTest = (appointment.BloodTests.Count() > 0) ? new BloodTestDTO
                        {
                            Id = appointment.BloodTests.FirstOrDefault().Id,
                            AppointmentId = appointment.Id,
                            Aids = appointment.BloodTests.FirstOrDefault().Aids,
                            Leukemia = appointment.BloodTests.FirstOrDefault().Leukemia,
                            HepatitisB = appointment.BloodTests.FirstOrDefault().HepatitisB,
                            HepatitisC = appointment.BloodTests.FirstOrDefault().HepatitisC,
                            Pox = appointment.BloodTests.FirstOrDefault().Pox,
                            Thrombocytes = appointment.BloodTests.FirstOrDefault().Thrombocytes,
                            Hemoglobin = appointment.BloodTests.FirstOrDefault().Hemoglobin,
                            Cholesterol = appointment.BloodTests.FirstOrDefault().Cholesterol,
                            Leukocytes = appointment.BloodTests.FirstOrDefault().Leukocytes
                        } : null
                    };
                    return appointmentDTO;
                });
            return test;
        }

        public IEnumerable<AppointmentDTO> GetUnconfirmedAppointments(int id)
        {
            var appointments = _hospitalRepository.GetUnconfirmedAppointments(id);

            var test = appointments.Select(
            appointment =>
            {
                var appointmentDTO = new AppointmentDTO
                {
                    Id = appointment.Id,
                    Hospital = new HospitalDTO
                    {
                        Id = appointment.Hospital.Id,
                        Name = appointment.Hospital.Name,
                        Address = appointment.Hospital.Address,
                        PhoneNumber = appointment.Hospital.PhoneNumber
                    },
                    AppointmentDe = appointment.AppointmentDe ?? DateTime.Now,
                    Confirmed = appointment.Confirmed,
                    User = new UserDTO
                    {
                        Id = appointment.User.Id,
                        FirstName = appointment.User.FirstName,
                        LastName = appointment.User.LastName,
                        Username = appointment.User.Username,
                        Password = appointment.User.Password,
                        Phone = appointment.User.Phone,
                        Email = appointment.User.Email,
                        Cnp = appointment.User.Cnp,
                        Blood = _bloodService.GetById(appointment.User.BloodId ?? 1)
                    }
                };
                return appointmentDTO;
            });
            return test;
        }

        public IEnumerable<AppointmentDTO> GetConfirmedAppointments(int id)
        {
            var appointments = _hospitalRepository.GetConfirmedAppointments(id);

            var test = appointments.Select(
            appointment =>
            {
                var appointmentDTO = new AppointmentDTO
                {
                    Id = appointment.Id,
                    Hospital = new HospitalDTO
                    {
                        Id = appointment.Hospital.Id,
                        Name = appointment.Hospital.Name,
                        Address = appointment.Hospital.Address,
                        PhoneNumber = appointment.Hospital.PhoneNumber
                    },
                    AppointmentDe = appointment.AppointmentDe ?? DateTime.Now,
                    Confirmed = appointment.Confirmed,
                    User = new UserDTO
                    {
                        Id = appointment.User.Id,
                        FirstName = appointment.User.FirstName,
                        LastName = appointment.User.LastName,
                        Username = appointment.User.Username,
                        Password = appointment.User.Password,
                        Phone = appointment.User.Phone,
                        Email = appointment.User.Email,
                        Cnp = appointment.User.Cnp,
                        Blood = _bloodService.GetById(appointment.User.BloodId ?? 1)
                    },
                    HasResults = (appointment.BloodTests.Count() == 0) ? false : true
                };
                return appointmentDTO;
            });
            return test;
        }

        public void ConfirmAppointment(int id)
        {
            _hospitalRepository.ConfirmAppointment(id);
        }

        public void AddBloodTest(BloodTestDTO bloodTestDTO)
        {
            var bloodTest = new BloodTest
            {
                AppointmentId = bloodTestDTO.AppointmentId,
                Aids = bloodTestDTO.Aids,
                Leukemia = bloodTestDTO.Leukemia,
                HepatitisB = bloodTestDTO.HepatitisB,
                HepatitisC = bloodTestDTO.HepatitisC,
                Pox = bloodTestDTO.Pox,
                Thrombocytes = bloodTestDTO.Thrombocytes,
                Hemoglobin = bloodTestDTO.Hemoglobin,
                Cholesterol = bloodTestDTO.Cholesterol,
                Leukocytes = bloodTestDTO.Leukocytes
            };

            _hospitalRepository.AddBloodTest(bloodTest);
        }
    }
}
