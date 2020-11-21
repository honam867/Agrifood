using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models
{
    public class APIDistrictModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        //to map with API
        public int TinhThanhID { get; set; }
    }
}
