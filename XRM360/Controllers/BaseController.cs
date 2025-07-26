using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace XRM360website.Controllers
{

    public class BaseController : Controller
    {
        protected string CurrentLang => Request.Cookies["XRM360_Lang"] ?? "en";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // ✅ Dynamically assign layout based on selected language
            ViewBag.Layout = CurrentLang == "zh"
                ? "~/Views/Shared/_Layout.zh.cshtml"
                : "~/Views/Shared/_Layout.cshtml";

            base.OnActionExecuting(context);
        }

        protected IActionResult LangView(string viewName)
        {
            // ✅ Automatically load Chinese view if cookie is zh and file exists
            if (CurrentLang == "zh")
                return View(viewName + ".zh");

            return View(viewName);
        }
    }
}

