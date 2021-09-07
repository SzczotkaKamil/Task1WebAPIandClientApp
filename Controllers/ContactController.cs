using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Task1WebAPIandClientApp.Services;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task1WebAPIandClientApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public ContactController(IOptions<AppSettings> options)
        {
            _options = options;
        }
        private readonly IOptions<AppSettings> _options;
        
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            Deserializer deserializer = new Deserializer();
            deserializer.deserializeXml(_options.Value.FilePath);
            return deserializer.listOfXmlObjects;
            
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            Deserializer deserializer = new Deserializer();
            deserializer.deserializeXml(_options.Value.FilePath);
            return deserializer.listOfXmlObjects[id];
        }

        // POST api/<ContactController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
