using RestApiNetCore9.Model;

namespace RestApiNetCore9.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {


        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person myPerson = MockPerson(i);
                persons.Add(myPerson);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = i,
                FirstName = "Person FirstName " + i,
                LastName = "Person LastName " + i,
                Address = "Uberlandia - Minas Gerais - Brasil",
                Gender = "M"
            };
        }

        public Person FindByID(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Leandro",
                LastName = "Costa",
                Address = "Uberlandia - Minas Gerais - Brasil",
                Gender = "M"
            };
        }

        public Person Updade(Person person)
        {
            return person;
        }
    }
}
