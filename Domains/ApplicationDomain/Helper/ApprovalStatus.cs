namespace ApplicationDomain.Helper
{
    public class ApprovalStatus
    {
        public static int New = 1;
        public static int Waiting = 2;
        public static int Cancelled = 3;
        public static int Rejected = 4;
        public static int Approved = 5;
        public static int Checked = 6;
        public static int Confirmed = 7;
        public static int Completed = 8;

        public static string GetName(int statusId)
        {
            return statusId == New ? "Mới tạo"
                : statusId == Waiting ? "Chờ duyệt"
                : statusId == Cancelled ? "Huỷ"
                : statusId == Checked ? "Đã kiểm tra"
                : statusId == Approved ? "Đã duyệt"
                : statusId == Confirmed ? "Đã xác nhận"
                : statusId == Completed ? "Hoàn thành"
                : "Không duyệt";
        }

        public static string GetCode(int statusId)
        {
            return statusId == New ? "NEW"
                : statusId == Waiting ? "WAI"
                : statusId == Cancelled ? "CAN"
                : statusId == Checked ? "CHK"
                : statusId == Approved ? "APP"
                : statusId == Confirmed ? "CON"
                : statusId == Completed ? "COM"
                : "REJ";
        }
    }
}
