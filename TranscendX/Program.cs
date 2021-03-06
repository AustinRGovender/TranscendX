﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace TranscendX
{
    class Program
    {
        static void Main(string[] args)
        {
            var xslPath = "";
            //var xmlPath = "";
            var path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
            xslPath = path + "\\input.xsl";
            string doc = path + "\\input.xml";
        
            TransformFile(doc, xslPath);
            ValidateFile();
        }


        static void ValidateFile()
        {
            var path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", path + "\\input.xsd");
            XmlReader rd = XmlReader.Create(path + "\\input.xml");
            XDocument doc = XDocument.Load(rd);
            doc.Validate(schema, ValidationEventHandler);
            Console.WriteLine("Success");
            Console.ReadLine();
        }

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

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            XmlSeverityType type = XmlSeverityType.Warning;
            if (Enum.TryParse<XmlSeverityType>("Error", out type))
            {
                if (type == XmlSeverityType.Error) throw new Exception(e.Message);

            }

        }
    }
}
