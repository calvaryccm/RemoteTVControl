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
        static void Main(string[] args)
        {
            if (args.Length == 0)
                return;

            TVAddresses tvs = new TVAddresses(true);

            switch(args[0])
            {
                case "on":
                    tvs.CurrentTvs.SendCommand(Command.TurnOn);
                    break;

                case "off":
                    tvs.CurrentTvs.SendCommand(Command.TurnOff);
                    break;

                case "serviceon":
                    tvs.CurrentTvs.SendCommand(Command.SwitchToChannel5, tvs.TvsToSkip);
                    break;

                case "serviceoff":
                    tvs.CurrentTvs.SendCommand(Command.SwitchToHDMI1, tvs.TvsToSkip);
                    break;

                default:
                    tvs.CurrentTvs.SendCommand(Command.TurnOn);
                    break;
            }
        }

    }
}
