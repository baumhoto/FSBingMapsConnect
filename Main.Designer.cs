namespace SimMapsConnect
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonRequestData = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.richResponse = new System.Windows.Forms.RichTextBox();
            this.chkUpdateMaps = new System.Windows.Forms.CheckBox();
            this.cbRequestInterval = new System.Windows.Forms.ComboBox();
            this.chkRequestData = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbZoom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkZoom = new System.Windows.Forms.CheckBox();
            this.chkShowValues = new System.Windows.Forms.CheckBox();
            this.cbMap = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkKeepFocus = new System.Windows.Forms.CheckBox();
            this.nudPitch = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.chkpreventSleep = new System.Windows.Forms.CheckBox();
            this.cbMapService = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPitch)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(12, 22);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(194, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonRequestData
            // 
            this.buttonRequestData.Enabled = false;
            this.buttonRequestData.Location = new System.Drawing.Point(13, 80);
            this.buttonRequestData.Name = "buttonRequestData";
            this.buttonRequestData.Size = new System.Drawing.Size(193, 23);
            this.buttonRequestData.TabIndex = 1;
            this.buttonRequestData.Text = "Manual Request Position";
            this.buttonRequestData.UseVisualStyleBackColor = true;
            this.buttonRequestData.Click += new System.EventHandler(this.buttonRequestData_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(13, 51);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(193, 23);
            this.buttonDisconnect.TabIndex = 2;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // richResponse
            // 
            this.richResponse.Location = new System.Drawing.Point(13, 429);
            this.richResponse.Name = "richResponse";
            this.richResponse.Size = new System.Drawing.Size(193, 114);
            this.richResponse.TabIndex = 3;
            this.richResponse.Text = "";
            // 
            // chkUpdateMaps
            // 
            this.chkUpdateMaps.AutoSize = true;
            this.chkUpdateMaps.Checked = true;
            this.chkUpdateMaps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdateMaps.Location = new System.Drawing.Point(12, 190);
            this.chkUpdateMaps.Name = "chkUpdateMaps";
            this.chkUpdateMaps.Size = new System.Drawing.Size(179, 17);
            this.chkUpdateMaps.TabIndex = 4;
            this.chkUpdateMaps.Text = "Send Position to Windows Maps";
            this.chkUpdateMaps.UseVisualStyleBackColor = true;
            // 
            // cbRequestInterval
            // 
            this.cbRequestInterval.FormattingEnabled = true;
            this.cbRequestInterval.Items.AddRange(new object[] {
            "0.5",
            "1",
            "3",
            "5",
            "10",
            "15",
            "20",
            "30",
            "60",
            "90",
            "180"});
            this.cbRequestInterval.Location = new System.Drawing.Point(133, 163);
            this.cbRequestInterval.Name = "cbRequestInterval";
            this.cbRequestInterval.Size = new System.Drawing.Size(73, 21);
            this.cbRequestInterval.TabIndex = 5;
            // 
            // chkRequestData
            // 
            this.chkRequestData.AutoSize = true;
            this.chkRequestData.Enabled = false;
            this.chkRequestData.Location = new System.Drawing.Point(13, 140);
            this.chkRequestData.Name = "chkRequestData";
            this.chkRequestData.Size = new System.Drawing.Size(156, 17);
            this.chkRequestData.TabIndex = 6;
            this.chkRequestData.Text = "Automatic Request Position";
            this.chkRequestData.UseVisualStyleBackColor = true;
            this.chkRequestData.CheckedChanged += new System.EventHandler(this.chkRequestData_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Request Inverval (sec)";
            // 
            // cbZoom
            // 
            this.cbZoom.FormattingEnabled = true;
            this.cbZoom.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cbZoom.Location = new System.Drawing.Point(133, 213);
            this.cbZoom.Name = "cbZoom";
            this.cbZoom.Size = new System.Drawing.Size(73, 21);
            this.cbZoom.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "ZoomLevel";
            // 
            // chkZoom
            // 
            this.chkZoom.AutoSize = true;
            this.chkZoom.Location = new System.Drawing.Point(13, 240);
            this.chkZoom.Name = "chkZoom";
            this.chkZoom.Size = new System.Drawing.Size(158, 17);
            this.chkZoom.TabIndex = 10;
            this.chkZoom.Text = "Align Zoom Level to Altitude";
            this.chkZoom.UseVisualStyleBackColor = true;
            this.chkZoom.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkShowValues
            // 
            this.chkShowValues.AutoSize = true;
            this.chkShowValues.Location = new System.Drawing.Point(12, 397);
            this.chkShowValues.Name = "chkShowValues";
            this.chkShowValues.Size = new System.Drawing.Size(88, 17);
            this.chkShowValues.TabIndex = 11;
            this.chkShowValues.Text = "Show Values";
            this.chkShowValues.UseVisualStyleBackColor = true;
            // 
            // cbMap
            // 
            this.cbMap.FormattingEnabled = true;
            this.cbMap.Items.AddRange(new object[] {
            "Aerial",
            "Road"});
            this.cbMap.Location = new System.Drawing.Point(131, 262);
            this.cbMap.Name = "cbMap";
            this.cbMap.Size = new System.Drawing.Size(75, 21);
            this.cbMap.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Map Type";
            // 
            // chkKeepFocus
            // 
            this.chkKeepFocus.AutoSize = true;
            this.chkKeepFocus.Location = new System.Drawing.Point(12, 358);
            this.chkKeepFocus.Name = "chkKeepFocus";
            this.chkKeepFocus.Size = new System.Drawing.Size(153, 17);
            this.chkKeepFocus.TabIndex = 14;
            this.chkKeepFocus.Text = "Keep FS Window Focused";
            this.chkKeepFocus.UseVisualStyleBackColor = true;
            // 
            // nudPitch
            // 
            this.nudPitch.Location = new System.Drawing.Point(58, 302);
            this.nudPitch.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudPitch.Name = "nudPitch";
            this.nudPitch.Size = new System.Drawing.Size(75, 20);
            this.nudPitch.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Map Pitch (0 = Top / 90 = Horizontal)";
            // 
            // chkpreventSleep
            // 
            this.chkpreventSleep.AutoSize = true;
            this.chkpreventSleep.Location = new System.Drawing.Point(12, 335);
            this.chkpreventSleep.Name = "chkpreventSleep";
            this.chkpreventSleep.Size = new System.Drawing.Size(105, 17);
            this.chkpreventSleep.TabIndex = 17;
            this.chkpreventSleep.Text = "Keep Display On";
            this.chkpreventSleep.UseVisualStyleBackColor = true;
            this.chkpreventSleep.CheckedChanged += new System.EventHandler(this.chkpreventSleep_CheckedChanged);
            // 
            // cbMapService
            // 
            this.cbMapService.FormattingEnabled = true;
            this.cbMapService.Items.AddRange(new object[] {
            "Windows Maps",
            "Google Earth Pro"});
            this.cbMapService.Location = new System.Drawing.Point(13, 109);
            this.cbMapService.Name = "cbMapService";
            this.cbMapService.Size = new System.Drawing.Size(193, 21);
            this.cbMapService.TabIndex = 18;
            this.cbMapService.SelectedIndexChanged += new System.EventHandler(this.cbMapService_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 564);
            this.Controls.Add(this.cbMapService);
            this.Controls.Add(this.chkpreventSleep);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudPitch);
            this.Controls.Add(this.chkKeepFocus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbMap);
            this.Controls.Add(this.chkShowValues);
            this.Controls.Add(this.chkZoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbZoom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkRequestData);
            this.Controls.Add(this.cbRequestInterval);
            this.Controls.Add(this.chkUpdateMaps);
            this.Controls.Add(this.richResponse);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonRequestData);
            this.Controls.Add(this.buttonConnect);
            this.Name = "Main";
            this.Text = "FS Maps Connect";
            ((System.ComponentModel.ISupportInitialize)(this.nudPitch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonRequestData;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.RichTextBox richResponse;
        private System.Windows.Forms.CheckBox chkUpdateMaps;
        private System.Windows.Forms.ComboBox cbRequestInterval;
        private System.Windows.Forms.CheckBox chkRequestData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbZoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkZoom;
        private System.Windows.Forms.CheckBox chkShowValues;
        private System.Windows.Forms.ComboBox cbMap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkKeepFocus;
        private System.Windows.Forms.NumericUpDown nudPitch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkpreventSleep;
        private System.Windows.Forms.ComboBox cbMapService;
    }
}

