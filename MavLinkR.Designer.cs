namespace MavLinkReader
{
    partial class MavLinkReader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LCom = new System.Windows.Forms.Label();
            this.LBaud = new System.Windows.Forms.Label();
            this.Comm = new System.Windows.Forms.TextBox();
            this.Baud = new System.Windows.Forms.ComboBox();
            this.Start = new System.Windows.Forms.Button();
            this.Serial = new System.IO.Ports.SerialPort(this.components);
            this.LStatus = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.LMode = new System.Windows.Forms.Label();
            this.Mode = new System.Windows.Forms.Label();
            this.LBattery = new System.Windows.Forms.Label();
            this.BVolts = new System.Windows.Forms.Label();
            this.LBPercent = new System.Windows.Forms.Label();
            this.BPercent = new System.Windows.Forms.Label();
            this.LCurrent = new System.Windows.Forms.Label();
            this.Current = new System.Windows.Forms.Label();
            this.LRoll = new System.Windows.Forms.Label();
            this.Roll = new System.Windows.Forms.Label();
            this.LPitch = new System.Windows.Forms.Label();
            this.Pitch = new System.Windows.Forms.Label();
            this.LYaw = new System.Windows.Forms.Label();
            this.Yaw = new System.Windows.Forms.Label();
            this.LGpsf = new System.Windows.Forms.Label();
            this.GpsFix = new System.Windows.Forms.Label();
            this.LLatitude = new System.Windows.Forms.Label();
            this.Latitude = new System.Windows.Forms.Label();
            this.LLongitude = new System.Windows.Forms.Label();
            this.Longitude = new System.Windows.Forms.Label();
            this.LSatellites = new System.Windows.Forms.Label();
            this.Satellites = new System.Windows.Forms.Label();
            this.LAltitude = new System.Windows.Forms.Label();
            this.Altitude = new System.Windows.Forms.Label();
            this.LHeading = new System.Windows.Forms.Label();
            this.Heading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LCom
            // 
            this.LCom.AutoSize = true;
            this.LCom.ForeColor = System.Drawing.Color.Lime;
            this.LCom.Location = new System.Drawing.Point(21, 33);
            this.LCom.Name = "LCom";
            this.LCom.Size = new System.Drawing.Size(42, 16);
            this.LCom.TabIndex = 0;
            this.LCom.Text = "COM:";
            // 
            // LBaud
            // 
            this.LBaud.AutoSize = true;
            this.LBaud.ForeColor = System.Drawing.Color.Lime;
            this.LBaud.Location = new System.Drawing.Point(21, 62);
            this.LBaud.Name = "LBaud";
            this.LBaud.Size = new System.Drawing.Size(48, 16);
            this.LBaud.TabIndex = 0;
            this.LBaud.Text = "BAUD:";
            // 
            // Comm
            // 
            this.Comm.Location = new System.Drawing.Point(86, 33);
            this.Comm.Name = "Comm";
            this.Comm.Size = new System.Drawing.Size(100, 22);
            this.Comm.TabIndex = 1;
            this.Comm.Text = "COM16";
            // 
            // Baud
            // 
            this.Baud.FormattingEnabled = true;
            this.Baud.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.Baud.Location = new System.Drawing.Point(86, 62);
            this.Baud.Name = "Baud";
            this.Baud.Size = new System.Drawing.Size(121, 24);
            this.Baud.TabIndex = 2;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(24, 142);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 3;
            this.Start.Text = "Connect";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.ReadData);
            // 
            // Serial
            // 
            this.Serial.BaudRate = 57600;
            this.Serial.PortName = "COM16";
            this.Serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Data);
            // 
            // LStatus
            // 
            this.LStatus.AutoSize = true;
            this.LStatus.ForeColor = System.Drawing.Color.Lime;
            this.LStatus.Location = new System.Drawing.Point(12, 202);
            this.LStatus.Name = "LStatus";
            this.LStatus.Size = new System.Drawing.Size(50, 16);
            this.LStatus.TabIndex = 0;
            this.LStatus.Text = "Status:";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(80, 202);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(30, 16);
            this.Status.TabIndex = 4;
            this.Status.Text = "N/A";
            // 
            // LMode
            // 
            this.LMode.AutoSize = true;
            this.LMode.ForeColor = System.Drawing.Color.Lime;
            this.LMode.Location = new System.Drawing.Point(157, 202);
            this.LMode.Name = "LMode";
            this.LMode.Size = new System.Drawing.Size(44, 16);
            this.LMode.TabIndex = 0;
            this.LMode.Text = "Mode:";
            // 
            // Mode
            // 
            this.Mode.AutoSize = true;
            this.Mode.Location = new System.Drawing.Point(220, 202);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(30, 16);
            this.Mode.TabIndex = 4;
            this.Mode.Text = "N/A";
            // 
            // LBattery
            // 
            this.LBattery.AutoSize = true;
            this.LBattery.ForeColor = System.Drawing.Color.Lime;
            this.LBattery.Location = new System.Drawing.Point(12, 218);
            this.LBattery.Name = "LBattery";
            this.LBattery.Size = new System.Drawing.Size(54, 16);
            this.LBattery.TabIndex = 0;
            this.LBattery.Text = "Battery:";
            // 
            // BVolts
            // 
            this.BVolts.AutoSize = true;
            this.BVolts.Location = new System.Drawing.Point(80, 218);
            this.BVolts.Name = "BVolts";
            this.BVolts.Size = new System.Drawing.Size(30, 16);
            this.BVolts.TabIndex = 4;
            this.BVolts.Text = "N/A";
            // 
            // LBPercent
            // 
            this.LBPercent.AutoSize = true;
            this.LBPercent.ForeColor = System.Drawing.Color.Lime;
            this.LBPercent.Location = new System.Drawing.Point(157, 218);
            this.LBPercent.Name = "LBPercent";
            this.LBPercent.Size = new System.Drawing.Size(57, 16);
            this.LBPercent.TabIndex = 0;
            this.LBPercent.Text = "Percent:";
            // 
            // BPercent
            // 
            this.BPercent.AutoSize = true;
            this.BPercent.Location = new System.Drawing.Point(220, 218);
            this.BPercent.Name = "BPercent";
            this.BPercent.Size = new System.Drawing.Size(30, 16);
            this.BPercent.TabIndex = 4;
            this.BPercent.Text = "N/A";
            // 
            // LCurrent
            // 
            this.LCurrent.AutoSize = true;
            this.LCurrent.ForeColor = System.Drawing.Color.Lime;
            this.LCurrent.Location = new System.Drawing.Point(299, 218);
            this.LCurrent.Name = "LCurrent";
            this.LCurrent.Size = new System.Drawing.Size(54, 16);
            this.LCurrent.TabIndex = 0;
            this.LCurrent.Text = "Current:";
            // 
            // Current
            // 
            this.Current.AutoSize = true;
            this.Current.Location = new System.Drawing.Point(373, 218);
            this.Current.Name = "Current";
            this.Current.Size = new System.Drawing.Size(30, 16);
            this.Current.TabIndex = 4;
            this.Current.Text = "N/A";
            // 
            // LRoll
            // 
            this.LRoll.AutoSize = true;
            this.LRoll.ForeColor = System.Drawing.Color.Lime;
            this.LRoll.Location = new System.Drawing.Point(12, 234);
            this.LRoll.Name = "LRoll";
            this.LRoll.Size = new System.Drawing.Size(34, 16);
            this.LRoll.TabIndex = 0;
            this.LRoll.Text = "Roll:";
            // 
            // Roll
            // 
            this.Roll.AutoSize = true;
            this.Roll.Location = new System.Drawing.Point(80, 234);
            this.Roll.Name = "Roll";
            this.Roll.Size = new System.Drawing.Size(30, 16);
            this.Roll.TabIndex = 4;
            this.Roll.Text = "N/A";
            // 
            // LPitch
            // 
            this.LPitch.AutoSize = true;
            this.LPitch.ForeColor = System.Drawing.Color.Lime;
            this.LPitch.Location = new System.Drawing.Point(157, 234);
            this.LPitch.Name = "LPitch";
            this.LPitch.Size = new System.Drawing.Size(42, 16);
            this.LPitch.TabIndex = 0;
            this.LPitch.Text = "Pitch:";
            // 
            // Pitch
            // 
            this.Pitch.AutoSize = true;
            this.Pitch.Location = new System.Drawing.Point(220, 234);
            this.Pitch.Name = "Pitch";
            this.Pitch.Size = new System.Drawing.Size(30, 16);
            this.Pitch.TabIndex = 4;
            this.Pitch.Text = "N/A";
            // 
            // LYaw
            // 
            this.LYaw.AutoSize = true;
            this.LYaw.ForeColor = System.Drawing.Color.Lime;
            this.LYaw.Location = new System.Drawing.Point(299, 234);
            this.LYaw.Name = "LYaw";
            this.LYaw.Size = new System.Drawing.Size(36, 16);
            this.LYaw.TabIndex = 0;
            this.LYaw.Text = "Yaw:";
            // 
            // Yaw
            // 
            this.Yaw.AutoSize = true;
            this.Yaw.Location = new System.Drawing.Point(373, 234);
            this.Yaw.Name = "Yaw";
            this.Yaw.Size = new System.Drawing.Size(30, 16);
            this.Yaw.TabIndex = 4;
            this.Yaw.Text = "N/A";
            // 
            // LGpsf
            // 
            this.LGpsf.AutoSize = true;
            this.LGpsf.ForeColor = System.Drawing.Color.Lime;
            this.LGpsf.Location = new System.Drawing.Point(12, 250);
            this.LGpsf.Name = "LGpsf";
            this.LGpsf.Size = new System.Drawing.Size(62, 16);
            this.LGpsf.TabIndex = 0;
            this.LGpsf.Text = "GPS Fix:";
            // 
            // GpsFix
            // 
            this.GpsFix.AutoSize = true;
            this.GpsFix.Location = new System.Drawing.Point(80, 250);
            this.GpsFix.Name = "GpsFix";
            this.GpsFix.Size = new System.Drawing.Size(30, 16);
            this.GpsFix.TabIndex = 4;
            this.GpsFix.Text = "N/A";
            // 
            // LLatitude
            // 
            this.LLatitude.AutoSize = true;
            this.LLatitude.ForeColor = System.Drawing.Color.Lime;
            this.LLatitude.Location = new System.Drawing.Point(157, 250);
            this.LLatitude.Name = "LLatitude";
            this.LLatitude.Size = new System.Drawing.Size(58, 16);
            this.LLatitude.TabIndex = 0;
            this.LLatitude.Text = "Latitude:";
            // 
            // Latitude
            // 
            this.Latitude.AutoSize = true;
            this.Latitude.Location = new System.Drawing.Point(221, 250);
            this.Latitude.Name = "Latitude";
            this.Latitude.Size = new System.Drawing.Size(30, 16);
            this.Latitude.TabIndex = 4;
            this.Latitude.Text = "N/A";
            // 
            // LLongitude
            // 
            this.LLongitude.AutoSize = true;
            this.LLongitude.ForeColor = System.Drawing.Color.Lime;
            this.LLongitude.Location = new System.Drawing.Point(299, 250);
            this.LLongitude.Name = "LLongitude";
            this.LLongitude.Size = new System.Drawing.Size(68, 16);
            this.LLongitude.TabIndex = 0;
            this.LLongitude.Text = "Longitude:";
            // 
            // Longitude
            // 
            this.Longitude.AutoSize = true;
            this.Longitude.Location = new System.Drawing.Point(373, 250);
            this.Longitude.Name = "Longitude";
            this.Longitude.Size = new System.Drawing.Size(30, 16);
            this.Longitude.TabIndex = 4;
            this.Longitude.Text = "N/A";
            // 
            // LSatellites
            // 
            this.LSatellites.AutoSize = true;
            this.LSatellites.ForeColor = System.Drawing.Color.Lime;
            this.LSatellites.Location = new System.Drawing.Point(12, 266);
            this.LSatellites.Name = "LSatellites";
            this.LSatellites.Size = new System.Drawing.Size(66, 16);
            this.LSatellites.TabIndex = 0;
            this.LSatellites.Text = "Satellites:";
            // 
            // Satellites
            // 
            this.Satellites.AutoSize = true;
            this.Satellites.Location = new System.Drawing.Point(80, 266);
            this.Satellites.Name = "Satellites";
            this.Satellites.Size = new System.Drawing.Size(30, 16);
            this.Satellites.TabIndex = 4;
            this.Satellites.Text = "N/A";
            // 
            // LAltitude
            // 
            this.LAltitude.AutoSize = true;
            this.LAltitude.ForeColor = System.Drawing.Color.Lime;
            this.LAltitude.Location = new System.Drawing.Point(12, 282);
            this.LAltitude.Name = "LAltitude";
            this.LAltitude.Size = new System.Drawing.Size(56, 16);
            this.LAltitude.TabIndex = 0;
            this.LAltitude.Text = "Altitude:";
            // 
            // Altitude
            // 
            this.Altitude.AutoSize = true;
            this.Altitude.Location = new System.Drawing.Point(80, 282);
            this.Altitude.Name = "Altitude";
            this.Altitude.Size = new System.Drawing.Size(30, 16);
            this.Altitude.TabIndex = 4;
            this.Altitude.Text = "N/A";
            // 
            // LHeading
            // 
            this.LHeading.AutoSize = true;
            this.LHeading.ForeColor = System.Drawing.Color.Lime;
            this.LHeading.Location = new System.Drawing.Point(157, 282);
            this.LHeading.Name = "LHeading";
            this.LHeading.Size = new System.Drawing.Size(59, 16);
            this.LHeading.TabIndex = 0;
            this.LHeading.Text = "Heading:";
            // 
            // Heading
            // 
            this.Heading.AutoSize = true;
            this.Heading.Location = new System.Drawing.Point(220, 282);
            this.Heading.Name = "Heading";
            this.Heading.Size = new System.Drawing.Size(30, 16);
            this.Heading.TabIndex = 4;
            this.Heading.Text = "N/A";
            // 
            // MavLinkReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 436);
            this.Controls.Add(this.Longitude);
            this.Controls.Add(this.Yaw);
            this.Controls.Add(this.Current);
            this.Controls.Add(this.Heading);
            this.Controls.Add(this.Latitude);
            this.Controls.Add(this.Pitch);
            this.Controls.Add(this.BPercent);
            this.Controls.Add(this.Mode);
            this.Controls.Add(this.Altitude);
            this.Controls.Add(this.Satellites);
            this.Controls.Add(this.GpsFix);
            this.Controls.Add(this.Roll);
            this.Controls.Add(this.BVolts);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Baud);
            this.Controls.Add(this.Comm);
            this.Controls.Add(this.LLongitude);
            this.Controls.Add(this.LYaw);
            this.Controls.Add(this.LCurrent);
            this.Controls.Add(this.LHeading);
            this.Controls.Add(this.LLatitude);
            this.Controls.Add(this.LPitch);
            this.Controls.Add(this.LBPercent);
            this.Controls.Add(this.LMode);
            this.Controls.Add(this.LAltitude);
            this.Controls.Add(this.LSatellites);
            this.Controls.Add(this.LGpsf);
            this.Controls.Add(this.LRoll);
            this.Controls.Add(this.LBattery);
            this.Controls.Add(this.LStatus);
            this.Controls.Add(this.LBaud);
            this.Controls.Add(this.LCom);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MavLinkReader";
            this.Text = "MavLink";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dismiss);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Update);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LCom;
        private System.Windows.Forms.Label LBaud;
        private System.Windows.Forms.TextBox Comm;
        private System.Windows.Forms.ComboBox Baud;
        private System.Windows.Forms.Button Start;
        private System.IO.Ports.SerialPort Serial;
        private System.Windows.Forms.Label LStatus;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label LMode;
        private System.Windows.Forms.Label Mode;
        private System.Windows.Forms.Label LBattery;
        private System.Windows.Forms.Label BVolts;
        private System.Windows.Forms.Label LBPercent;
        private System.Windows.Forms.Label BPercent;
        private System.Windows.Forms.Label LCurrent;
        private System.Windows.Forms.Label Current;
        private System.Windows.Forms.Label LRoll;
        private System.Windows.Forms.Label Roll;
        private System.Windows.Forms.Label LPitch;
        private System.Windows.Forms.Label Pitch;
        private System.Windows.Forms.Label LYaw;
        private System.Windows.Forms.Label Yaw;
        private System.Windows.Forms.Label LGpsf;
        private System.Windows.Forms.Label GpsFix;
        private System.Windows.Forms.Label LLatitude;
        private System.Windows.Forms.Label Latitude;
        private System.Windows.Forms.Label LLongitude;
        private System.Windows.Forms.Label Longitude;
        private System.Windows.Forms.Label LSatellites;
        private System.Windows.Forms.Label Satellites;
        private System.Windows.Forms.Label LAltitude;
        private System.Windows.Forms.Label Altitude;
        private System.Windows.Forms.Label LHeading;
        private System.Windows.Forms.Label Heading;
    }
}

