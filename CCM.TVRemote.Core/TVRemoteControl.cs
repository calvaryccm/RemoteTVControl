using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CCM.TVRemote.Core
{
    public static class TVRemoteControl
    {
        public static int DefaultPort { get; set; }
        /// <summary>
        /// The indexes of IP addresses to skip in the TV address list.
        /// You can change the default value below.
        /// </summary>
        public static int[] TvsToSkip { get; set; }

        static TVRemoteControl()
        {
            DefaultPort = 10002;
        }

        public static void SendCommand(this List<IPAddress> addresses, string data, int[] tvsToSkip = null)
        {

            for (var i = 0; i < addresses.Count; i++)
            {
                if (tvsToSkip != null)
                {
                    if (tvsToSkip[i] == i)
                        continue;
                }
              
                using (TcpClient client = new TcpClient())
                {
                    client.Connect(addresses[i], DefaultPort);
                    using (var networkStream = client.GetStream())
                    using (var writer = new StreamWriter(networkStream))
                    {
                        writer.AutoFlush = true;

                        writer.Write(data);
                    }

                    client.Close();
                }

            }

        }
    }
}
