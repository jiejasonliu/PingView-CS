using System.Net;

namespace PingView_WF_App {
    public static class PingViewHelper {
        
        /// <summary>
        /// Returns whether the provided string is a valid ip address.
        /// </summary>
        public static bool IsValidIP(string ip) {
            IPAddress address;
            return IPAddress.TryParse(ip, out address);
        }
    }
}
