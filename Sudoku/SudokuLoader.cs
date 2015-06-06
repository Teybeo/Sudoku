using System;
using System.Collections.Generic;
using System.IO;

namespace Sudoku
{
	/// <summary>
	/// Description of GrilleLoader.
	/// </summary>
	public partial class Sudoku
	{
		public static List<Sudoku> loadFrom(string path) {
			
			List<Sudoku> sudoku_list = new List<Sudoku>();
			
			try {
				using (StreamReader file = new StreamReader(path)) {
					
					string line;
					// Consume here the comment line separating each grid
					while ( (line = file.ReadLine() ) != null)	{
						Sudoku sudoku = parseSudoku(file);
						sudoku_list.Add(sudoku);
					}
				}

			} catch (Exception) {
				Console.WriteLine("Error: couldn't open file [" + path + "]");
			}

			return sudoku_list;
		}
		
		private static Sudoku parseSudoku(StreamReader reader) {
			Sudoku sudoku = new Sudoku();
			sudoku.nom = reader.ReadLine();
			sudoku.date = reader.ReadLine();
			
			string symbols = reader.ReadLine();
			int length = symbols.Length;
			sudoku.size = length;
			sudoku.symbols = new int[length];
			for (int i = 0; i < length; i++) {
				sudoku.symbols[i] = (int)Char.GetNumericValue(symbols[i]);
			}
			
			sudoku.grid = new Cell[length,length];
			for (int i = 0; i < length; i++) {
				for (int j = 0; j < length; j++) {
					sudoku.grid[i, j] = new Cell(reader.Read() - '0');
				}
				// Consume \n and/or \r
				reader.ReadLine(); 
			}
			return sudoku;
		}
	}
}
