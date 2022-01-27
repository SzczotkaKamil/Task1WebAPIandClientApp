using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsAPI.Entities;

namespace ContactsAPI.Services
{
    public interface IContactsRepository
    {
        bool HasContact(int id);
        Contact GetContact(int id);
        IEnumerable<Contact> GetContacts();
    }
}
