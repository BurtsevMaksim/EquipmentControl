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

        public IActionResult Index()
        {
            LastochkaContext context = HttpContext.RequestServices.GetService(typeof(EquipmentControl.Data.LastochkaContext)) as LastochkaContext;

            return View(context.GetAllLastochkas());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult LastochkasList()
        {
            LastochkaContext context = HttpContext.RequestServices.GetService(typeof(EquipmentControl.Data.LastochkaContext)) as LastochkaContext;
            ViewBag.LastochkasList = new SelectList(context.GetAllLastochkas(), "Id", "TrainNumber");
            return View();
        }

        public string CMDtest(string selectedTrainID, string command, string Interface, string TCPPackets, string DiscoveredIP, string AccessIP)
        {
            LastochkaContext context = HttpContext.RequestServices.GetService(typeof(EquipmentControl.Data.LastochkaContext)) as LastochkaContext;
            if (command.Equals("Show Interfaces"))
            {

                int TrainID = Int32.Parse(selectedTrainID);
                var hostIP = context.GetAllLastochkas().Find(x => x.Id == TrainID).MarIP;
                SSH s = new SSH();
                s.SSHGetInterfaces(hostIP);
                return s.SSHGetInterfaces(hostIP);
            }
            else if (command.Equals("Show Home Folder"))
            {
                int TrainID = Int32.Parse(selectedTrainID);
                var hostIP = context.GetAllLastochkas().Find(x => x.Id == TrainID).MarIP;
                SSH s = new SSH();
                s.SSHFolderInfo(hostIP);
                return s.SSHFolderInfo(hostIP);
            }
            else if (command.Equals("Launch TCPDump"))
            {
                int TrainID = Int32.Parse(selectedTrainID);
                var hostIP = context.GetAllLastochkas().Find(x => x.Id == TrainID).MarIP;
                int TCPPacketsParsed = Int32.Parse(TCPPackets);
                SSH s = new SSH();
                s.TCPDumpLaunch(hostIP, Interface, TCPPacketsParsed);
                return s.TCPDumpLaunch(hostIP, Interface, TCPPacketsParsed);
            }
            else
            {
                int TrainID = Int32.Parse(selectedTrainID);
                var hostIP = context.GetAllLastochkas().Find(x => x.Id == TrainID).MarIP;
                SSH s = new SSH();
                s.ChangeInterfaceSettings(hostIP, Interface, DiscoveredIP, AccessIP);
                return s.ChangeInterfaceSettings(hostIP, Interface, DiscoveredIP, AccessIP);
            }
        }
    }
}
