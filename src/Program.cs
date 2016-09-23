using System;
using System.Collections.Generic;
using orez.ogamma.win32;
using orez.ogamma.math;

namespace orez.ogamma {
	class Program {

		// constant data
		private const string APP = "ogamma";


		// static method
		/// <summary>
		/// I can touch the sky,
		/// I know that i am alive.
		/// : Celine Dion
		/// </summary>
		/// <param name="args">Input arguments.</param>
		static void Main(string[] args) {
			oParams p = new oParams(args);
			if (args.Length == 0) { GetGdiRamp(); return; }
			if (p.Red.Count == 0) { Console.Error.WriteLine("{0}: no red values.", APP); return; }
			if (p.Green.Count == 0) { Console.Error.WriteLine("{0}: no green values.", APP); return; }
			if (p.Blue.Count == 0) { Console.Error.WriteLine("{0}: no blue values.", APP); return; }
			if (p.Ramp) {
				RampMin2(p.Red, p.Green, p.Blue);
				p.Red = oVector.GetLin(new double[oGdi.RAMP_SZ], p.Red);
				p.Green = oVector.GetLin(new double[oGdi.RAMP_SZ], p.Green);
				p.Blue = oVector.GetLin(new double[oGdi.RAMP_SZ], p.Blue);
			}
			else {
				p.Red = GetRamp(p.Red[0], oGdi.RAMP_SZ);
				p.Green = GetRamp(p.Green[0], oGdi.RAMP_SZ);
				p.Blue = GetRamp(p.Blue[0], oGdi.RAMP_SZ);
			}
			SetGdiRamp(p.Red, p.Green, p.Blue);
		}

		/// <summary>
		/// Make sure the red, green and blue ramps have minimum 2 values.
		/// </summary>
		/// <param name="red">Red floating-point ramp.</param>
		/// <param name="green">Green floating-point ramp.</param>
		/// <param name="blue">Blue floating-point ramp.</param>
		private static void RampMin2(IList<double> red, IList<double> green, IList<double> blue) {
			if (red.Count < 2) { red.Add(red[0]); red[0] = 0; }
			if (green.Count < 2) { green.Add(green[0]); green[0] = 0; }
			if (blue.Count < 2) { blue.Add(blue[0]); blue[0] = 0; }
		}

		/// <summary>
		/// Set Gdi Ramp from floating-point input ramps.
		/// </summary>
		/// <param name="r">Gdi Ramp.</param>
		/// <param name="red">Red floating-point ramp.</param>
		/// <param name="green">Green floating-point ramp.</param>
		/// <param name="blue">Blue floating-point ramp.</param>
		private static void SetGdiRamp(IList<double> red, IList<double> green, IList<double> blue) {
			oGdi.RAMP r = new oGdi.RAMP(null);
			oVector.Map(r.Red, UInt16.MinValue, UInt16.MaxValue, red, 0, 1);
			oVector.Map(r.Green, UInt16.MinValue, UInt16.MaxValue, green, 0, 1);
			oVector.Map(r.Blue, UInt16.MinValue, UInt16.MaxValue, blue, 0, 1);
			oGdi.SetDeviceGammaRamp(oUser.GetDC(IntPtr.Zero), ref r);
		}

		/// <summary>
		/// Get the current gamma ramp.
		/// </summary>
		private static void GetGdiRamp() {
			oGdi.RAMP r = new oGdi.RAMP(null);
			oGdi.GetDeviceGammaRamp(oUser.GetDC(IntPtr.Zero), ref r);
			IList<double> red = oVector.Map(null, 0, 1, r.Red, UInt16.MinValue, UInt16.MaxValue);
			IList<double> green = oVector.Map(null, 0, 1, r.Green, UInt16.MinValue, UInt16.MaxValue);
			IList<double> blue = oVector.Map(null, 0, 1, r.Blue, UInt16.MinValue, UInt16.MaxValue);
			Console.WriteLine("Red");
			oVector.Print(red);
			Console.WriteLine("Green");
			oVector.Print(green);
			Console.WriteLine("Blue");
			oVector.Print(blue);
		}

		/// <summary>
		/// Get double ramp from gamma value.
		/// </summary>
		/// <param name="g">Gamma value.</param>
		/// <param name="len">Output ramp length.</param>
		/// <returns>Ramp.</returns>
		private static IList<double> GetRamp(double g, int sz) {
			IList<double> d = oVector.LinSpace(null, 0, 1, sz);
			return oVector.Pow(d, d, g);
		}
	}
}
