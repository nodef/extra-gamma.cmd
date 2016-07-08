using System;
using System.Collections.Generic;
using orez.ogamma.win32;
using orez.ogamma.math;

namespace orez.ogamma {
	class Program {

		// static method
		/// <summary>
		/// I can touch the sky,
		/// I know that i am alive.
		/// : Celine Dion
		/// </summary>
		/// <param name="args">Input arguments.</param>
		static void Main(string[] args) {
			args = new string[] { "--ramp", "0.0", "0.5", "1.0" };
			oParams p = new oParams(args);
			if (!p.Ramp) SetGammaRamps(p);
			oGdi.RAMP r = new oGdi.RAMP();
			SetGdiRamp(ref r, p.Red, p.Green, p.Blue);
			oGdi.SetDeviceGammaRamp(oUser.GetDC(IntPtr.Zero), ref r);
		}

		/// <summary>
		/// Set Gdi Ramp from floating-point input ramps.
		/// </summary>
		/// <param name="r">Gdi Ramp.</param>
		/// <param name="red">Red floating-point ramp.</param>
		/// <param name="green">Green floating-point ramp.</param>
		/// <param name="blue">Blue floating-point ramp.</param>
		private static void SetGdiRamp(ref oGdi.RAMP r, IList<double> red, IList<double> green, IList<double> blue) {
			r.Red = GetUint16Ramp(oGdi.RAMP_SZ, red);
			r.Green = GetUint16Ramp(oGdi.RAMP_SZ, green);
			r.Blue = GetUint16Ramp(oGdi.RAMP_SZ, blue);
		}

		/// <summary>
		/// Get UInt16 ramp from piecewise-linear floating-point ramp.
		/// </summary>
		/// <param name="len">UInt16 ramp length.</param>
		/// <param name="ramp">Input floating-point ramp.</param>
		/// <returns>UInt16 ramp.</returns>
		private static UInt16[] GetUint16Ramp(int len, IList<double> ramp) {
			UInt16[] o = new UInt16[len];
			double p = 0, pd = 1.0 / len;
			for (int i = 0; i < len; i++, p += pd)
				o[i] = (UInt16)(UInt16.MaxValue * oVector.GetPiecewiseLinear(ramp, p));
			return o;
		}

		/// <summary>
		/// Set gamma ramps for red, green and blue components.
		/// </summary>
		/// <param name="p">Input parameters.</param>
		private static void SetGammaRamps(oParams p) {
			p.Red = GammaRamp(oGdi.RAMP_SZ, p.Red[0]);
			p.Green = GammaRamp(oGdi.RAMP_SZ, p.Green[0]);
			p.Blue = GammaRamp(oGdi.RAMP_SZ, p.Blue[0]);
		}

		/// <summary>
		/// Get gamma ramp.
		/// </summary>
		/// <param name="g">Gamma value.</param>
		/// <param name="len">Output ramp length.</param>
		/// <returns>Ramp.</returns>
		private static IList<double> GammaRamp(int len, double g) {
			double[] o = new double[len];
			double p = 0, pd = 1.0 / len;
			for (int i = 0; i < len; i++, p += pd)
				o[i] = p;
			return oVector.Pow(o, o, g);
		}
	}
}
