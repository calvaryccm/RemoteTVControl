using CCM.TVRemote.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CCM.TVRemote.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SendCommand(string command)
        {
            TVAddresses tvs = new TVAddresses(true);

            switch (command)
            {
                case "on":
                    await Task.Run(() => tvs.CurrentTvs.SendCommand(Command.TurnOn));
                    break;

                case "off":
                    await Task.Run(() => tvs.CurrentTvs.SendCommand(Command.TurnOff));
                    break;

                case "serviceon":
                    await Task.Run(() => tvs.CurrentTvs.SendCommand(Command.SwitchToChannel5, tvs.TvsToSkip));
                    break;

                case "serviceoff":
                    await Task.Run(() => tvs.CurrentTvs.SendCommand(Command.SwitchToHDMI1, tvs.TvsToSkip));
                    break;

                default:
                    await Task.Run(() => tvs.CurrentTvs.SendCommand(Command.TurnOn));
                    break;
            }

            return RedirectToAction("Index");
        }
	}
}