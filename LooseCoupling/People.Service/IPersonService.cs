using Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace People.Service
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        List<Person> GetPeople();

        [OperationContract]
        Person GetPerson(string lastName);

        [OperationContract]
        void AddPerson(Person newPerson);

        [OperationContract]
        void UpdatePerson(string lastName, Person updatedPerson);

        [OperationContract]
        void DeletePerson(string lastName);

        [OperationContract]
        void UpdatePeople(List<Person> updatedPeople);
    }
}
