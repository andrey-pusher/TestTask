using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers.Abstract
{
    public abstract class BaseController : Controller
    {
        protected IActionResult TryBlock(Func<IActionResult> func)
        {
            try
            {
                return func();
            }
            catch (Exception e)
            {
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { Message = e.Message });
            }
        }

        protected JsonResult TryBlock(Func<JsonResult> func)
        {
            try
            {
                return func();
            }
            catch (Exception e)
            {
                return Json(new ErrorViewModel { Message = e.Message });
            }
        }
    }
}
