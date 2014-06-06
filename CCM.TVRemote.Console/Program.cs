using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CCM.TVRemote.Core;

namespace CCM.TVRemote.Console
{
    class Program
    {
        //private static IPAddress[] _IPAddresses = new IPAddress[]{
        //    System.Net.IPAddress.Parse("10.10.252.10"), //RF only
        //    System.Net.IPAddress.Parse("10.10.252.11"),
        //    System.Net.IPAddress.Parse("10.10.252.12"),
        //    System.Net.IPAddress.Parse("10.10.252.13"),
        //    System.Net.IPAddress.Parse("10.10.252.14"), //RF only
        //    System.Net.IPAddress.Parse("10.10.252.15"),
        //    System.Net.IPAddress.Parse("10.10.252.16"),
        //    System.Net.IPAddress.Parse("10.10.252.17")
        //};

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
        //private static string[] CommandsList = { 
        //                                    "POWR1   \r", //0 - Turn on
        //                                    "POWR0   \r", //1 - Turn off
        //                                    "RSPW2   \r", //2 - Enable remote commands
        //                                    "ITGDx   \r", //3 - Input Toggle
        //                                    "AVMD000 \r", //4 - AV Mode Selection
        //                                    "MUTE0   \r", //5 - Mute Toggle
        //                                    "VOLMUP", //6 - Volume Up
        //                                    "VOLMDN", //7 - Volume Down
        //                                    "IAVD1   \r", //8 - HDMI1
        //                                    "DCCH0005\r" //9 - Channel 5
        //                                };

        static void Main(string[] args)
        {
            if (args.Length == 0)
                return;

            TVAddresses tvs = new TVAddresses(true);

            switch(args[0])
            {
                case "on":
                    //SendCommand(CommandsList[0], false);
                    tvs.CurrentTvs.SendCommand(Command.TurnOn);
                    break;

                case "off":
                    //SendCommand(CommandsList[1], false);
                    tvs.CurrentTvs.SendCommand(Command.TurnOff);
                    break;

                case "serviceon":
                    //SendCommand(CommandsList[9], true);
                    tvs.CurrentTvs.SendCommand(Command.SwitchToChannel5, tvs.TvsToSkip);
                    break;

                case "serviceoff":
                    //SendCommand(CommandsList[8], true);
                    tvs.CurrentTvs.SendCommand(Command.SwitchToHDMI1, tvs.TvsToSkip);
                    break;

                default:
                    tvs.CurrentTvs.SendCommand(Command.TurnOn);
                    break;
            }
        }

        //private static void SendCommand(string data, bool skip)
        //{

        //    for (var i = 0; i < _IPAddresses.Length; i++)
        //    {
        //        if (skip && (i == 0 || i == 4))
        //            continue;

        //        using (TcpClient client = new TcpClient())
        //        {
        //            client.Connect(_IPAddresses[i], 10002);
        //            using (var networkStream = client.GetStream())
        //            using (var writer = new StreamWriter(networkStream))
        //            {
        //                writer.AutoFlush = true;

        //                writer.Write(data);
        //            }

        //            client.Close();
        //        }

        //    }

        //}

    }
}
