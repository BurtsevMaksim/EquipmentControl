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
            ViewBag.LastochkasList = new SelectList(_context.Lastochka, "Id", "TrainNumber");
            return View();
        }

        [HttpPost]
        public string CMDtest(string selectedTrainID, string command)
        {
            if (command.Equals("Show Interfaces"))
                {
                int TrainID = Int32.Parse(selectedTrainID);
                var hostIP = _context.Lastochka.Find(TrainID).MarIP;
                SSH s = new SSH();
                s.SSHGetInterfaces(hostIP);
                return s.SSHGetInterfaces(hostIP);
                }
            else
                {
                int TrainID = Int32.Parse(selectedTrainID);
                var hostIP = _context.Lastochka.Find(TrainID).MarIP;
                SSH s = new SSH();
                s.SSHFolderInfo(hostIP);
                return s.SSHFolderInfo(hostIP);
                }
        }
    }
}
