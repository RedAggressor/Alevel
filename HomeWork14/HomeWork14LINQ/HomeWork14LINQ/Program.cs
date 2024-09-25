namespace HomeWork14LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Створіть список контактів і спробуйте всі основні методи LINQ
            FirstOrDefault, Where, Select і ще 3
            */

            var listContacts = GetRandomContacts();

            ShowBaseList(listContacts);

            FirstOfDefaultContact(listContacts);

            WhereAge(listContacts);

            SelectName(listContacts);

            OrderNameAge(listContacts);

            FirstAge(listContacts);

            TakeWhileAD(listContacts);
        }

        private static void TakeWhileAD(List<Contact> listContacts)
        {
            Console.WriteLine(".............TakeWhile...........Name [0] == A");

            var takeWhileList = listContacts?.OrderBy(x => x.Name).TakeWhile(x => x.Name[0] == 'A' || x.Name[0] == 'D').ToList();

            Contact.ShowContacts(takeWhileList);
        }
        private static void FirstAge(List<Contact> listContacts)
        {
            Console.WriteLine(".............First...........Age = 18");

            var firstNameAge = new Contact();

            try
            {
                firstNameAge = listContacts.First(y => y.Age == 18);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("First Age 18 = " + firstNameAge?.ToString());
        }

        private static void OrderNameAge(List<Contact> listContacts)
        {
            Console.WriteLine(".............OrderBy...........Name,Age");

            var orderByList = listContacts.OrderBy(x => x.Name).ThenBy(x => x.Age).ToList();

            Contact.ShowContacts(orderByList);
        }

        private static void SelectName(List<Contact> listContacts)
        {
            Console.WriteLine(".............Select...........Name");

            var selectList = listContacts.Select(x => x.Number);

            foreach (var number in selectList)
            {
                Console.WriteLine(number);
            }
        }

        private static List<Contact> GetRandomContacts()
        {
            var listContacts = new List<Contact>();


            for (int i = 0; i <= 10; i++)
            {
                listContacts.Add(new Contact()
                {
                    Name = Contact.GetName(),
                    Number = Contact.GetNumber(),
                    Age = Contact.GetAge()
                });
            }

            return listContacts;
        }

        private static void ShowBaseList(List<Contact> listContacts)
        {
            Console.WriteLine(".............Base list...........");

            Contact.ShowContacts(listContacts);
        }

        private static void FirstOfDefaultContact(List<Contact> listContacts)
        {
            Console.WriteLine(".............FirstOfDefault...........Name == Anton");

            var firstOrDefaultList = listContacts?.FirstOrDefault(x => x.Name == "Anton");

            Console.WriteLine("FirstOFDefault = " + (firstOrDefaultList?.ToString() ?? "Not finded Contact"));
        }

        private static void WhereAge(List<Contact> listContacts)
        {
            Console.WriteLine(".............Where...........Age >= 30");

            var whereList = listContacts.Where(x => x.Age >= 30).ToList();

            Contact.ShowContacts(whereList);
        }
    }
}
