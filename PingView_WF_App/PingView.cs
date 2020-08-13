using System;
using System.Windows.Forms;

namespace PingView_WF_App {
    public partial class PingView : Form {

        private const int MAX_TTL_QUERIES = 10;

        public PingView() {
            InitializeComponent();
        }

        private void PingButton_Click(object sender, EventArgs e) {
            Clear();
            string ipText = ipTextbox.Text.Trim();

            // check if ip is valid
            if (PingViewHelper.IsValidIP(ipText)) {
                Clear();

                // check if avg ttl required
                if (avgTTL.Checked) {
                    double ping = Pinger.PingAvg(MAX_TTL_QUERIES, ipText);

                    if (ping != -1 && !Pinger.InProgress) {
                        if (Pinger.Reply.Address != null) {
                            string host = Pinger.Reply.Address.ToString();
                            resultLabel.Text = $"{ping}ms -- {host} ({MAX_TTL_QUERIES} packets)";
                        }
                    }
                    else {
                        // discard if in progress
                        if (!Pinger.InProgress) {
                            ShowErrorNetworkError();
                        }
                    }
                }
                // single ping check
                else {
                    if (Pinger.Ping(ipText) && !Pinger.InProgress) {
                        if (Pinger.Reply.Address != null) {
                            double ping = Pinger.Reply.RoundtripTime;
                            string host = Pinger.Reply.Address.ToString();
                            resultLabel.Text = $"{ping}ms -- {host} (1 packet)";
                        }
                    }
                    else {
                        // discard if in progress
                        if (!Pinger.InProgress) {
                            ShowErrorNetworkError();
                        }
                    }
                }
            }
            // input is empty or not a valid ip
            else {
                ShowErrorInvalidIP();
            }
        }

        private void ShowErrorInvalidIP() {
            resultLabel.Text = "You have entered an invalid IP.";
        }

        private void ShowErrorNetworkError() {
            resultLabel.Text = "There was a network error.";
        }

        private void Clear() {
            resultLabel.ResetText();
        }
    }
}
