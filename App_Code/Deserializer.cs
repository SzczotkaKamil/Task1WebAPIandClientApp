using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task1WebAPIandClientApp.Services
{
    public class Deserializer
    {
        public List<Contact> listOfXmlObjects;
        public void deserializeXml(string path)
        {
            listOfXmlObjects = new List<Contact>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Contact[]));
            using (Stream ins = System.IO.File.Open(path, FileMode.Open))
                foreach (Contact o in (Contact[])xmlSerializer.Deserialize(ins))
                    listOfXmlObjects.Add(o);
                    
        }
        public IEnumerable<Contact> GetDeserializedXml()
        {
            return listOfXmlObjects;
        }
       
    }
}
