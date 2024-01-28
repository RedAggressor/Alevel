using Models;
using Repositoreis;
using Repositoreis.Abstract;
using Services;
using Services.Abstract;

namespace HomeWork8
{
    internal class Menu
    {
        private readonly ISaladBowlService _saladBowlService;

        public Menu(ISaladBowlService saladBowlService)
        { 
            _saladBowlService = saladBowlService;
        }

        public void StartUp()
        {
            List<Vegetables> ingridients = GetListIngridients();

            string nameSalad = GetNameSalad();

            string id = _saladBowlService.AddSalad(ingridients, nameSalad);

            SaladBowl saladBowl = _saladBowlService.GetSalad(id);

            TypeOfSorting();

            ingridients = saladBowl.VegetablesList;

            ConsoleKey consoleKey = Console.ReadKey().Key;

            ingridients = ChoseTypeSort(ingridients, consoleKey);

            ShowFullInfoList(ingridients);
            while (true)
            {
                FindObject(ingridients);
            }
        }

        private static IVegetablesService? GetService(ConsoleKey consoleKey, IVegetablesRepository sweets) =>
           consoleKey switch
           {
               ConsoleKey.C => new CabbageService(sweets, new LoggerService(), new NotifyService(new LoggerService())),
               ConsoleKey.B => new CornService(sweets, new LoggerService(), new NotifyService(new LoggerService())),
               ConsoleKey.S => new CucumbersService(sweets, new LoggerService(), new NotifyService(new LoggerService())),
               ConsoleKey.A => new DillService(sweets, new LoggerService(), new NotifyService(new LoggerService())),
               ConsoleKey.K => new OnionService(sweets, new LoggerService(), new NotifyService(new LoggerService())),
               _ => null
           };

        private static IVegetablesRepository? GetRepository(ConsoleKey consoleKey) =>
             consoleKey switch
             {
                 ConsoleKey.C => new CabbageRepository(),
                 ConsoleKey.B => new CornRepository(),
                 ConsoleKey.S => new CucumbersRepository(),
                 ConsoleKey.A => new DillRepository(),
                 ConsoleKey.K => new OnionRepository(),
                 _ => null
             };

        private static void ShowListOption()
        {
            Console.WriteLine(@"Choose sweets:
            C => Cabbage
            B => Corn 
            S => Cucumbers
            A => Dill
            K => Onion
            _ => Exite creator, to next step");
        }

        private static List<Vegetables> GetListIngridients()
        {
            IVegetablesRepository? vegetablesRepository;
            IVegetablesService? vegetablesService;
            List<Vegetables> listIngridient = new List<Vegetables>();
            ConsoleKey consoleKey;

            while(true)
            {
                Console.WriteLine("Create ingridients what you want add to calad: ");

                ShowListOption();

                consoleKey = Console.ReadKey().Key;

                vegetablesRepository = GetRepository(consoleKey);

                if (vegetablesRepository == null)
                {
                    return listIngridient;
                }

                vegetablesService = GetService(consoleKey, vegetablesRepository);

                Console.WriteLine("Enter weight ingridient: ");

                double weight = 0;

                while (true)
                {
                    if (!double.TryParse(Console.ReadLine(), out weight))
                    {
                        Console.WriteLine("enter double number!");
                    }
                    else 
                    { 
                        break;
                    }
                }

                string id = vegetablesService.AddVegetable(weight);

                listIngridient.Add(vegetablesService.GetVegetables(id));
            }
        }

        public void ShowOption()
        {
            Console.WriteLine(@"Choose params:
            N => Name
            O => Weight 
            P => Calories
            A => Id
            _ => don`t, to next step...");
        }

        private void TypeOfSorting()
        {
            Console.WriteLine(@"Choose sort: 
            A - sort in descending order,
            B - sort by growth,
            _=> exit sort, next step...");
        }

        private List<Vegetables> ChoseTypeSort(List<Vegetables> listSweets, ConsoleKey consoleKey)
        {
            ConsoleKey consoleKeySwitch;

            switch (consoleKey)
            {
                case ConsoleKey.A:

                    ShowOption();

                    consoleKeySwitch = Console.ReadKey().Key;

                    return listSweets.SortToSomeParamsDescending(consoleKeySwitch);

                case ConsoleKey.B:

                    ShowOption();

                    consoleKeySwitch = Console.ReadKey().Key;

                    return listSweets.SortToSomeParams(consoleKeySwitch);

                default:

                    return listSweets;
            }
        }
        private void GetFullInfo(Vegetables list)
        {
            Console.WriteLine($"name:  {list.Name}, weight: {list.Weight}, calories: {list.Calories}");
        }

        private void ShowFullInfoList(List<Vegetables> list)
        {
            foreach (var item in list)
            {
                GetFullInfo(item);
            }
        }

        private string GetNameSalad()
        {
            Console.WriteLine("Enter name your salad: ");

            string? name = Console.ReadLine().ToString();

            return name;
        }

        private void FindObject(List<Vegetables> list)
        {
            Console.WriteLine("Chose params for search and enter value:");

            ShowOption();

            ConsoleKey consoleKey = Console.ReadKey().Key;

            double compareValuesDouble = 0;

            string compareValuesStr = string.Empty;

            Console.WriteLine("Enter value parametr to find");

            if (consoleKey == ConsoleKey.O && consoleKey == ConsoleKey.P)
            {
                while (!double.TryParse(Console.ReadLine(), out compareValuesDouble))
                {
                    Console.WriteLine("enter only integer number");
                }
            }
            else
            {
                compareValuesStr = Console.ReadLine().ToString();
            }

            Vegetables? resultOfFind = list.FindObjectToParams(consoleKey, compareValuesStr, compareValuesDouble);

            if (resultOfFind == null)
            {
                Console.WriteLine("Can`t find object!!");

                Console.WriteLine("another attempt");

                return;
            }

            Console.WriteLine("result of search: ");

            GetFullInfo(resultOfFind);
        }
    }
}
