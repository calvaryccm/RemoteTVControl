using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CCM.TVRemote.Core
{
    public class TVAddresses
    {
        public List<IPAddress> CurrentTvs { get; set; }
        public int[] TvsToSkip { get; set; }

        private static IPAddress[] _DefaultIPAddresses = new IPAddress[]{
            System.Net.IPAddress.Parse("10.10.10.10"),
            System.Net.IPAddress.Parse("10.10.10.11"),
            System.Net.IPAddress.Parse("10.10.10.12")
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initDefaultTVs">Initializes the default TV Addresses</param>
        public TVAddresses(bool initDefaultTVs = false)
        {
            if(initDefaultTVs)
            {
                foreach(var item in _DefaultIPAddresses)
                {
                    AddTVAddress(item);
                }
            }

            TvsToSkip = new int[] { 0, 4 };
        }

        public TVAddresses(IPAddress[] tvaddresses)
        {
            foreach (var item in tvaddresses)
            {
                AddTVAddress(item);
            }

            TvsToSkip = new int[] { 0, 4 };
        }

        public TVAddresses(string[] tvaddresses)
        {
            foreach (var item in tvaddresses)
            {
                AddTVAddress(item);
            }

            TvsToSkip = new int[] { 0, 4 };
        }

        public void AddTVAddress(string ipaddress)
        {
            CurrentTvs.Add(IPAddress.Parse(ipaddress));
        }

        public void AddTVAddress(IPAddress ipaddress)
        {
            CurrentTvs.Add(ipaddress);
        }
    }
}
