using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace EShopWorld.Hackathon.ASNValidator.Core
{
    public class AsnValidator
    {
        public static bool Validate(
            string xmlSchemaPath,
            string xmlInputPath,
            out string validationExceptionMessage)
        {
            var xmlSchemaSet = new XmlSchemaSet();
            xmlSchemaSet.Add(string.Empty, xmlSchemaPath);

            XDocument xmlDocument;

            using (var xmlReader = XmlReader.Create(xmlInputPath))
            {
                try
                {
                    xmlDocument = XDocument.Load(xmlReader);
                }
                catch (XmlException e)
                {
                    validationExceptionMessage = e.Message;
                    return false;
                }
            }

            var failedValidation = false;
            ValidationEventArgs validationEventArgs = null;

            xmlDocument.Validate(xmlSchemaSet, (o, e) =>
            {
                failedValidation = true;
                validationEventArgs = e;
            });

            if (failedValidation)
            {
                validationExceptionMessage = validationEventArgs.Message;
                return false;
            }

            validationExceptionMessage = null;
            return true;
        }
    }
}