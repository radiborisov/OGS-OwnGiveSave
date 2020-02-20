namespace OwnGiveSave.Web.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class ElementsController : BaseController
    {
        // GET: Elements
        public IActionResult Elements()
        {
            return this.View();
        }

    }
}
