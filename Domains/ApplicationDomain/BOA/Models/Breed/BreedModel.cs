using ApplicationDomain.BOA.Entities;
using AutoMapper;


namespace ApplicationDomain.BOA.Models.Breeds
{
    public class BreedModel
    {
        public int Id { get; set; }
        public string Code { set; get; }
        public string Name { set; get; }
    }
    public class BreedModelMapper : Profile
    {
        public BreedModelMapper()
        {
            CreateMap<BreedModel, Breed>();
            var mapers = CreateMap<Breed, BreedModel>();
        }
    }
}
