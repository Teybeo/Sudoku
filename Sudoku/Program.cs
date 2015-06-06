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
			List<Sudoku> list = Sudoku.loadFrom("../../resolved.sud");
			
			foreach (Sudoku sudoku in list) {
				Console.Write(sudoku);
				Console.WriteLine("[Validity]: " + (sudoku.checkValidity() == true ? "OK" : "INVALID"));
				Console.WriteLine();
			}

			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}