using System.Xml.Serialization;

namespace Task1WebAPIandClientApp
{
    public class Contact
    {   [XmlAttribute]
        public string Id{ get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
       
    }

}
