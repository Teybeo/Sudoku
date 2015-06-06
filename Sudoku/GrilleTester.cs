using System;
using System.Collections.Generic;

namespace Sudoku
{
	/// <summary>
	/// Description of GrilleTester.
	/// </summary>
	public partial class Grille
	{
		/// <summary>
		/// Verify the validity of lines, columns and squares regions
		/// </summary>
		public bool verifyGrille() {
			
			int root = (int)Math.Sqrt(norm);
			List<int> _target = new List<int>(symbols);
			HashSet<int>[,] square_symbols = new HashSet<int>[root, root];
			HashSet<int> line_symbols = new HashSet<int>();
			HashSet<int> column_symbols = new HashSet<int>();
			
			// Allocate the hashsets
			for (int i = 0; i < root; i++)
				for (int j = 0; j < root; j++)
					square_symbols[i, j] = new HashSet<int>();
			
			for (int i = 0; i < norm; i++) {
				
				for (int j = 0; j < norm; j++) {
					
					// Potential Optimisation
					// If already in the set, the grid is wrong
					
					// On accumule les symboles
					line_symbols.Add(data[i, j]);
					column_symbols.Add(data[j, i]);
					
					square_symbols[i / root, j / root].Add(data[i, j]);
				}
				
				// Si l'ensemble des symboles de cette ligne != de l'ensemble cible, mauvaise grille
				if (line_symbols.SetEquals(_target) == false)
					return false;
				// Si l'ensemble des symboles de cette colonne != de l'ensemble cible, mauvaise grille
				if (column_symbols.SetEquals(_target) == false)
					return false;
				
				line_symbols.Clear();
				column_symbols.Clear();
			}
			
			// Check the set of each squares 
			foreach (HashSet<int> set in square_symbols) {
				
				if (set.SetEquals(_target) == false)
					return false;
			}
			
			return true;
		}
		
	}
}
