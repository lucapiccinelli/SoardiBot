using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Soardibot.Dto
{
    public class Secrets
    {
        public TelegramSecrets Telegram { get; set; }

        public static Secrets FromXmlString(string xmlAsString)
        {
            var reader = new XmlSerializer(typeof(Secrets));
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xmlAsString)))
            using (var streamreader = new StreamReader(stream))
            {
                var deserialized = (Secrets)reader.Deserialize(streamreader);
                return deserialized;
            }
        }

        public static Secrets FromXml(string secretsXml)
        {
            return FromXmlString(File.ReadAllText(secretsXml));
        }
    }
}