using HomeWork12.Entities;

namespace HomeWork12.Repositories.Abstractions
{
    internal interface IContactRepository
    {
        public Guid AddContact(ContactEntity contactEntity);
        public List<ContactEntity> GetContacts();
    }
}
