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
        private static IPAddress[] _IPAddresses = new IPAddress[]{
            System.Net.IPAddress.Parse("10.10.252.10"), //RF only
            System.Net.IPAddress.Parse("10.10.252.11"),
            System.Net.IPAddress.Parse("10.10.252.12"),
            System.Net.IPAddress.Parse("10.10.252.13"),
            System.Net.IPAddress.Parse("10.10.252.14"), //RF only
            System.Net.IPAddress.Parse("10.10.252.15"),
            System.Net.IPAddress.Parse("10.10.252.16"),
            System.Net.IPAddress.Parse("10.10.252.17")
        };

        /// <summary>
        /// 0: Power Off
        /// 1: Power On
        /// 2: Power On Command Setting
        /// 3: Input Selection
        /// 4: AV Mode Selection
        /// 5: Toggle Mute
        /// 6: Volume Up
        /// 7: Volume Down
        /// 8: HDMI1
        /// 9: Channel 5
        /// </summary>
        private static string[] CommandsList = { 
                                            "POWR1   \r", //0 - Turn on
                                            "POWR0   \r", //1 - Turn off
                                            "RSPW2   \r", //2 - Enable remote commands
                                            "ITGDx   \r", //3 - Input Toggle
                                            "AVMD000 \r", //4 - AV Mode Selection
                                            "MUTE0   \r", //5 - Mute Toggle
                                            "VOLMUP", //6 - Volume Up
                                            "VOLMDN", //7 - Volume Down
                                            "IAVD1   \r", //8 - HDMI1
                                            "DCCH0005\r" //9 - Channel 5
                                        };

        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendCommand(string command)
        {

            switch (command)
            {
                case "on":
                    Task.Run(() => SendCommand(CommandsList[0], false));
                    break;

                case "off":
                    Task.Run(() => SendCommand(CommandsList[1], false));
                    break;

                case "serviceon":
                    Task.Run(() => SendCommand(CommandsList[9], true));
                    break;

                case "serviceoff":
                    Task.Run(() => SendCommand(CommandsList[8], true));
                    break;

                default:
                    Task.Run(() => SendCommand(CommandsList[0], false));
                    break;
            }

            return View("Index");
        }

        private static async Task SendCommand(string data, bool skip)
        {
            for (var i = 0; i < _IPAddresses.Length; i++)
            {
                if (skip && (i == 0 || i == 4))
                    continue;

                using (TcpClient client = new TcpClient())
                {
                    await client.ConnectAsync(_IPAddresses[i], 10002);
                    using (var networkStream = client.GetStream())
                    using (var writer = new StreamWriter(networkStream))
                    {
                        writer.AutoFlush = true;

                        await writer.WriteAsync(data);
                    }

                    client.Close();
                }

            }

        }
	}
}