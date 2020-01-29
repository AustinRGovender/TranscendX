using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TranscendX
{
    public class Transformation
    {
        public static string TransformFile(string doc, string xslPath)
        {
            Func<string, XmlDocument> GetXmlDocument = (xmlContent) =>
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlContent);
                return xmlDocument;
            };

            try
            {
                var document = GetXmlDocument(doc);
                var xsl = GetXmlDocument(File.ReadAllText(xslPath));

                System.Xml.Xsl.XslCompiledTransform transform = new System.Xml.Xsl.XslCompiledTransform();
                transform.Load(xsl);
                System.IO.StringWriter writer = new System.IO.StringWriter();

                XmlReader reader = new XmlTextReader(new StringReader(document.DocumentElement.OuterXml));

                transform.Transform(reader, null, writer);
                return writer.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
