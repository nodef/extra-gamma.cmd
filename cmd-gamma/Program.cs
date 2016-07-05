using System;
using cmd_gamma.win32;

namespace cmd_gamma {
	class Program {
		static void Main(string[] args) {
			Gdi.RAMP r = new Gdi.RAMP();
			r.Red = new UInt16[256];
			r.Green = new UInt16[256];
			r.Blue = new UInt16[256];
			for (int i = 0; i < 256; i++)
				r.Red[i] = r.Green[i] = r.Blue[i] = (UInt16)(i*200 + 50);
			Gdi.SetDeviceGammaRamp(User.GetDC(IntPtr.Zero), ref r);
		}
	}
}
