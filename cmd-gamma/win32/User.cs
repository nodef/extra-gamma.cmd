using System;
using System.Runtime.InteropServices;

namespace cmd_gamma.win32 {
	class User {

		// extern methods
		[DllImport("user32.dll")]
		public static extern IntPtr GetDC(IntPtr hWnd);
	}
}
