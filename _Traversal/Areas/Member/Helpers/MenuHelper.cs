using Microsoft.AspNetCore.Mvc.Rendering;

namespace _Traversal.Areas.Member.Helpers
{
    public static class MenuHelper
    {
        public  static  string IsActiveMenu(this ViewContext context , string controller , string action="Index")
        {
            string _controller = context.RouteData.Values["Controller"].ToString();
            string _action = context.RouteData.Values["Action"].ToString();

            return (_controller == controller && _action == action) ? "active" :"";

        }
    }
}
