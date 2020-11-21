namespace ApplicationDomain.Helper
{
    public class CaptionConstant
    {
        public static string GetItemGroupName(ItemGroupConstant itemGroup)
        {
            switch (itemGroup)
            {
                case ItemGroupConstant.ASSET: return "Máy";
                case ItemGroupConstant.PART: return "Vật tư";
                default:return "Khác";
            }
        }
    }
}
