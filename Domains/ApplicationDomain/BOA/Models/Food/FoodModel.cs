using ApplicationDomain.BOA.Entities;
using AutoMapper;


namespace ApplicationDomain.BOA.Models.Foods
{
    public class FoodModel
    {
        public int Id { get; set; }
        public string Name { get; set; } //NOT NULL, LENGTH > 5, UPPER CASE
        public string Code { set; get; } //NOT NULL, LENGTH = 3, UPPER CASE, UNIQUE
        public int Provinceid { set; get; }
        public string ProvinceName { set; get; }
        public string Type { set; get; }
    }
    public class FoodModelMapper : Profile
    {
        public FoodModelMapper()
        {
            CreateMap<FoodModel, Food>();
            var mapers = CreateMap<Food, FoodModel>();
        }
    }
}
