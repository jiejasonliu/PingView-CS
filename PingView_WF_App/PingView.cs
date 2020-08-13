using System;
using System.Windows.Forms;

namespace PingView_WF_App {
    public partial class PingView : Form {
        public PingView() {
            InitializeComponent();
        }

        private void PingButton_Click(object sender, EventArgs e) {
            string ipText = ipTextbox.Text.Trim();

            // check if ip is valid
            if (PingViewHelper.IsValidIP(ipText)) {
                resultLabel.Text = "Running ping test...";
                if (Pinger.Ping(ipText)) {
                    double ping = Pinger.Reply.RoundtripTime;
                    string host = Pinger.Reply.Address.ToString();
                    resultLabel.Text = $"{ping}ms -- {host}";
                }
                else {
                    // discard if in progress
                    if (!Pinger.InProgress) {
                        ShowErrorNetworkError();
                    }
                }
            }
            // input is empty or not a valid ip
            else {
                ShowErrorInvalidIP();
            }

        }

        private void ShowErrorInvalidIP() {
            MessageBox.Show("You must enter a valid IP address.", "PingView (C#) Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Standby();
        }

        private void ShowErrorNetworkError() {
            MessageBox.Show("There was a network error or the host could not be resolved.", "PingView (C#) Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Standby();
        }

        private void Standby() {
            resultLabel.Text = "Standby...";
        }
    }
}
