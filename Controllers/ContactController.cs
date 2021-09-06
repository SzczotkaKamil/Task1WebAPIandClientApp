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
            return deserializeXml();
        }
        public IEnumerable<Contact> deserializeXml()
        {
            var listOfXmlObjects = new List<Contact>();
            XmlSerializer xs = new XmlSerializer(typeof(Contact[]));
            using (Stream ins = System.IO.File.Open(_options.Value.FilePath, FileMode.Open))
                foreach (Contact o in (Contact[])xs.Deserialize(ins))
                    yield return o;
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
