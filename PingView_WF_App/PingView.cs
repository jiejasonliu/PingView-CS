using System;
using System.Net;
using System.Net.NetworkInformation;
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
            }
            // input is empty or not a valid ip
            else {
                MessageBox.Show("You must enter a valid IP address!", "PingView (C#) Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
