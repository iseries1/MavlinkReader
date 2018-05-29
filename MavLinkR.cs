using System;
using System.ComponentModel;
using System.Windows.Forms;
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
        Msg_command_ack Ca = new Msg_command_ack();
        Msg_statustext St = new Msg_statustext();
        Msg_mission_count Mc = new Msg_mission_count();
        Msg_mission_item[] Mi = new Msg_mission_item[32];
        int Prs;
        int Tep;
        int Dif;
        int Systemid;
        int Componentid;
        int Sequence;
        Boolean HB = true;
        volatile int MI = -1;
        Util ut;

        public MavLinkReader()
        {
            InitializeComponent();
            Baud.SelectedIndex = 3;
            Ca.result = (byte)255;
            Mv.PacketReceived += Mv_PacketReceived;
            String[] P = System.IO.Ports.SerialPort.GetPortNames();
            if (P.Length > 0)
                Comm.Text = P[0];
            FlightModes.Items.AddRange(SMode);
            Mi[0] = new Msg_mission_item();
            ut = new Util();
        }

        void Mv_PacketReceived(object sender, MavLink.MavlinkPacket e)
        {
            uint x = Mv.PacketsReceived;
            Systemid = e.SystemId;
            Componentid = e.ComponentId;
            Sequence = e.SequenceNumber;
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
                /*
                 * Special log of Barometric data to the D drive
                 * Can be disable if not needed
                 */
                ut.LogPressure(Sp);
            }
            if (m.GetType() == Ca.GetType())
            {
                Ca = (Msg_command_ack)e.Message;
            }
            if (m.GetType() == St.GetType())
            {
                St = (Msg_statustext)e.Message;
            }
            if (m.GetType() == Mc.GetType())
            {
                Mc = (Msg_mission_count)e.Message;
                MI = 0;
                GetMissionValues.RunWorkerAsync();
            }
            if (m.GetType() == Mi[0].GetType())
            {
                Mi[MI++] = (Msg_mission_item)e.Message;
                if (MI >= Mc.count)
                    MI = -1;
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
            Start.Enabled = false;
            HeartBeat.RunWorkerAsync();
        }

        private void Dismiss(object sender, FormClosingEventArgs e)
        {
            if (Serial.IsOpen)
                Serial.Close();
        }

        private void Update(object sender, PaintEventArgs e)
        {
            Mode.Text = SMode[Hb.custom_mode];
            if (Ss != null)
            {
                BVolts.Text = String.Format("{0:f}", (float)Ss.voltage_battery / 1000.0f);
                BPercent.Text = String.Format("{0:d}%", Ss.battery_remaining);
                Current.Text = String.Format("{0:f}", (float)Ss.current_battery / 100.0f);
            }
            if ((Hb.base_mode & (byte)MAV_MODE_FLAG.MAV_MODE_FLAG_SAFETY_ARMED) != 0)
                Status.Text = "Armed";
            else
                Status.Text = "Not Armed";

            Seq.Text = String.Format("{0}", Sequence);

            if (At != null)
            {
                Roll.Text = String.Format("{0:f}", At.roll * 180 / 3.1415926);
                Pitch.Text = String.Format("{0:f}", At.pitch * 180 / 3.1415926);
                Yaw.Text = String.Format("{0:f}", At.yaw * 180 / 3.1415926);
            }
            if (Gps != null)
            {
                GpsFix.Text = String.Format("{0:d}", Gps.fix_type);
                Latitude.Text = String.Format("{0:00.000000}", (float)Gps.lat / 10000000.0f);
                Longitude.Text = String.Format("{0:00.000000}", (float)Gps.lon / 10000000.0f);
                Satellites.Text = String.Format("{0:d}", Gps.satellites_visible);
            }
            if (Vfr != null)
            {
                Altitude.Text = String.Format("{0:f}", Vfr.alt);
                Heading.Text = String.Format("{0:d}", Vfr.heading);
            }
            if (Ca != null)
            {
                if ((MAV_RESULT)Ca.result == MAV_RESULT.MAV_RESULT_ACCEPTED)
                    Results.Text = "Accepted";
                if ((MAV_RESULT)Ca.result == MAV_RESULT.MAV_RESULT_FAILED)
                    Results.Text = "Failed";
                if ((MAV_RESULT)Ca.result == MAV_RESULT.MAV_RESULT_TEMPORARILY_REJECTED)
                    Results.Text = "Rejected";
                if ((MAV_RESULT)Ca.result == MAV_RESULT.MAV_RESULT_UNSUPPORTED)
                    Results.Text = "Unsupported";
            }
            if (St.text != null)
            {
                char[] c = new char[St.text.Length];
                for (int i = 0; i < St.text.Length; i++)
                    c[i] = (char)St.text[i];
                Message.Text = new string(c);
            }
            if (Mc != null)
            {
                MissionItems.Text = String.Format("{0:d}", Mc.count);
            }
        }

        /*
         * Use this function to tell the copter what data you want to see and how often
         */
        private void RequestMav()
        {

            Msg_request_data_stream ds = new Msg_request_data_stream();
            ds.req_message_rate = 2;
            ds.req_stream_id = (byte)MAV_DATA_STREAM.MAV_DATA_STREAM_ALL;
            ds.start_stop = 1;
            ds.target_component = (byte)MAV_COMPONENT.MAV_COMP_ID_ALL;
            ds.target_system = (byte)Systemid;

            SendPacket(ds);
        }

        private void DoCmd(object sender, EventArgs e)
        {
            RequestMav();
        }

         private void HeartB(object sender, DoWorkEventArgs e)
        {
            int sec;

            sec = 0;

            while (HB)
            {
                Msg_heartbeat hb = new Msg_heartbeat();
                if (sec != DateTime.Now.Second)
                {
                    hb.type = 6;
                    hb.system_status = 0;
                    hb.custom_mode = 0;
                    hb.base_mode = 0;
                    hb.autopilot = 0;

                    SendPacket(hb);
                    sec = DateTime.Now.Second;
                }
            }
        }

        private void SendPacket(MavlinkMessage m)
        {
            MavlinkPacket p = new MavlinkPacket();
            p.Message = m;
            p.SequenceNumber = (byte)Sequence;
            p.SystemId = 255;
            p.ComponentId = (byte)MAV_COMPONENT.MAV_COMP_ID_MISSIONPLANNER;
            byte[] b = Mv.Send(p);
            Serial.Write(b, 0, b.Length);
        }

        private void StopHeartBeat(object sender, EventArgs e)
        {
            HB = false;
        }

        private void ChgFlight(object sender, EventArgs e)
        {
            if (!Serial.IsOpen)
                return;
            int i = FlightModes.SelectedIndex;
            Msg_set_mode m = new Msg_set_mode();
            m.base_mode = (byte)MAV_MODE_FLAG.MAV_MODE_FLAG_CUSTOM_MODE_ENABLED;
            m.custom_mode = (byte)i;
            m.target_system = (byte)MAV_AUTOPILOT.MAV_AUTOPILOT_RESERVED;

            SendPacket(m);
        }

        private void SendMission(object sender, EventArgs e)
        {
            Msg_mission_clear_all cl = new Msg_mission_clear_all();
            cl.target_component = (byte)MAV_COMPONENT.MAV_COMP_ID_ALL;
            cl.target_system = (byte)Systemid;
            SendPacket(cl);
            Msg_mission_item it = new Msg_mission_item();
            it.autocontinue = 1;
            it.command = (byte)MAV_CMD.MAV_CMD_NAV_TAKEOFF;
            it.current = 0;
            it.frame = (byte)MAV_FRAME.MAV_FRAME_GLOBAL_RELATIVE_ALT;
            it.seq = 1;
            SendPacket(it);
        }

        private void GetMission(object sender, EventArgs e)
        {
            Msg_mission_request_list rl = new Msg_mission_request_list();
            rl.target_component = (byte)MAV_COMPONENT.MAV_COMP_ID_ALL;
            rl.target_system = (byte)Systemid;
            SendPacket(rl);
        }

        /* Lacks retry logic in case mission recieved is missed */
        private void RecvMission(object sender, DoWorkEventArgs e)
        {
            int Pr = -1;

            while (MI >= 0)
            {
                if ((Pr != MI) && (MI >= 0))
                {
                    Msg_mission_request Mr = new Msg_mission_request();
                    Mr.seq = (byte)MI;
                    Mr.target_component = (byte)MAV_COMPONENT.MAV_COMP_ID_ALL;
                    Mr.target_system = (byte)Systemid;
                    SendPacket(Mr);
                    Pr = MI;
                }
            }
        }
    }

    public enum FLIGHT_MODES : ushort
    {
        MODE_STABILIZE = 0,
        MODE_ACRO = 1,
        MODE_ALT_HOLD = 2,
        MODE_AUTO = 3,
        MODE_GUIDED = 4,
        MODE_LOITER = 5,
        MODE_RTL = 6,
        MODE_CIRCLE = 7,
        MODE_LAND = 9,
        MODE_DRIFT = 11,
        MODE_SPORT = 13,
        MODE_FLIP = 14,
        MODE_AUTOTUNE = 15,
        MODE_POSHOLD = 16,
        MODE_BRAKE = 17,
        MODE_THROW = 18,
    }

}
