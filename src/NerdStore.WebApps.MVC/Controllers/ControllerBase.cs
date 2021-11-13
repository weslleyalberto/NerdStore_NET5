using Microsoft.AspNetCore.Mvc;
using System;

namespace NerdStore.WebApps.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected Guid ClienteId = Guid.Parse("4b10fc0f-bb1d-4381-a80d-930060a5a277");
    }
}
