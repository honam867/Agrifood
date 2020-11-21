namespace ApplicationDomain.Helper
{
    public class InventoryStatus
    {
        public static int New = 1;
        public static int Waiting = 2;
        public static int Canceled = 3;
        public static int Checked = 4;
        public static int Approved = 5;
        public static int Confirmed = 7;
        public static int Rejected = 6;

        public static string GetName(int StatusId)
        {
            if (StatusId == InventoryStatus.New) return "Mới tạo";
            else if (StatusId == InventoryStatus.Waiting) return "Chờ kiểm tra";
            else if (StatusId == InventoryStatus.Canceled) return "Huỷ";
            else if (StatusId == InventoryStatus.Checked) return "Đã kiểm tra";
            else if (StatusId == InventoryStatus.Approved) return "Đã duyệt";
            else if (StatusId == InventoryStatus.Confirmed) return "Hoàn thành";    
            else if (StatusId == InventoryStatus.Rejected) return "Không duyệt";
            return "Mới tạo";
        }
    }
}
