using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class Cow : EntityBase<int>
    {
        public int ByreId { set; get; }
        public Byre Byre { set; get; }
        public int? MotherId { set; get; }
        public int? FatherId { set; get; }
        public string Name { set; get; }
        public string Status { get; set; }
        public string Code { set; get; }
        public string TinhCode { get; set; }
        public DateTime Birthday { set; get; }
        public string Gender { set; get; }
        public DateTime WeaningDate { set; get; }
        public int FoodSuggestionId { set; get; }
        public FoodSuggestion FoodSuggestion { set; get; }
    }
}