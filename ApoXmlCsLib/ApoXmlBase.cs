using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ApoXmlCsLib
{
    public abstract class ApoXmlBase<T> where T : class, new()
    {
        /// <summary>
        ///     Deserialize an existing ApoXml file.
        /// </summary>
        /// <param name="apoXmlFile">Path of an existing ApoXML file.</param>
        /// <returns>An ApoXML or AsantiXML object. If deserilization fails an empty ApoXML object is returned.</returns>
        public static T FromXml(string apoXmlFile)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using FileStream fileStream = new FileStream(apoXmlFile, FileMode.Open);
                return (T)serializer.Deserialize(fileStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
                return new T();
            }
        }

        /// <summary>
        ///     Serialize ApoXML object to XML file. 
        /// </summary>
        /// <param name="apoXmlFile">Path of XML file.</param>
        public void ToFile(string apoXmlFile)
        {
            try
            {
                File.WriteAllText(apoXmlFile, this.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
        }


        /// <summary>
        ///     Serialize ApoXML object to string.
        /// </summary>
        /// <returns>ApoXML as a string.</returns>
        public override string ToString()
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("ns0", "http://www.agfa.com/apoxml");
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            ns.Add("xs", "http://www.w3.org/2001/XMLSchema");
            ns.Add("altova", "http://www.altova.com/xml-schema-extensions");
            Encoding Utf8 = new UTF8Encoding(false);    // no BOM
            using MemoryStream memorystream = new MemoryStream();
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
            {
                Encoding = Utf8,
                OmitXmlDeclaration = false,
                Indent = true           
            };
            using (XmlWriter xmlWriter = XmlWriter.Create(memorystream, xmlWriterSettings))
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                s.Serialize(xmlWriter, this, ns);
            }
            return Utf8.GetString(memorystream.ToArray());
        }



    }
}
