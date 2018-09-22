using System;
using System.Runtime.InteropServices;

namespace App.win32 {
	class EUser {

		// extern methods
		[DllImport("user32.dll")]
		public static extern IntPtr GetDC(IntPtr hWnd);
	}
}
