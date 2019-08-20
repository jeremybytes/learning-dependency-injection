using Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace PersonRepository.Service
{
    public class ServiceRepository : IPersonRepository
    {
        WebClient client;
        string baseUri;

        public ServiceRepository()
        {
            client = new WebClient();
            baseUri = "http://localhost:9874/";
        }

        public IEnumerable<Person> GetPeople()
        {
            var address = $"{baseUri}api/people";
            string reply = client.DownloadString(address);
            return JsonConvert.DeserializeObject<List<Person>>(reply);
        }

        public Person GetPerson(int id)
        {
            var address = $"{baseUri}api/people/{id}";
            string reply = client.DownloadString(address);
            return JsonConvert.DeserializeObject<Person>(reply);
        }
    }
}
