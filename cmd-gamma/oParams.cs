using System.Collections.Generic;

namespace orez.ogamma {
	class oParams {

		// data
		/// <summary>
		/// Tells whether the gamma values will be specified as a linear
		/// piecewise function. The range of values to be specified, is
		/// from 0 to 1.
		/// </summary>
		public bool Ramp;
		/// <summary>
		/// Tells whether gamma values will be separately specified
		/// for each color. In case, ramp is also true, RGB values
		/// are expected to be delimited with R, G, and B characters.
		/// </summary>
		public bool Color;
		/// <summary>
		/// Stores an array of red, blue or green input values.
		/// </summary>
		public IList<double> Red, Green, Blue;
		

		// constructor
		/// <summary>
		/// Get input parameters from input arguments.
		/// </summary>
		/// <param name="args">Input arguments.</param>
		public oParams(string[] args) {
			char s = '\0';
			Red = new List<double>();
			Green = new List<double>();
			Blue = new List<double>();
			for (int a = 0; a < args.Length; a++) {
				string v = args[a];
				if (v == "-r" || v == "--ramp") { Ramp = true; continue; }
				if (v == "-c" || v == "--color") { Color = true;  continue; }
				v = v.ToLower();
				if (v[0] >= 'a' && v[0] <= 'Z') { s = v[0]; continue; }
				double n = 0.0;
				double.TryParse(v, out n);
				bool sp = !Color || (s != 'r' && s != 'g' && s != 'b');
				if (s == 'r' || sp) Red.Add(n);
				if (s == 'g' || sp) Green.Add(n);
				if (s == 'b' || sp) Blue.Add(n);
			}
		}
	}
}
