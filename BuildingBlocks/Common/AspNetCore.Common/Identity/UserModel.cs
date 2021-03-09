using System;
using System.Collections.Generic;

namespace AspNetCore.Common.Identity
{
	public class UserModel
	{
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarURL { get; set; }
        public bool Status { set; get; }
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedByUserName { set; get; }
        public DateTimeOffset UpdatedDate { get; set; }
        public string UpdatedByUserName { set; get; }
    }
}