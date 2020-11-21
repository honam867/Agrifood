using ApplicationDomain.Identity.Entities;
using AutoMapper;

namespace ApplicationDomain.Identity.Models
{
    public class UserEmailModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }  
    }

    public class UserEmailModelMapper : Profile
    {
        public UserEmailModelMapper()
        {
            var mapper = CreateMap<User, UserEmailModel>();
        }
    }
}
