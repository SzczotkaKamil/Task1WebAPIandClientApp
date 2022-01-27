using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using ContactsAPI.Entities;

namespace ContactsAPI.Services
{
    public class ContactsRepository : IContactsRepository
    {
        private IEnumerable<Contact> contacts;

        public ContactsRepository()
        {
            var path = System.Configuration.ConfigurationManager.AppSettings["xmlDataPath"];

            var data = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/" + path));
            contacts = from contact in data.Descendants("Contact")
                       select new Contact()
                       {
                           Id = (int)contact.Element("Id"),
                           Name = (string)contact.Element("Name"),
                           Surname = contact.Element("Surname").Value,
                           PhoneNumber = contact.Element("PhoneNumber").Value,
                           Email = contact.Element("Email").Value
                       };
        }

        public bool HasContact(int id)
        {
            return contacts.Any(o => o.Id == id);
        }

        public Contact GetContact(int id)
        {
            return contacts.Where(o => o.Id == id).FirstOrDefault();
        }

        public IEnumerable<Contact> GetContacts()
        {
            return contacts;
        }
    }
}