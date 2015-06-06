using System;
using System.Collections.Generic;

namespace Sudoku
{
	/// <summary>
	/// Description of GrilleTester.
	/// </summary>
	public partial class Sudoku
	{
		/// <summary>
		/// Verify the validity of lines, columns and squares regions
		/// </summary>
		public bool checkValidity() {
			
			int root = (int)Math.Sqrt(size);
			HashSet<int>[,] square_symbols = new HashSet<int>[root, root];
			HashSet<int> line_symbols = new HashSet<int>();
			HashSet<int> column_symbols = new HashSet<int>();
			
			// Allocate the hashsets
			for (int i = 0; i < root; i++)
				for (int j = 0; j < root; j++)
					square_symbols[i, j] = new HashSet<int>();
			
			for (int i = 0; i < size; i++) 
			{
				for (int j = 0; j < size; j++) 
				{	
					// Potential Optimisation
					// If already in the set, the grid is wrong
					
					// On accumule les symboles
					line_symbols.Add(grid[i, j].val);
					column_symbols.Add(grid[j, i].val);

					square_symbols[i / root, j / root].Add(grid[i, j].val);
				}
				
				// Si la ligne/colonne ne contient pas l'ensemble des symboles du sudoku => sudoku invalide
				if (line_symbols.SetEquals(symbols) == false || column_symbols.SetEquals(symbols) == false)
					return false;
				
				line_symbols.Clear();
				column_symbols.Clear();
			}
			
			// Check the set of each squares 
			foreach (HashSet<int> set in square_symbols) {
				
				if (set.SetEquals(symbols) == false)
					return false;
			}
			
			return true;
		}
		
	}
}
