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
        public int MotherId { set; get; }
        public int FatherId { set; get; }
        public string Name { set; get; }
        public string QRCode { set; get; }
        public string Code { set; get; }
        public DateTime Birthday { set; get; }
        public int AgeNumber { set; get; }
        public string Gender { set; get; }
        public DateTime WeaningDate { set; get; }
        public int FoodSuggestionId { set; get; }
        public FoodSuggestion FoodSuggestion { set; get; }
    }
}