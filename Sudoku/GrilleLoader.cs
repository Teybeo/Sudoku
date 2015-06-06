using System;
using System.Collections.Generic;
using System.IO;

namespace Sudoku
{
	/// <summary>
	/// Description of GrilleLoader.
	/// </summary>
	public partial class Grille
	{
		public static List<Grille> loadFrom(string path) {
			
			List<Grille> grille_list = new List<Grille>();
			
			try {
				using (StreamReader file = new StreamReader(path)) {
					
					string line;
					// Consume here the comment line separating each grid
					while ( (line = file.ReadLine() ) != null)	{
						Grille grille = parseGrille(file);
						grille_list.Add(grille);
					}
				}

			} catch (Exception) {
				Console.WriteLine("Error: couldn't open file [" + path + "]");
			}

			return grille_list;
		}
		
		private static Grille parseGrille(StreamReader reader) {
			Grille grille = new Grille();
			grille.nom = reader.ReadLine();
			grille.date = reader.ReadLine();
			
			string symbols = reader.ReadLine();
			int length = symbols.Length;
			grille.norm = length;
			grille.symbols = new int[length];
			for (int i = 0; i < length; i++) {
				grille.symbols[i] = (int)Char.GetNumericValue(symbols[i]);
			}
			
			grille.data = new int[length,length];
			for (int i = 0; i < length; i++) {
				for (int j = 0; j < length; j++) {
					grille.data[i, j] = reader.Read() - '0';
				}
				// Consume \n and/or \r
				reader.ReadLine(); 
			}
			return grille;
		}
	}
}
