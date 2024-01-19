using Repositores;
using Services.Abstraction;
using Services;
using Repositores.Abstraction;
using Models;

namespace HomeWork7
{
    internal static class Starter
    {
        public static void StartUp()
        {
            ConsoleKey consoleKey;

            IGiftService gift = CreateParamsForGift(out int weightGift);

            string idGift = gift.CreateGift(weightGift);

            while (true)
            {
                ShowListOption();

                consoleKey = Console.ReadKey().Key;

                ISweetsRepository? sweetsRepository = GetRepository(consoleKey);

                if (sweetsRepository == null)
                {
                    break;
                }

                ISweetsService? sweetsService = GetService(consoleKey, sweetsRepository);

                CreateParamsForSweets(sweetsService, out string name, out int weightSweets);

                string idSweets = sweetsService.AddSweets(name, weightSweets);

                gift.AddToGift(idGift, sweetsService.GetSweets(idSweets));
            }

            List<Sweets> listGifts = gift.GetListOfSweets(idGift);

            Console.WriteLine("Sweets in to gift: ");

            ShowFullInfoList(listGifts);

            Gift giftforInfo = gift.GetGift(idGift);

            ShowWeightGiftInfo(listGifts, giftforInfo);

            TypeOfSorting();

            consoleKey = Console.ReadKey().Key;

            List<Sweets> listGiftAfterSort = listGifts.ChoseTypeSort(consoleKey);

            ShowFullInfoList(listGiftAfterSort);

            FindObject(listGiftAfterSort);
        }

        private static void ShowWeightGiftInfo(List<Sweets> list, Gift gift)
        { 
            int totalWeight = list.Select(p => p.Weight).Sum();

            int maxWeight = gift.MaxWeight;

            Console.WriteLine($"All sweets in gift weight = {totalWeight}, weight indicator gift {totalWeight}/{maxWeight}");
        }

        private static void FindObject(List<Sweets> list)
        {
            Console.WriteLine("Chose params for search and enter value:");

            ShowOption();

            ConsoleKey consoleKey = Console.ReadKey().Key;

            int compareValuesInt = 0;

            string compareValuesStr = "";

            if (consoleKey == ConsoleKey.O)
            {
                while (!int.TryParse(Console.ReadLine(), out compareValuesInt))
                {
                    Console.WriteLine("enter only integer number");
                }
            }
            else
            {
                compareValuesStr = Console.ReadLine().ToString();
            }

            Sweets? resultOfFind = list.FindObjectToParams(consoleKey, compareValuesStr, compareValuesInt);

            if (resultOfFind == null)
            {
                Console.WriteLine("Can`t find object!!");

                Console.WriteLine("another attempt");

                return;
            }

            Console.WriteLine("result of search: ");

            GetFullInfo(resultOfFind);
        }

        private static void TypeOfSorting()
        {
            Console.WriteLine(@"Choose sort: 
            A - sort in descending order,
            B - sort by growth,
            _=> exit sort, next step...");
        }
        private static ISweetsService? GetService(ConsoleKey consoleKey, ISweetsRepository sweets) =>
            consoleKey switch
            {
                ConsoleKey.C => new CandyService(sweets, new LoggerService(), new NotifyService(new LoggerService())),
                ConsoleKey.B => new BakingService(sweets, new LoggerService(), new NotifyService(new LoggerService())),
                ConsoleKey.S => new SweetsService(sweets, new LoggerService(), new NotifyService(new LoggerService())),
                ConsoleKey.A => new CakeService(sweets, new LoggerService(), new NotifyService(new LoggerService())),
                ConsoleKey.K => new ChocolateService(sweets, new LoggerService(), new NotifyService(new LoggerService())),
                _ => null
            };

        private static ISweetsRepository? GetRepository(ConsoleKey consoleKey) =>
             consoleKey switch
             {
                 ConsoleKey.C => new CandyRepository(),
                 ConsoleKey.B => new BakingRepository(),
                 ConsoleKey.S => new SweetsRepository(),
                 ConsoleKey.A => new CakeRepository(),
                 ConsoleKey.K => new ChocolateRepository(),
                 _ => null
             };

        private static void GetFullInfo(Sweets list)
        {          
            Console.WriteLine($"id: {list.Id}, type:  {list.GetType().Name}, name:  {list.Name}, weight:  {list.Weight}");
        }

        private static void ShowFullInfoList(List<Sweets> list)
        {
            foreach (var item in list)
            {
                GetFullInfo(item);
            }
        }

        private static IGiftService CreateParamsForGift(out int weightGift)
        {
            IGiftService gift;

            Console.WriteLine("Create gift. enter weight(in gramms): ");

            while (!int.TryParse(Console.ReadLine(), out weightGift))
            {
                Console.WriteLine("enter only integer number");
            }

            IGiftRepository giftRepository = new GiftRepository();

            gift = new GiftService(giftRepository, new LoggerService(), new NotifyService(new LoggerService()));
            
            return gift;
        }

        private static void ShowListOption()
        {
            Console.WriteLine(@"Choose sweets:
            C => Candy
            B => Baking 
            S => Sweets
            A => Cake
            K => Chocolate
            _ => Exite creator, to next step");
        }

        private static void CreateParamsForSweets(ISweetsService sweetsService, out string name, out int weightSweets)
        {
            Console.WriteLine($"\nCreate {sweetsService.GetType().Name.ToString()[..^7]} weight and name");

            Console.WriteLine("enter name");

            name = Console.ReadLine().ToString();

            Console.WriteLine("enter weight");

            while (!int.TryParse(Console.ReadLine(), out weightSweets))
            {
                Console.WriteLine("enter only integer number");
            }
        }

        private static List<Sweets> SortToSomeParams(this List<Sweets> listSweets, ConsoleKey consoleKey) =>
            consoleKey switch
            {
                ConsoleKey.N => listSweets.OrderBy(p => p.Name).ToList(),
                ConsoleKey.O => listSweets.OrderBy(p => p.Weight).ToList(),
                ConsoleKey.P => listSweets.OrderBy(p => p.GetType().Name).ToList(),
                ConsoleKey.A => listSweets.OrderBy(p => p.Id).ToList(),
                _ => listSweets
            };

        private static List<Sweets> SortToSomeParamsDescending(this List<Sweets> listSweets, ConsoleKey consoleKey) =>
            consoleKey switch
            {
                ConsoleKey.N => listSweets.OrderByDescending(p => p.Name).ToList(),
                ConsoleKey.O => listSweets.OrderByDescending(p => p.Weight).ToList(),
                ConsoleKey.P => listSweets.OrderByDescending(p => p.GetType().Name).ToList(),
                ConsoleKey.A => listSweets.OrderByDescending(p => p.Id).ToList(),
                _ => listSweets
            };

        private static List<Sweets> ChoseTypeSort(this List<Sweets> listSweets, ConsoleKey consoleKey)
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
        private static void ShowOption()
        {
            Console.WriteLine(@"Choose params:
            N => Name
            O => Weight 
            P => Type
            A => Id
            _ => don`t, to next step...");
        }

        private static Sweets? FindObjectToParams(this List<Sweets> listSweets, ConsoleKey consoleKey, string compareValuesStr = "", int compareValuesInt = 0) =>
           consoleKey switch
           {
               ConsoleKey.N => listSweets.Find(p => p.Name == compareValuesStr),
               ConsoleKey.O => listSweets.Find(p => p.Weight == compareValuesInt),
               ConsoleKey.P => listSweets.Find(p => p.GetType().Name == compareValuesStr),
               ConsoleKey.A => listSweets.Find(p => p.Id == compareValuesStr),
               _ => null
           };
    }
}
