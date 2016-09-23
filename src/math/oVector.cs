using System;
using System.Collections.Generic;

namespace orez.ogamma.math {
	class oVector {

		// static method
		/// <summary>
		/// Map a double vector to ushort vector.
		/// </summary>
		/// <param name="d">Destination vector.</param>
		/// <param name="d0">Destination range begin.</param>
		/// <param name="d1">Destination range end.</param>
		/// <param name="s">Source vector.</param>
		/// <param name="s0">Source range begin.</param>
		/// <param name="s1">Source range end.</param>
		/// <returns>Mapped ushort vector.</returns>
		public static IList<ushort> Map(IList<ushort> d, ushort d0, ushort d1, IList<double> s, double s0, double s1) {
			double f = (d1 - d0) / (s1 - s0);
			d = d == null ? new ushort[s.Count] : d;
			for (int i = 0, I = Math.Min(d.Count, s.Count); i < I; i++)
				d[i] = (ushort)((s[i] - s0) * f + d0);
			return d;
		}
		/// <summary>
		/// Map a ushort vector to double vector.
		/// </summary>
		/// <param name="d">Output vector.</param>
		/// <param name="d0">Output range begin.</param>
		/// <param name="d1">Output range end.</param>
		/// <param name="s">Input vector.</param>
		/// <param name="s0">Input range begin.</param>
		/// <param name="s1">Input range end.</param>
		/// <returns>Mapped double vector.</returns>
		public static IList<double> Map(IList<double> d, double d0, double d1, IList<ushort> s, ushort s0, ushort s1) {
			double f = (d1 - d0) / (s1 - s0);
			d = d == null ? new double[s.Count] : d;
			for (int i = 0; i < d.Count; i++)
				d[i] = (s[i] - s0) * f + d0;
			return d;
		}

		/// <summary>
		/// Get linearly spaced values of specified length.
		/// </summary>
		/// <param name="d">Output vector.</param>
		/// <param name="d0">Range start.</param>
		/// <param name="d1">Range end.</param>
		/// <param name="n">Length.</param>
		/// <returns>Linearly spaced values vector.</returns>
		public static IList<double> LinSpace(IList<double> d, double d0, double d1, int n) {
			double v = d0, vd = (d1 - d0) / n;
			d = d == null ? new double[n] : d;
			for (int i = 0, I = Math.Min(d.Count, n); i < I; i++, v += vd)
				d[i] = v;
			return d;
		}

		/// <summary>
		/// Raise every component by specicied exponent.
		/// </summary>
		/// <param name="d">Output vector.</param>
		/// <param name="s">Input vector.</param>
		/// <param name="e">Exponent.</param>
		/// <returns>New vector.</returns>
		public static IList<double> Pow(IList<double> d, IList<double> s, double e) {
			d = d == null ? new double[s.Count] : d;
			for (int i = 0; i < s.Count; i++)
				d[i] = Math.Pow(s[i], e);
			return d;
		}

		/// <summary>
		/// Get piecewise linear vector from input vector.
		/// </summary>
		/// <param name="d">Destination vector.</param>
		/// <param name="s">Source vector.</param>
		/// <returns>Piecewise linear vector from Source.</returns>
		public static IList<double> GetLin(IList<double> d, IList<double> s) {
			double p = 0.0, pd = 1.0 / d.Count;
			d = d == null ? new double[s.Count] : d;
			for (int i = 0; i < d.Count; i++, p += pd)
				d[i] = GetLin(s, p);
			return d;
		}
		/// <summary>
		/// Get piecewise linear value at specified position.
		/// </summary>
		/// <param name="s">Input vector.</param>
		/// <param name="p">Position, ranging from 0 to 1.</param>
		/// <returns>Piecewise linear value.</returns>
		public static double GetLin(IList<double> s, double p) {
			double pi = p * (s.Count - 1);
			int i0 = (int)pi, i1 = (int)(pi + 1);
			double pf = pi - i0;
			return s[i0] * (1.0 - pf) + s[i1] * pf;
		}

		/// <summary>
		/// Print vector values in separate lines.
		/// </summary>
		/// <typeparam name="TS">Datatype of vector.</typeparam>
		/// <param name="s">Vector.</param>
		public static void Print<TS>(IList<TS> s) {
			for (int i = 0; i < s.Count; i++)
				Console.WriteLine(s[i]);
		}
	}
}
