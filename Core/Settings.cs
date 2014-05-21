using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DeskClock.Core
{
    public static class Settings
    {
        public static void Save()
        {
            Properties.Settings.Default.Save();
        }

        public static double XPosition
        {
            get { return Properties.Settings.Default.XPosition; }
            set { Properties.Settings.Default.XPosition = value; }
        }

        public static double YPosition
        {
            get { return Properties.Settings.Default.YPosition; }
            set { Properties.Settings.Default.YPosition = value; }
        }

        public static int ClockFontSize
        {
            get { return Properties.Settings.Default.ClockFontSize; }
            set { Properties.Settings.Default.ClockFontSize = value; }
        }

        public static Color ClockColor
        {
            get { return Properties.Settings.Default.ClockColor; }
            set { Properties.Settings.Default.ClockColor = value; }
        }

        public static FontFamily ClockFontFamily
        {
            get { return Properties.Settings.Default.ClockFontFamily; }
            set { Properties.Settings.Default.ClockFontFamily = value; }
        }
    }
}
