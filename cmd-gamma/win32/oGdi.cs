using System;
using System.Runtime.InteropServices;

namespace orez.ogamma.win32 {
	class oGdi {

		// types
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct RAMP {
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = RAMP_SZ)]
			public UInt16[] Red;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = RAMP_SZ)]
			public UInt16[] Green;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = RAMP_SZ)]
			public UInt16[] Blue;
		};


		// constant data
		public const int RAMP_SZ = 256;


		// extern methods
		[DllImport("gdi32.dll")]
		public static extern bool SetDeviceGammaRamp(IntPtr hDC, ref RAMP lpRamp);
		[DllImport("gdi32.dll")]
		public static extern bool GetDeviceGammaRamp(IntPtr hDC, ref RAMP lpRamp);
	}
}
