using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public partial class Grille
	{
		private string nom;
		private string date;
		private int[,] data;
		private int[] symbols;
		
		public int norm { get; set;}
			
		public override string ToString() {
			
			StringBuilder sb = new StringBuilder(norm * norm);
			
			sb.AppendLine(nom);
			sb.AppendLine(date);
			
			for (int i = 0; i < norm; i++) {
				for (int j = 0; j < norm; j++) {
					sb.Append(data[i, j] + " ");
				}
				sb.Append("\n");				
			}
			
			return sb.ToString();
		}
		
		/// <summary>
		/// Factory building a 4x4 resolved sudoku
		/// </summary>
		public static Grille DummyData() {
			int[,] _data = {
				{1, 2, 3, 4},
				{4, 3, 2, 1},
				{3, 4, 1, 2},
				{2, 1, 4, 3}
			};
			int[] _symbols = {1, 2, 3, 4};
			Grille g = new Grille();
			g.data = _data;
			g.norm = 4;
			g.symbols = _symbols;
			return g;
		}
	}
}
