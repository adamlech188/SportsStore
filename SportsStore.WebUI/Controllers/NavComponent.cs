using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return Content("Hello from NavController");
        }
    }
}