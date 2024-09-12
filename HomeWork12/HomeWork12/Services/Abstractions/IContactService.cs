using HomeWork12.Models;

namespace HomeWork12.Services.Abstractions
{
    internal interface IContactService
    {
        public Guid AddContact(Contact contact);
        public List<Contact> GetContacts();
        public List<Contact> SortContacts();

    }
}
