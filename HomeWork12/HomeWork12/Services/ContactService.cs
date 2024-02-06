using HomeWork12.Entities;
using HomeWork12.Enum;
using HomeWork12.Models;
using HomeWork12.Repositories.Abstractions;
using HomeWork12.Services.Abstractions;
using System.Text.RegularExpressions;

namespace HomeWork12.Services
{
    internal class ContactService : IContactService
    {
        private IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public Guid AddContact(Contact contact)
        {
            var entity = new ContactEntity()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Number = contact.Number,
                CreateAt = contact.CreateAt,
                SectorType = GetDirectoryType(contact.FirstName, contact.LastName)
            };

            Guid id = _contactRepository.AddContact(entity);

            return id;
        }

        public List<Contact> GetContacts()
        {
            var contacts = new List<Contact>();
            var entities = _contactRepository.GetContacts();

            foreach (var contact in entities)
            {
                contacts.Add(
                    new Contact()
                    {
                        Id = contact.Id,
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Number = contact.Number,
                        CreateAt = contact.CreateAt,
                        SectorType = contact.SectorType
                    });
            }

            return contacts;
        }

        public List<Contact> SortContacts()
        {
            return GetContacts().SortContacts();
        }

        private DirectoryType GetDirectoryType(string firstName, string lastName)
        {
            Regex numberCheck = new Regex("[0-9]");

            Regex symbolCheck = new Regex("[^0-9a-zA-Zа-яА-ЯіїІЇ ]");

            if (numberCheck.IsMatch(firstName) || numberCheck.IsMatch(lastName))
            {
                return DirectoryType.Number;
            }

            if (symbolCheck.IsMatch(firstName) || symbolCheck.IsMatch(lastName))
            {
                return DirectoryType.HeshTeg;
            }

            return DirectoryType.Alphabet;                
        }
    }
}
