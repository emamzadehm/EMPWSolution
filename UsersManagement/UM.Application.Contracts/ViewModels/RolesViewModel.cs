using _01_Framework.Application;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UM.Application.Contracts.ViewModels
{
    public class RolesViewModel
    {
        public long ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ValidationMessages.IsRequired)]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool Granted { get; set; }
        public long ModuleId { get; set; }
        public string ModuleName { get; set; }
        public List<long> SelectedPermissions { get; set; }
        public bool Status { get; set; }
    }
}
