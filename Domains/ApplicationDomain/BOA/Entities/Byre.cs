using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class Byre : EntityBase<int>
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public int BreedId { set; get; }
        public Breed Breed { get; set; }
        public int? QuantityCow { set; get; }
        public int FarmerId { set; get; }
        public Farmer Farmer { get; set; }
        public string Ration { set; get; }
    }
}