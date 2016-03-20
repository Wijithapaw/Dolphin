using System.Web.Mvc;

namespace Dolphin.Areas.AdminArea
{
    public class AdminAreaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AdminArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AdminArea_default",
                "admin/{controller}/{action}/{id}",
                new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}