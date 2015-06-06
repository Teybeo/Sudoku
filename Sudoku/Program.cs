using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
	class Program
	{
		public static void Main(string[] args)
		{
//			Grille grille = Grille.DummyData();
			List<Grille> list = Grille.loadFrom("../../resolved.sud");
			
			foreach (Grille grille in list) {
				Console.Write(grille);
				Console.WriteLine("[Validity]: " + (grille.verifyGrille() == true ? "OK" : "INVALID"));
				Console.WriteLine();
			}

			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}