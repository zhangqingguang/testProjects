using System.Web;
using System.Web.Mvc;

namespace ITGB.UIS.Customize.Form.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
