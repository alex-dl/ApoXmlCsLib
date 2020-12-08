using System;
using System.Configuration;
using System.IO;
//using ApoXML = Apogee.ApoXML;
//using AsantiXML = Asanti.ApoXML;

// Add a reference to the dll file: ApoXmlCsLib.dll

namespace DemoApoXmlApp
{
    class Program
    {
		// Destination folder for ApoXML files.
		private static string outputFolder = 
			String.IsNullOrWhiteSpace(Settings.Default.OutputFolder) ? @"\\apogee\JDFImportRoot\ApoXML" : Settings.Default.OutputFolder;

		/// <summary>
		///		Demonstration how to use the ApoXmlCsLib to generate ApoXML / AsantiXML files.
		/// </summary>
		static void Main()
        {
			// Depending on the workflow, Apogee or Asanti, use one of the following constructors:
			Apogee.ApoXML apogeexml = new Apogee.ApoXML() { /* initialization */ };
			Asanti.ApoXML asantixml = new Asanti.ApoXML() { /* initialization */ };

			// Demo 1 - Samples how to generate ApoXML / AsantiXML files. 
			bool finished = false;
			while (!finished)
            {
				char selection = GetUserSelection();
				switch (selection)
				{
					case '0':
						SetOutputFolder();
						break;
					case 'a':   // ApoXML - BusinessCards
						apogeexml = Samples.CreateBusinessCards();
						Console.WriteLine(apogeexml.ToString());
						apogeexml.ToFile(Path.Combine(outputFolder, $"business_cards_{Utils.Timestamp}.xml"));
						break;					
					case 'b':   // ApoXML - Booklet: spread cover + body
						apogeexml = Samples.CreateBookletSpreadCoverBody();
						Console.WriteLine(apogeexml.ToString());
						apogeexml.ToFile(Path.Combine(outputFolder, $"booklet_spreadcover_body_{Utils.Timestamp}.xml"));
						break;					
					case 'c':   // AsantiXML - Posters
						asantixml = Samples.CreatePosters();
						Console.WriteLine(asantixml.ToString());
						asantixml.ToFile(Path.Combine(outputFolder, $"posters_{Utils.Timestamp}.xml"));
						break;
					case 'q':
						finished = true;
						break;
					default:
						break;
				}
			}


			// Demo 2 - Load ApoXML file and modify it.
			Apogee.ApoXML apoxml2 = Apogee.ApoXML.FromXml(@"Samples\XML\ApoXML\Multipart_withSpreadCover.xml");
			apoxml2.AgentName = "Demo MIS";
			//Console.WriteLine(apoxml2.ToString());
			//apoxml2.ToFile(@"C:\Temp\Multipart_withSpreadCover_modified.xml");
			

			// Demo 3 - Load AsantiXML file and modify it.
			Asanti.ApoXML asantixml2 = Asanti.ApoXML.FromXml(@"Samples\XML\AsantiXML\Asanti_Posters.xml");
			asantixml2.AgentName = "Demo MIS";
			//Console.WriteLine(asantixml2.ToString());
			//asantixml2.ToFile(@"C:\Temp\Asanti_Posters_modified.xml");
		}



        /// <summary>
		///		Display main options menu and get users selection.
		/// </summary>
		/// <returns>Lowercase char that indicates users selection.</returns>
		private static char GetUserSelection()
        {
			Console.Write($@"
Create ApoXML
=============
0. Set output folder. Current output folder: {outputFolder}
a. Business cards (ApoXML)
b. Booklet: spread cover + body 16p (ApoXML)
c. Posters (AsantiXML)
q. Quit

> ");
			char userInput = Char.ToLower(Console.ReadKey().KeyChar);
			Console.WriteLine("\n");
			return userInput;
		}

		/// <summary>
		///		Set output folder where ApoXML is written.
		/// </summary>
		private static void SetOutputFolder()
		{
			Console.Write("Enter new output folder: ");
			string newOutputFolder = Console.ReadLine();
			if (Directory.Exists(newOutputFolder)) 
			{
				Settings.Default.OutputFolder = newOutputFolder;
				Settings.Default.Save();
				outputFolder = newOutputFolder;
			}
            else
            {
				Console.WriteLine("Output folder does not exists.");
            }
		}

	}
}
