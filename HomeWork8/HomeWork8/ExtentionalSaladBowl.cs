using Models;

namespace HomeWork8
{
    internal static class ExtentionalSaladBowl
    {
         public static List<Vegetables> SortToSomeParams(this List<Vegetables> listSweets, ConsoleKey consoleKey) =>
            consoleKey switch
            {
                ConsoleKey.N => listSweets.OrderBy(p => p.Name).ToList(),
                ConsoleKey.O => listSweets.OrderBy(p => p.Weight).ToList(),
                ConsoleKey.P => listSweets.OrderBy(p => p.Calories).ToList(),
                ConsoleKey.A => listSweets.OrderBy(p => p.Id).ToList(),
                _ => listSweets
            };

        public static List<Vegetables> SortToSomeParamsDescending(this List<Vegetables> listSweets, ConsoleKey consoleKey) =>
            consoleKey switch
            {
                ConsoleKey.N => listSweets.OrderByDescending(p => p.Name).ToList(),
                ConsoleKey.O => listSweets.OrderByDescending(p => p.Weight).ToList(),
                ConsoleKey.P => listSweets.OrderByDescending(p => p.Calories).ToList(),
                ConsoleKey.A => listSweets.OrderByDescending(p => p.Id).ToList(),
                _ => listSweets
            };
        public static Vegetables? FindObjectToParams(this List<Vegetables> listSweets, ConsoleKey consoleKey, string compareValuesStr = "", double compareValuesDouble = 0) =>
          consoleKey switch
          {
              ConsoleKey.N => listSweets.Find(p => p.Name == compareValuesStr),
              ConsoleKey.O => listSweets.Find(p => p.Weight == compareValuesDouble),
              ConsoleKey.P => listSweets.Find(p => p.Calories == compareValuesDouble),
              ConsoleKey.A => listSweets.Find(p => p.Id == compareValuesStr),
              _ => null
          };
    }
}
