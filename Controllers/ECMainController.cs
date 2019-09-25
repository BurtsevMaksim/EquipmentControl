using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentControl_v_0._1.Controllers
{
    public class ECMainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}