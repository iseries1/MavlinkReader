using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MavLink;

namespace MavLinkReader
{
    public partial class MavLinkReader : Form
    {
        String[] SMode = { "Stabilize", "Acrobatic", "Alt Hold ", "Auto     ", "Guided   ", "Loiter   ", "RTL      ",
"Circle   ", "Position ", "Land     ", "OF_Loiter", "Drift    ", "None     ", "Sport    ", "Flip     ",
"Auto Tune", "Pos Hold" };

        Mavlink Mv = new Mavlink();
        Msg_heartbeat Hb = new Msg_heartbeat();
        Msg_sys_status Ss = new Msg_sys_status();
        Msg_power_status Ps = new Msg_power_status();
        Msg_attitude At = new Msg_attitude();
        Msg_gps_raw_int Gps = new Msg_gps_raw_int();
        Msg_vfr_hud Vfr = new Msg_vfr_hud();
        Msg_data_stream Ds = new Msg_data_stream();
        Msg_raw_pressure Rp = new Msg_raw_pressure();
        Msg_scaled_pressure Sp = new Msg_scaled_pressure();
        int Total = 0;
        int Prs;
        int Tep;
        int Dif;
        StreamWriter Sw = null;


        public MavLinkReader()
        {
            InitializeComponent();
            Baud.SelectedIndex = 3;
            Mv.PacketReceived += Mv_PacketReceived;
        }

        void Mv_PacketReceived(object sender, MavLink.MavlinkPacket e)
        {
            uint x = Mv.PacketsReceived;
            MavlinkMessage m = e.Message;
            if (m.GetType() == Hb.GetType())
                Hb = (Msg_heartbeat)e.Message;
            if (m.GetType() == Ss.GetType())
                Ss = (Msg_sys_status)e.Message;
            if (m.GetType() == Ps.GetType())
                Ps = (Msg_power_status)e.Message;
            if (m.GetType() == At.GetType())
                At = (Msg_attitude)e.Message;
            if (m.GetType() == Gps.GetType())
                Gps = (Msg_gps_raw_int)e.Message;
            if (m.GetType() == Vfr.GetType())
                Vfr = (Msg_vfr_hud)e.Message;
            if (m.GetType() == Rp.GetType())
            {
                Rp = (Msg_raw_pressure)e.Message;

            }
            if (m.GetType() == Sp.GetType())
            {
                Sp = (Msg_scaled_pressure)e.Message;
                Prs = (int)(Sp.press_abs * 1000f);
                Tep = Sp.temperature;
                Dif = (int)(Sp.press_diff * 1000f);
                if (Sw == null)
                {
                    Sw = new StreamWriter("c:\\Baro.csv");
                    Sw.Write("\"Item\", \"Pressure\", \"Temp\", \"Difference\"\r\n");
                }
                String S = String.Format("{0}, {1}, {2}, {3}\r\n", Total++, Prs, Tep, Dif);
                Sw.Write(S);
            }
            if (x > 0)
            {
                if (MavLinkReader.ActiveForm != null)
                    MavLinkReader.ActiveForm.Invalidate();
            }
        }

        private void Data(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int x = Serial.BytesToRead;
            byte[] b = new byte[x];
            for (int i=0;i<x;i++)
                b[i] = (byte)Serial.ReadByte();
            Mv.ParseBytes(b);
        }

        private void ReadData(object sender, EventArgs e)
        {
            Serial.BaudRate = int.Parse(Baud.Text);
            Serial.PortName = Comm.Text;
            Serial.Open();
        }

        private void Dismiss(object sender, FormClosingEventArgs e)
        {
            if (Serial.IsOpen)
                Serial.Close();
        }

        private void Update(object sender, PaintEventArgs e)
        {
            Mode.Text = SMode[Hb.custom_mode];
            BVolts.Text = String.Format("{0:f}", (float)Ss.voltage_battery / 1000.0f);
            BPercent.Text = String.Format("{0:d}%", Ss.battery_remaining);
            Current.Text = String.Format("{0:f}", (float)Ss.current_battery / 100.0f);
            if ((Hb.base_mode & (byte)MAV_MODE_FLAG.MAV_MODE_FLAG_SAFETY_ARMED) != 0)
                Status.Text = "Armed";
            else
                Status.Text = "Not Armed";
            Roll.Text = String.Format("{0:f}", At.roll*180/3.1415926);
            Pitch.Text = String.Format("{0:f}", At.pitch*180/3.1415926);
            Yaw.Text = String.Format("{0:f}", At.yaw*180/3.1415926);
            GpsFix.Text = String.Format("{0:d}", Gps.fix_type);
            Latitude.Text = String.Format("{0:00.000000}", (float)Gps.lat / 10000000.0f);
            Longitude.Text = String.Format("{0:00.000000}", (float)Gps.lon / 10000000.0f);
            Satellites.Text = String.Format("{0:d}", Gps.satellites_visible);
            Altitude.Text = String.Format("{0:f}", Vfr.alt);
            Heading.Text = String.Format("{0:d}", Vfr.heading);
        }

        private void RequestMav()
        {
            Ds.message_rate = 2;
            Ds.on_off = 1;
            Ds.stream_id = (byte)MAV_DATA_STREAM.MAV_DATA_STREAM_ALL;

            MavlinkPacket p = new MavlinkPacket();


        }
    }
}
