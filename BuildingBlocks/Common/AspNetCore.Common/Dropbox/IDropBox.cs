namespace AspNetCore.Common.Dropbox
{
    public interface IDropbox
    {
        string GetFileNameByUrl(string url);
        string GetToken();
        string GetLv1CompanyCodeUrl();
        string GetLv2EnvironmentUrl();
        string GetLv3AssetImageUrl();
        string GetLv3AssetFileUrl();
        string GetLv3AssetDefaultUrl();
        string GetLv4CompanyUrl();
        string GetLv4EmployeeUrl();
        string GetLv4CustomerUrl();
        string GetLv4AssetpartUrl();
        string GetLv4CRMTemplateUrl();
        string GetLv5LogoUrl();
        string GetLv5AvatarUrl();
        string GetLv5TimeSheetUrl();
        string GetLv5TransfersUrl();
        string GetLv4ProductUrl();
        string GetLv5DrawingUrl();
    }
}
