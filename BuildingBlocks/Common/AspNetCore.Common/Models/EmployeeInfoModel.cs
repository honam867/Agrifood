using System;

namespace AspNetCore.Common.Models
{
    public class EmployeeInfoModel
    {
        public int EmployeeId { get; set; }
        public int? GroupId { get; set; }
        public int? DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string AvatarURL { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
