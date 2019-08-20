using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using People.Service.Models;
using Common;

namespace People.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        IPeopleProvider provider;

        public PeopleController(IPeopleProvider provider)
        {
            this.provider = provider;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return provider.GetPeople();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return provider.GetPeople().FirstOrDefault(p => p.Id == id);
        }
    }
}