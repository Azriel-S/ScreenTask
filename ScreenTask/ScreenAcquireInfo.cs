using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenTask
{
    public enum ScreenCaptureStyle
    {
        CaptureFullScreen,
        CapturePrimaryScreen,
        CaptureIndividualScreen
    }

    public class ScreenAcquireInfo
    {
        public ScreenCaptureStyle ScreenCaptureStyle { get; set; }

        public string DeviceName { get; set; }

        public double ScalingFactor { get; set; } = 1.0;
    }
}
