using BloodServer.DTO;
using BloodServer.DTO.Models;
using BloodServer.Repository.Interfaces;
using BloodServer.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BloodServer.Service
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IBloodTypeService _bloodTypeService;

        public UserService(IUserRepository userRepository, IBloodTypeService bloodTypeService)
        {
            _userRepository = userRepository;
            _bloodTypeService = bloodTypeService;
        }
        public void CreateUser(UserDTO user)
        {
            var newUser = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password,
                Phone = user.Phone,
                Email = user.Email,
                Cnp = user.Cnp,
                BloodId = user.BloodId
            };

            _userRepository.CreateUser(newUser);
        }

        public int GetUserId(UserDTO user)
        {
            var result = _userRepository.GetByUser(user.Username, user.Password);

            if (result == null)
                return -1;

            return result.Id;
        }

        public staff GetStaffId(string username, string password)
        {
            var result = _userRepository.GetByCredentials(username, password);

            if (result == null)
                throw new Exception("User not found");

            return result;
        }

        public string GetStaffRole(int id)
        {
            return _userRepository.GetAuthById(id).Role;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var users = _userRepository.GetAll().Select(
                user =>
                {
                    var userDTO = new UserDTO
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Username = user.Username,
                        Password = user.Password,
                        Phone = user.Phone,
                        Email = user.Email,
                        Cnp = user.Cnp,
                        Blood = new BloodTypeDTO {
                            Id = user.Blood.Id,
                            Rh = user.Blood.Rh,
                            Blood = user.Blood.Blood
                        }
                    };
                    return userDTO;
                }).ToList();

            return users;
        }
    }
}
