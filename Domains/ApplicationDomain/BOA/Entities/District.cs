using ApplicationDomain.Core.Entities;

namespace ApplicationDomain.BOA.Entities
{
    public class District : EntityBase<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}
