using HomeWork12.Entities;
using HomeWork12.Repositories.Abstractions;

namespace HomeWork12.Repositories
{
    internal class ContactRepository : IContactRepository
    {
        private List<ContactEntity> _contacts = new List<ContactEntity>();

        public Guid AddContact(ContactEntity contactEntity)
        {
            var contact = new ContactEntity()
            {
                Id = Guid.NewGuid(),
                FirstName = contactEntity.FirstName,
                LastName = contactEntity.LastName,
                Number = contactEntity.Number,
                CreateAt = contactEntity.CreateAt,
                SectorType = contactEntity.SectorType
            };

            _contacts.Add(contact);

            return contact.Id;
        }

        public List<ContactEntity> GetContacts()
        { 
            return _contacts;
        }
    }
}
