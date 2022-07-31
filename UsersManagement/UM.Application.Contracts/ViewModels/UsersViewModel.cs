using _01_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UM.Application.Contracts.ViewModels
{
    public class UsersViewModel
    {
        public long ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]

        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]

        public string LastName { get; set; }
        public string Fullname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        [DataType(DataType.EmailAddress, ErrorMessage = ValidationMessages.Email)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public bool Sex { get; set; }
        public IFormFile IMG { get; set; }
        public string Tel { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }
        [Compare(nameof(RePassword), ErrorMessage = ValidationMessages.PasswordCompare)]
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string RePassword { get; set; }
        public bool UserStatus { get; set; }
        public IFormFile IDCardIMG { get; set; }
        public string IDCardIMGFileAddress { get; set; }
        public string IMGFileAddress { get; set; }

        public List<UsersRolesViewModel> UserRolesList { get; set; }
        public List<long> UserRolesIdList { get; set; }

        public List<RolesViewModel> RolesList { get; set; }


    }
}
