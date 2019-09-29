using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EquipmentControl_v_0._1.Models;
using EquipmentControl.BusinessLogic;
using Microsoft.EntityFrameworkCore;
using EquipmentControl.Data;
using EquipmentControl.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EquipmentControl_v_0._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly LastochkaContext _context;

        public HomeController(LastochkaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult LastochkasList()
        {
            ViewBag.LastochkasList = new SelectList(_context.Lastochka, "MarIP", "TrainNumber");
            return View();
        }

        [HttpPost]
        public string CMDtest(string hostIP)
        {
            SSH s = new SSH();
            s.SSHConnect(hostIP);
            return s.SSHConnect(hostIP);
        }
    }
}
