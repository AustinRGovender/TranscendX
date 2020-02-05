//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;
//using System.Xml.Linq;
//using System.Xml.Schema;

//namespace TranscendX
//{
//    public class Validation
//    {
//        static void ValidateFile()
//        {
//            var path = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
//            XmlSchemaSet schema = new XmlSchemaSet();
//            schema.Add("", path + "\\input.xsd");
//            XmlReader rd = XmlReader.Create(path + "\\input.xml");
//            XDocument doc = XDocument.Load(rd);
//            doc.Validate(schema, ValidationEventHandler);
//            Console.WriteLine("Success");
//            Console.ReadLine();
//        }

//        static void ValidationEventHandler(object sender, ValidationEventArgs e)
//        {
//            XmlSeverityType type = XmlSeverityType.Warning;
//            if (Enum.TryParse<XmlSeverityType>("Error", out type))
//            {
//                if (type == XmlSeverityType.Error) throw new Exception(e.Message);

//            }

//        }
//    }
//}

