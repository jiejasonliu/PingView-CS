namespace PingView_WF_App {
    partial class PingViewForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ipLabel = new System.Windows.Forms.Label();
            this.ipTextbox = new System.Windows.Forms.TextBox();
            this.pingButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.avgTTL = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Font = new System.Drawing.Font("Orbitron", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipLabel.Location = new System.Drawing.Point(54, 47);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(35, 20);
            this.ipLabel.TabIndex = 0;
            this.ipLabel.Text = "IP :";
            // 
            // ipTextbox
            // 
            this.ipTextbox.Font = new System.Drawing.Font("Orbitron", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipTextbox.Location = new System.Drawing.Point(95, 45);
            this.ipTextbox.Name = "ipTextbox";
            this.ipTextbox.Size = new System.Drawing.Size(324, 25);
            this.ipTextbox.TabIndex = 1;
            // 
            // pingButton
            // 
            this.pingButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pingButton.Font = new System.Drawing.Font("Orbitron", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pingButton.Location = new System.Drawing.Point(325, 76);
            this.pingButton.Name = "pingButton";
            this.pingButton.Size = new System.Drawing.Size(94, 33);
            this.pingButton.TabIndex = 2;
            this.pingButton.Text = "Ping";
            this.pingButton.UseVisualStyleBackColor = false;
            this.pingButton.Click += new System.EventHandler(this.PingButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Orbitron", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.resultLabel.Location = new System.Drawing.Point(54, 198);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(100, 20);
            this.resultLabel.TabIndex = 3;
            this.resultLabel.Text = "Standby...";
            // 
            // avgTTL
            // 
            this.avgTTL.AutoSize = true;
            this.avgTTL.Checked = true;
            this.avgTTL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.avgTTL.Location = new System.Drawing.Point(329, 126);
            this.avgTTL.Name = "avgTTL";
            this.avgTTL.Size = new System.Drawing.Size(90, 17);
            this.avgTTL.TabIndex = 4;
            this.avgTTL.Text = "Average Ping";
            this.avgTTL.UseVisualStyleBackColor = true;
            // 
            // PingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 257);
            this.Controls.Add(this.avgTTL);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.pingButton);
            this.Controls.Add(this.ipTextbox);
            this.Controls.Add(this.ipLabel);
            this.Name = "PingView";
            this.Text = "PingView (C#)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.TextBox ipTextbox;
        private System.Windows.Forms.Button pingButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.CheckBox avgTTL;
    }
}

