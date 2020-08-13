using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace PingView_WF_App {
    /// <summary>
    /// A modular integration with System.Net.NetworkInformation to ping hosts.
    /// <para></para>
    /// As of this release, Pinger is constrained to synchronous requests.
    /// </summary>
    public static class Pinger {
        ///<summary>
        /// Returns a <b>PingReply</b> object, <b>null</b> if in progress or never used.
        /// </summary>
        public static PingReply Reply { get; private set; }

        public static bool InProgress = false;

        /// <summary>
        /// Requests a new ping query to the supplied host.
        /// <para></para>
        /// Returns true if the Ping request was successful, false if in progress or failed.
        /// </summary>
        public static bool Ping(string ipAddress) {
            // ensure synchronization
            if (InProgress) 
                return false;

            // reset PingReply data
            Reply = null;
            InProgress = true;

            // initialize ping service and options
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // use default TTL, but change fragmentation settings
            options.DontFragment = true;

            // buffer of 32 bytes (32 chars)
            string data = "aaaabcdefghijklmnopqrstuvwxyzzzz";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            // ping query
            Reply = pingSender.Send(ipAddress, timeout, buffer, options);

            // update progress
            InProgress = false;

            // return data
            if (Reply.Status == IPStatus.Success)
                return true;
            else
                return false;
        }
    }
}
