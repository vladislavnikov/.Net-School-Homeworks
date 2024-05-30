using System.Xml.Serialization;
using Task6.Interfaces;

namespace Task6.Repository
{
    public class XMLRepository : IRepository
    {
        public void Save(Catalog catalog, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Catalog));
            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, catalog);
            }
        }

        public Catalog Load(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Catalog));
            using (StreamReader reader = new StreamReader(path))
            {
                return (Catalog)serializer.Deserialize(reader);
            }
        }
    }
}
