using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactsAPI.Services;
using ContactsAPI.Entities;
using ContactsAPI.Models;

namespace ContactsAPI.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly IContactsRepository repository;

        public ContactsController(IContactsRepository contactsRepository)
        {
            repository = contactsRepository;
        }

        // GET api/contacts
        public IEnumerable<ContactDto> Get()
        {
            var contacts = repository.GetContacts();
            var contactDtos = new List<ContactDto>();

            foreach (var c in contacts)
                contactDtos.Add(new ContactDto() {
                    Id = c.Id,
                    FullName = $"{c.Name} {c.Surname}",
                    PhoneNumber = c.PhoneNumber,
                    Email = c.Email
                });

            return contactDtos;
        }

        // GET api/contacts/{id}
        public IHttpActionResult Get(int? id)
        {
            if (id == null)
                return BadRequest();

            if (!repository.HasContact((int)id))
                return NotFound();

            var contact = repository.GetContact((int)id);

            var contactDto = new ContactDto()
            {
                Id = contact.Id,
                FullName = $"{contact.Name} {contact.Surname}",
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email
            };

            return Ok(contactDto);
        }
    }
}
