using System;
using System.IO;
using MavLink;

namespace MavLinkReader
{
    public class Util
    {
        StreamWriter Sw = null;
        int Total = 0;

        public void LogPressure(Msg_scaled_pressure sp)
        {
            int Prs = (int)(sp.press_abs * 1000f);
            int Tep = sp.temperature;
            int Dif = (int)(sp.press_diff * 1000f);

            if (Sw == null)
            {
                Sw = new StreamWriter("d:\\Baro.csv");
                Sw.Write("\"Item\", \"Pressure\", \"Temp\", \"Difference\"\r\n");
            }
            String S = String.Format("{0}, {1}, {2}, {3}\r\n", Total++, Prs, Tep, Dif);
            Sw.Write(S);

        }
    }
}
