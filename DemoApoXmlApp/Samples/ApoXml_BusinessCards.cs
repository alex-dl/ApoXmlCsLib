using System;

namespace DemoApoXmlApp
{
    static partial class Samples
	{

		public static Apogee.ApoXML CreateBusinessCards()
        {
			string[] names = new string[] { "A", "B", "C" };
			int[] amounts = new int[] { 200, 100, 300 };

			Apogee.ApoXML apoxml = new Apogee.ApoXML()
			{
				AgentName = "ApoXmlCsLib",
				AgentVersion = "1.0.0",
				OrderNumber = "ApoXML",
				JobName = "BusinessCards " + Utils.Timestamp,
				Comments = "ApoXML BusinessCards sample - 3 different business cards in different quantities.",
				ProductType = "Flatwork",
				DecimalSeparator = Apogee.ApoXMLDecimalSeparator.Item1,  // Item=comma, Item1=point
				ThousandSeparator = Apogee.ApoXMLThousandSeparator.Item1,	// Item=point Item1=comma
				Unit = Apogee.ApoXMLUnit.mm,
				//TicketTemplate = "myTicketTemplate",	// Name of job or hot ticket template.
				CustomerContact = new Apogee.BaseContactType()
				{
					Company = new Apogee.BaseCompanyType()
					{
						JDFProductID = "PID_Comp_DemoCompany_001",
						Company = "Demo Company",
						Street = "Demo Street 1",
						ZIP = "1234",
						City = "Demo City",
						StateProvince = "Demo Province",
						Country = "Demo Country",
						Phone = "123456789",
						PrintCenter = "Demo Print Center"
					},
					Person = new Apogee.BasePersonType()
					{
						JDFProductID = "PID_Pers_FirstLast_001",
						Title = "Mr.",
						FirstName = "ContactFirstName",
						LastName = "ContactLastName",
						Prefix = "123",
						FixPhone = "456789",
						MobilePhone = "987654",
						Email = "contact@example.com"
					}
				},
				Binding = new Apogee.BindingType()
				{
					Method = Apogee.MethodType.Unbound,
					MethodSpecified = true
				}
			};

			apoxml.Part = new Apogee.BasePartType[names.Length];
			for (int i = 0; i < names.Length; i++)
			{
				var part = new Apogee.BasePartType()
				{
					PartType = Apogee.PartTypeType.Plain,
					PartName = "BusinessCards " + names[i],
					Press = "Large Press",
					WorkStyle = Apogee.ImposeWorkStyleType.Duplex,
					Comments = "BusinessCard remark",
					Amount = amounts[i].ToString(),   // string
					Pages = new Apogee.PagesType()
					{
						URL = $"file:///{Utils.AppFolderUrl}Samples/PDF/BusinessCard_{names[i]}_01_DS_CMYK_85x54.7.pdf",
						PageCount = "2",   // string
						PageWidth = 85M,
						PageHeight = 55M
					},
					Color = new Apogee.ColorType()
					{
						NrColors = "4"  // string
					},
					PaperStock = new Apogee.PaperStockType()
					{
						Grade = Apogee.GradeType.Item1, // 1
						GradeSpecified = true,
						StockName = "Businesscards",
						Weight = "200",     // string
						Thickness = 0.2M,  // decimal
						ThicknessSpecified = true,
						SheetWidth = 707M,  // decimal
						SheetWidthSpecified = true,
						SheetHeight = 500M,  // decimal
						SheetHeightSpecified = true
					}
				};
				apoxml.Part[i] = part;
			}
			return apoxml;
		}

    }
}
