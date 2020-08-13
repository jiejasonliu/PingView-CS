﻿using System;
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
        /// <para></para>
        /// Pinger.Reply is referenced from the very last ping request (last ping for an PingAvg() query).
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

            // use default TTL (128), but change fragmentation settings
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

        /// <summary>
        /// Requests a new ping query to the supplied host, will run for the asked amount.
        /// <para></para>
        /// Returns the average TTL of all the successful queries, or -1 if failed.
        /// </summary>
        public static double PingAvg(int timesToPing, string ipAddress) {
            // ensure synchronization
            if (InProgress)
                return -1;

            // reset PingReply data
            Reply = null;
            InProgress = true;

            // total ping
            long sumPing = 0;
            int lastDropped = 0;

            // initialize ping service and options
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // use default TTL (128), but change fragmentation settings
            options.DontFragment = true;

            // buffer of 32 bytes (32 chars)
            string data = "aaaabcdefghijklmnopqrstuvwxyzzzz";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            int discarded = 0;

            for (int i = 0; i < timesToPing; i++) {
                Reply = pingSender.Send(ipAddress, timeout, buffer, options);

                if (Reply.Status == IPStatus.Success) {
                    sumPing += Reply.RoundtripTime;
                }
                else {
                    discarded += 1;
                }
            }
            // update progress
            InProgress = false;

            return sumPing / (timesToPing - discarded);
        }
    }
}
