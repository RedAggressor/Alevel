namespace HomeWork14LINQ
{
    public class Contact
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Number { get; set; }

        public static string GetName()
        {
            var listName = new List<string>
            {
                "Anton", "Valera", "Dima", "Dinis",
                "Vitalic", "Oleg", "Maxim", "Vlad",
                "Yaroslav", "Alex"
            };

            int rendomndex = new Random().Next(0, listName.Count);

            string name = listName.ElementAt(rendomndex);

            return name;
        }

        public static string GetNumber()
        {
            string shablon = $"+38({new Random().Next(100, 1000)})-{new Random().Next(100, 1000)}-{new Random().Next(10, 100)}-{new Random().Next(10, 100)}";
            return shablon;
        }

        public static int GetAge()
        {
            return new Random().Next(1, 100);
        }

        public static void ShowContacts(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Age: {contact.Age}, Number: {contact.Number}");
            }
        }
        public override string ToString()
        {
            return $"Name: {Name ?? "none"}, Age: {Age}, Number: {Number ?? "none"}";
                
        }
    }
}
