using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OwnGiveSave.Web.Controllers
{
    public class ElementsController : BaseController
    {
        // GET: Elements
        public IActionResult Elements()
        {
            return this.View();
        }

    }
}