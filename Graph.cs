using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Challenge
{
    public class Graph
    {
		private int vertices, edges;
		private String text;
		private int[,] adjacenceMatrix;
		public Graph()
		{
			LoadFile();
		}
		/// <summary>
		/// Function in charge of loading and transforming the matrix into a graph
		/// </summary>
		private void LoadFile()
		{
			Console.Write("Ingrese el nombre del archivo ");
			string file = Console.ReadLine();
			try
			{
				//Look for the file with that name in the location C:\Users\julim\source\repos\Challenge\Challenge\bin\Debug\netcoreapp3.1
				using (StreamReader sr = new StreamReader(file + ".txt"))
				{
					text = sr.ReadToEnd();
				}

			}
			catch (Exception e)
			{
				Console.WriteLine("Error in load file.");
				Console.WriteLine(e.ToString());
			}
			if (text != null)
			{
				if (file == "4x4")
					text = text.Replace("\r\n", " \n ");
				if (file == "map")
					text = text.Replace("\n", " \n ");
				string[] verticesStrings = text.Split(' ');
				vertices = Convert.ToInt32(verticesStrings[0]);
				adjacenceMatrix = new int[vertices, vertices];
				int count = 0;
				for (int line = 0; line < vertices; line++)
				{
					for (int col = 0; col < vertices; col++)
					{
						if (verticesStrings[count] != "\n")
						{
							adjacenceMatrix[line, col] = Convert.ToInt32(verticesStrings[count]);
						}
						else
							col--;
						count++;
					}
				}
				Console.WriteLine(text);


				CalculateEdges();
			}

		}
		/// <summary>
		/// Function in charge of finding the vertices and going through the matrix to find the most optimal route 
		// </summary>
		public void CalculateEdges()
		{
			edges = 0;
			int number = 0;
			int exnumber = 0;
			int lastnumber = 0;
			List<int> path = new List<int>();
			for (int line = 0; line < vertices; line++)
			{
				for (int col = 0; col < vertices; col++)
				{
					number = adjacenceMatrix[line, col];
					if (number > exnumber && exnumber != 0)
					{
							if (lastnumber > number || lastnumber == 0)
							{
								path.Add(number);
								lastnumber = number;
								
							}
					
					}
					else 
					{
						exnumber = number;
					}
					if (adjacenceMatrix[line, col] == 1)
						edges++;
				}
				
			}
			Console.WriteLine("La ruta es");
			for (int i=0; i< path.Count; i++)
			{
				Console.WriteLine(path[i]);
			}
			Console.WriteLine("El numero de pasos es: " + path.Count());
			Console.WriteLine("La altura inicial es: " + path[0]);

		}



		

	}
}

