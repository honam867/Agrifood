using System.Drawing;

namespace WebAdminApplication.Models
{
    public class CompanyModel
    {
        public byte[] Stamp { get; set; }
        public Bitmap StampBitmap { get; set; }
        public string CompanyName { get; set; }
        public string LocalURL { get; set; }
        public string StampURL { get; set; }
        public CompanyModel()
        {
            Stamp = new byte[10];
            StampBitmap = new Bitmap(10, 10);
            CompanyName = "Tuloc";
            LocalURL = "";
            StampURL = "";
        }
    }
}
