using System;
using System.Collections.Generic;

namespace orez.ogamma.math {
	class oVector {

		// static method
		/// <summary>
		/// Raise every component by specicied exponent.
		/// </summary>
		/// <param name="o">Output vector.</param>
		/// <param name="v">Input vector.</param>
		/// <param name="exp">Exponent.</param>
		/// <returns>New vector.</returns>
		public static IList<double> Pow(IList<double> o, IList<double> v, double exp) {
			o = o == null ? new double[v.Count] : o;
			for (int i = 0; i < v.Count; i++)
				o[i] = Math.Pow(v[i], exp);
			return o;
		}

		/// <summary>
		/// Get piecewise linear value at specified position.
		/// </summary>
		/// <param name="v">Input vector.</param>
		/// <param name="p">Position, ranging from 0 to 1.</param>
		/// <returns>Piecewise linear value.</returns>
		public static double GetPiecewiseLinear(IList<double> v, double p) {
			double pi = p * (v.Count - 1);
			int i0 = (int)pi, i1 = (int)(pi + 1);
			double pf = pi - i0;
			return v[i0] * (1 - pf) + v[i1] * pf;
		}
	}
}
