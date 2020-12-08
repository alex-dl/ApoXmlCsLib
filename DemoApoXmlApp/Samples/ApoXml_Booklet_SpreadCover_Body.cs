using System;

namespace DemoApoXmlApp
{
    static partial class Samples
	{

		public static Apogee.ApoXML CreateBookletSpreadCoverBody()
        {

			Apogee.ApoXML apoxml = new Apogee.ApoXML()
			{
				AgentName = "ApoXmlCsLib",
				AgentVersion = "1.0.0",
				OrderNumber = "ApoXML",
				JobName = "Booklet - SpreadCover + Body " + Utils.Timestamp,
				Amount = "2000",    // string
				Comments = "ApoXML multipart brochure SpreadCover 4/4; Body 1/1 16pp",
				DecimalSeparator = Apogee.ApoXMLDecimalSeparator.Item1,  // Item=comma, Item1=point
				ThousandSeparator = Apogee.ApoXMLThousandSeparator.Item1,   // Item=point Item1=comma
				ProductType = "Brochure",
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
					Method = Apogee.MethodType.Nested,
					MethodSpecified = true
				},
				PartCover = new Apogee.PartCoverType()
				{
					PartType = Apogee.PartTypeType.Cover,
					PartTypeSpecified = true,
					PartName = "Cover",
					Press = "Small Press",
					WorkStyle = Apogee.ImposeWorkStyleType.Duplex,
					CoverType = Apogee.CoverTypeType.Spread,
					CoverTypeSpecified = true,
					OpenWidth = 422M,
					OpenWidthSpecified = true,
					Comments = "Cover remarks",
					Pages = new Apogee.PagesType()
					{
						URL = $"file:///{Utils.AppFolderUrl}Samples/PDF/Cover_Spread_DS_425x297.pdf",
						PageCount = "2",    // string
						PageWidth = 210M,
						PageHeight = 297M
					},
					Color = new Apogee.ColorType()
					{
						NrColors = "4"  // string
					},
					PaperStock = new Apogee.PaperStockType()
					{
						Grade = Apogee.GradeType.Item1, // 1
						GradeSpecified = true,
						StockName = "Cover_Heavy",
						Weight = "200",     // string
						Thickness = 0.24M,  // decimal
						ThicknessSpecified = true,
						SheetWidth = 707M,  // decimal
						SheetWidthSpecified = true,
						SheetHeight = 500M,  // decimal
						SheetHeightSpecified = true
					}
				},
				Part = new Apogee.BasePartType[]
				{
					new Apogee.BasePartType()
					{
						PartType = Apogee.PartTypeType.Body,
						PartName = "Body",
						Press = "Large Press",
						WorkStyle = Apogee.ImposeWorkStyleType.Duplex,
						Comments = "Body remark",
						Pages = new Apogee.PagesType()
						{
							URL = $"file:///{Utils.AppFolderUrl}Samples/PDF/A4_16p_CMYK.pdf",
							PageCount = "16",	// string
							PageWidth = 210M,
							PageHeight = 297M
						},
						Color = new Apogee.ColorType()
						{
							NrColors = "1"	// string
						},
						PaperStock = new Apogee.PaperStockType()
						{
							Grade = Apogee.GradeType.Item1,	// 1
							GradeSpecified = true,
							StockName = "Antalis Coated",
							Weight = "100",		// string
							Thickness = 0.12M,	// decimal
							ThicknessSpecified = true,
							SheetWidth = 1000M,  // decimal
							SheetWidthSpecified = true,
							SheetHeight = 707M,  // decimal
							SheetHeightSpecified = true
						}
					}
				}
			};
			return apoxml;
		}

    }
}
