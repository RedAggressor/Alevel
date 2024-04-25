using HomeWork12.Enum;

namespace HomeWork12.Models
{
    internal class Contact : IComparable<Contact>
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Number { get; set; }
        public DateTime? CreateAt { get; set; }
        public DirectoryType SectorType { get; set; }

        public override string ToString()
        {
            return @$"firstname {FirstName} lastname {LastName} 
                    number of phone: {Number} 
                    CreateTime at {CreateAt} 
                    Directory {SectorType}";
        }

        public int CompareTo(Contact? contact)
        {
            int secondComper = SectorType.CompareTo(contact?.SectorType);

            if (secondComper != 0)
            {
                return secondComper;
            }
            else
            {
                int firstComper = FirstName.CompareTo(contact?.FirstName);

                if (firstComper != 0)
                {
                    return firstComper;
                }
                else
                {
                    return LastName.CompareTo(contact?.LastName);
                }
            }
        }
    }
}
