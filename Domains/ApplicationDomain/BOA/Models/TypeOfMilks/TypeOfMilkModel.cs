using ApplicationDomain.BOA.Entities;
using AutoMapper;


namespace ApplicationDomain.BOA.Models.TypeOfMilks
{
    public class TypeOfMilkModel
    {
        public int Id { get; set; }
        public string Name { get; set; } //NOT NULL, LENGTH > 5, UPPER CASE
        public string Code { set; get; } //NOT NULL, LENGTH = 3, UPPER CASE, UNIQUE
       
    }
    public class TypeOfMilkModelMapper : Profile
    {
        public TypeOfMilkModelMapper()
        {
            CreateMap<TypeOfMilkModel, TypeOfMilk>();
            var mapers = CreateMap<TypeOfMilk, TypeOfMilkModel>();
        }
    }
}
