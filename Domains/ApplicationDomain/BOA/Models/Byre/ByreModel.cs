using ApplicationDomain.BOA.Entities;
using AutoMapper;


namespace ApplicationDomain.BOA.Models.Branchs
{
    public class ByreModel
    {
        public int Id { get; set; }
        public string Code { set; get; }
        public string Name { set; get; }
        public int BreedId { set; get; }
        public int? QuantityCow { set; get; }
        public int FarmerId { set; get; }
        public string Ration { set; get; }
    }
    public class ByreModelMapper : Profile
    {
        public ByreModelMapper()
        {
            CreateMap<ByreModel, Byre>();
            var mapers = CreateMap<Byre, ByreModel>();
        }
    }
}
