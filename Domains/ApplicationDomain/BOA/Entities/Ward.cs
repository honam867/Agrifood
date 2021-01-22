using ApplicationDomain.Core.Entities;

namespace ApplicationDomain.BOA.Entities
{
    public class Ward : EntityBase<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
