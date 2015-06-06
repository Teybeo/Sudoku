using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
	public partial class Sudoku
	{
		private string nom;
		private string date;
		private Cell[,] grid;
		private int[] symbols;
		
		public int size { get; set;}
		
		public Sudoku()
		{
		}
		
		public Sudoku(int[,] data, int size, int[] symbols) {
			this.size = size;
			this.symbols = symbols;
			this.grid = new Cell[size, size];
			
			for (int i = 0; i < size; i++) {
				for (int j = 0; j < size; j++) {
					this.grid[i, j] = new Cell(data[i, j]);
				}
			}
		}
		
		public override string ToString() {
			
			StringBuilder sb = new StringBuilder(size * size);
			
			sb.AppendLine(nom);
			sb.AppendLine(date);
			
			for (int i = 0; i < size; i++) {
				for (int j = 0; j < size; j++) {
					sb.Append(grid[i, j].val + " ");
				}
				sb.Append("\n");				
			}
			
			return sb.ToString();
		}
		
		/// <summary>
		/// Factory building a 4x4 resolved sudoku
		/// </summary>
		public static Sudoku DummyData() {
			int[,] _data = {
				{1, 2, 3, 4},
				{4, 3, 2, 1},
				{3, 4, 1, 2},
				{2, 1, 4, 3}
			};
			int[] _symbols = {1, 2, 3, 4};
			Sudoku g = new Sudoku(_data, 4, _symbols);
			return g;
		}
	}
}
