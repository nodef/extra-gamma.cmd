using System;
using System.Runtime.InteropServices;

namespace orez.ogamma.win32 {
	class oUser {

		// extern methods
		[DllImport("user32.dll")]
		public static extern IntPtr GetDC(IntPtr hWnd);
	}
}
