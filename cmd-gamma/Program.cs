using System;
using cmd_gamma.win32;

namespace cmd_gamma {
	class Program {
		static void Main(string[] args) {
			oGdi.RAMP r = new oGdi.RAMP();
			r.Red = new UInt16[256];
			r.Green = new UInt16[256];
			r.Blue = new UInt16[256];
			for (int i = 0; i < 256; i++)
				r.Red[i] = r.Green[i] = r.Blue[i] = (UInt16)(i*200 + 50);
			oGdi.SetDeviceGammaRamp(oUser.GetDC(IntPtr.Zero), ref r);
		}
	}
}
