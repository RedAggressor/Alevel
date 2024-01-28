using Models;

namespace HomeWork7
{
    internal static class ExtentionGiftService
    {
        public static Sweets? FindObjectToParams(this List<Sweets> listSweets, ConsoleKey consoleKey, string compareValuesStr = "", int compareValuesInt = 0) =>
           consoleKey switch
           {
               ConsoleKey.N => listSweets.Find(p => p.Name == compareValuesStr),
               ConsoleKey.O => listSweets.Find(p => p.Weight == compareValuesInt),
               ConsoleKey.P => listSweets.Find(p => p.GetType().Name == compareValuesStr),
               ConsoleKey.A => listSweets.Find(p => p.Id == compareValuesStr),
               _ => null
           };

        public static List<Sweets> SortToSomeParams(this List<Sweets> listSweets, ConsoleKey consoleKey) =>
            consoleKey switch
            {
                ConsoleKey.N => listSweets.OrderBy(p => p.Name).ToList(),
                ConsoleKey.O => listSweets.OrderBy(p => p.Weight).ToList(),
                ConsoleKey.P => listSweets.OrderBy(p => p.GetType().Name).ToList(),
                ConsoleKey.A => listSweets.OrderBy(p => p.Id).ToList(),
                _ => listSweets
            };

        public static List<Sweets> SortToSomeParamsDescending(this List<Sweets> listSweets, ConsoleKey consoleKey) =>
            consoleKey switch
            {
                ConsoleKey.N => listSweets.OrderByDescending(p => p.Name).ToList(),
                ConsoleKey.O => listSweets.OrderByDescending(p => p.Weight).ToList(),
                ConsoleKey.P => listSweets.OrderByDescending(p => p.GetType().Name).ToList(),
                ConsoleKey.A => listSweets.OrderByDescending(p => p.Id).ToList(),
                _ => listSweets
            };
    }
}
