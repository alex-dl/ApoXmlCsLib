# ApoXmlCsLib

ApoXmlCsLib is a C# library for creating **ApoXML** files.

ApoXML files are used to automate job creation in an **Agfa Apogee** or **Asanti** workflow.  
It allows web-to-print and MIS vendors to integrate with the Agfa workflows without the need to create a complex JDF file.

## Usage

Download and build the project.  
Copy the **ApoXmlCsLib.dll** file to your project and add a reference to this file.  
To get this dll, download and build the project or simply download it from the release.
Depending on the workflow, Apogee or Asanti, use one of following constructors:

```cs
Apogee.ApoXML apogeexml = new Apogee.ApoXML() { /* initialization */ };
Asanti.ApoXML asantixml = new Asanti.ApoXML() { /* initialization */ };
```

Use the examples in the **DemoApoXmlApp** to create an ApoXML file.  
Write the ApoXML file into an ApoXML enabled hot folder on the workflow. For workflow requirements and setup, please contact your local support.

![ApoXML Hot Ticket](/Images/ApoXML_HotTicket.png)

## What can be controlled?

Administrative info like order number, jobname, comments,...  
Customer details, contact information, uploaders and approvers.    
Job milestones, when should the job be finished.  
Ticket template for plan setup, parameter set selection, product, number of pages.  
Job parts, page sizes, (spot)colors, paper details, workstyle, press, link to content files...  
Job versions, layers, run lengths.

## Limitations

To keep the ApoXML syntax simple, it is not possible to control production details directly.
To control the production details, select a preconfigured ticket template with the TicketTemplate attribute and use the NamedFeatures attribute to select parameter sets.  
ApoXML does not specifiy imposition details but provides high level settings used by the auto impose feature to create the imposition.  

Some MIS vendors support JDF. The JDF format gives greater control over the job settings but is vastly more complex.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)