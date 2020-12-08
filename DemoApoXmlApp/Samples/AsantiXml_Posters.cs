using System;

namespace DemoApoXmlApp
{
    static partial class Samples
	{

		public static Asanti.ApoXML CreatePosters()
        {
			string[] posters = new string[] { "Poster0-A3", "Poster1-A3" };
			int[] amounts = new int[] { 3, 4 };

			Asanti.ApoXML asantixml = new Asanti.ApoXML()
			{
				AgentName = "ApoXmlCsLib",
				AgentVersion = "1.0.0",
				OrderNumber = "AsantiXML",
				JobName = "Demo Posters " + DateTime.Now.ToString("MMddHHmmss"),
				Comments = "Posters Wideformat",
				PrintProcess = Asanti.PrintProcessType.WideFormatPrinting,
				PrintQuality = Asanti.PrintQualityType.CostEffective,				
				EndDate = "2021-12-01",
				DecimalSeparator = Asanti.ApoXMLDecimalSeparator.Item1,  // Item=comma, Item1=point
				ThousandSeparator = Asanti.ApoXMLThousandSeparator.Item1,   // Item=point Item1=comma
				Unit = Asanti.ApoXMLUnit.mm,
				//TicketTemplate = "myTicketTemplate",	// Name of job or hot ticket template.
				CustomerContact = new Asanti.BaseContactType()
				{
					Company = new Asanti.BaseCompanyType()
					{
						Company = "Demo Company",
						Street = "Demo Street 1",
						ZIP = "1234",
						City = "Demo City",
						StateProvince = "Demo Province",
						Country = "Demo Country",
						Phone = "123456789",
					},
					Person = new Asanti.BasePersonType()
					{
						Title = "Mr.",
						FirstName = "ContactFirstName",
						LastName = "ContactLastName",
						FixPhone = "456789",
						Email = "contact@example.com"
					}
				},
				PaperStock = new Asanti.PaperStockType()
				{
					StockName = "Generic",
					MediaType = "Generic"
				}
			};

			asantixml.Part = new Asanti.BasePartType[posters.Length];
			for (int i = 0; i < posters.Length; i++)
			{
				var part = new Asanti.BasePartType()
				{
					Amount = amounts[i].ToString(),
					PartName = posters[i],
					Press = "(Generic_SD)Engine",
					Comments = posters[i],
					Pages = new Asanti.PagesType()
					{
						URL = $"file:///{Utils.AppFolderUrl}Samples/PDF/Poster_0{i+1}_CMYK_A3.pdf",
						PageCount = "1"   // string
					}
				};
				asantixml.Part[i] = part;
			}
			return asantixml;
		}

    }
}
