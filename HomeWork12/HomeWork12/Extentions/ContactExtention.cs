using HomeWork12.Models;

namespace HomeWork12
{
    internal static class ContactExtention
    {
        public static List<Contact> SortContacts(this List<Contact> contacts)
        {
            var temp = new Contact();

            for (int count = contacts.Count / 2; count >= 1; count /= 2)
            {
                for (int i = 0; i < contacts.Count; i++)
                {
                    for (int c = i - count; c >= 0; c -= count)
                    {
                        if (contacts[c].CompareTo(contacts[c + count]) > 0)
                        {
                            temp = contacts[c];
                            contacts[c] = contacts[c + count];
                            contacts[c + count] = temp;
                        }
                    }
                }
            }
            return contacts;
        }
    }
}
