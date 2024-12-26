using RestApiNetCore9.Model;

namespace RestApiNetCore9.Services.Implementations
{
    public interface IPersonService
    {
        Person Create (Person person);

        Person FindByID(long id);

        List<Person> FindAll();

        Person Updade(Person person);

        void Delete(long id);
    }
}
