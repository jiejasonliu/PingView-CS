using System;
using System.Net;
using System.Net.Sockets;

namespace PingView_WF_App {
    public static class PingViewHelper {
        
        /// <summary>
        /// Returns whether the provided string is a valid ip address.
        /// </summary>
        public static bool IsValidIP(string ip) {
            // reference type arg
            IPAddress address;

            // verify form of xxx.xxx.xxx.xxx
            if (ip.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).Length == 4) {
                // verify parse success
                if (IPAddress.TryParse(ip, out address)) {
                    // verify ipv4
                    switch (address.AddressFamily) {
                        case AddressFamily.InterNetwork:
                            return true;
                        default:
                            return false;
                    }
                }
            }
            return false;
        }
    }
}
