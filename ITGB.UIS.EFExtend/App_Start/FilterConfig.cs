using System.Web;
using System.Web.Mvc;

namespace ITGB.UIS.EFExtend
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
