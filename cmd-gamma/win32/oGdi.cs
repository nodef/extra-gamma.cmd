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

			// constructor
			/// <summary>
			/// Define red, blue and green arrays.
			/// </summary>
			/// <param name="r">Red array.</param>
			/// <param name="g">Green array.</param>
			/// <param name="b">Blue array.</param>
			public RAMP(UInt16[] r = null, UInt16[] g = null, UInt16[] b = null) {
				Red = r == null ? new UInt16[RAMP_SZ] : r;
				Green = g == null ? new UInt16[RAMP_SZ] : g;
				Blue = b == null ? new UInt16[RAMP_SZ] : b;
			}
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
