using HomeWork12.Models;
using HomeWork12.Services.Abstractions;
using System.Globalization;

namespace HomeWork12
{
    internal class StartUp
    {
        private readonly IContactService _contactService;
        
        public StartUp(IContactService contactService)
        {
            _contactService = contactService;
        }
        public void Start()
        {
            UseCultur();

            AddContact();

            ShowContacts();
        }

        private void AddContact()
        {
            do
            {
                Console.WriteLine("enter name:");
                var name = Console.ReadLine();

                Console.WriteLine("enter lastName:");
                var lastName = Console.ReadLine();
                
                Console.WriteLine("enter number of phone");
                var number = Console.ReadLine();

                var newContact = new Contact()
                {
                    FirstName = name,
                    LastName = lastName,
                    Number = number,
                    CreateAt = DateTime.UtcNow
                };

                _contactService.AddContact(newContact);

                Console.WriteLine("Continue end construct? Y");
            }
            while (Console.ReadKey().Key != ConsoleKey.Y);
            
        }

        private void ShowContacts()
        {
            foreach (var item in _contactService.SortContacts())
            {
                Console.WriteLine(item.ToString());
            }

        }

        private void UseCultur()
        {
            Console.WriteLine("Choose cultur language: Ukraine - U or English - E/ defoult en");

            if(Console.ReadKey().Key == ConsoleKey.U) 
            {
                CultureInfo.CurrentUICulture = new CultureInfo("uk-UA");
                CultureInfo.CurrentCulture = new CultureInfo("uk-UA");
            }
            else 
            {
                CultureInfo.CurrentUICulture = new CultureInfo("en-US");
                CultureInfo.CurrentCulture = new CultureInfo("en-US");
            }
            
            Console.WriteLine("CurrentUICulture is now {0}.", CultureInfo.CurrentUICulture.Name);
            Console.WriteLine("CurrentCulture is now {0}.", CultureInfo.CurrentCulture.Name);
            Console.WriteLine("CurrentUICulture is now {0}.", CultureInfo.CurrentUICulture.Name);
        }
    }
}