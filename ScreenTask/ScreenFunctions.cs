using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenTask
{
    static class ScreenFunctions
    {
        public static List<string> DeviceNames()
        {
            List<string> deviceNames = new List<string>{"All Screens", "Primary Screen"};

            foreach (var screen in Screen.AllScreens)
            {
                deviceNames.Add(screen.DeviceName);
            }

            return deviceNames;
        }

        public static Rectangle GetScreenBounds(ScreenAcquireInfo screenAcquireInfo)
        {
            Rectangle bounds;

            switch (screenAcquireInfo.ScreenCaptureStyle)
            {
                default:
                case ScreenCaptureStyle.CaptureFullScreen:
                    bounds = CaptureFullScreen();
                    break;

                case ScreenCaptureStyle.CapturePrimaryScreen:
                    bounds = CapturePrimaryScreen();
                    break;

                case ScreenCaptureStyle.CaptureIndividualScreen:
                    bounds = CaptureIndividualScreen(screenAcquireInfo);
                    break;
            }

            bounds = new Rectangle(bounds.Left, bounds.Top,(int)Math.Floor(bounds.Width * screenAcquireInfo.ScalingFactor), 
                (int)Math.Floor(bounds.Height * screenAcquireInfo.ScalingFactor));

            return bounds;
        }

        static Rectangle CaptureFullScreen()
        {
            var allBounds = Screen.AllScreens.Select(s => s.Bounds).ToArray();
            Rectangle bounds = Rectangle.FromLTRB(allBounds.Min(b => b.Left), allBounds.Min(b => b.Top), allBounds.Max(b => b.Right), allBounds.Max(b => b.Bottom));

            return bounds;
        }

        static Rectangle CapturePrimaryScreen()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;

            return bounds;
        }

        static Rectangle CaptureIndividualScreen(ScreenAcquireInfo screenAcquireInfo)
        {
            var bounds = new Rectangle(0, 0, 100, 100);

            foreach (var screen in Screen.AllScreens)
            {
                if (screenAcquireInfo.DeviceName == screen.DeviceName)
                {
                    bounds = screen.Bounds;
                }
            }

            return bounds;
        }
    }
}
