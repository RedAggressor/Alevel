using HomeWork12.Enum;

namespace HomeWork12.Entities
{
    internal class ContactEntity
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Number { get; set; }
        public DateTime? CreateAt { get; set; }
        public DirectoryType SectorType { get; set; }
    }
}
