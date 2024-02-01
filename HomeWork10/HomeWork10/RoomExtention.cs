using HomeWork10.Models;

namespace HomeWork10
{
    internal static class RoomExtention
    {
        public static List<ElectricalAppliances> SortRoom(this List<ElectricalAppliances> appliances, ConsoleKey consoleKey) =>
            consoleKey switch
            {
                ConsoleKey.N => appliances.OrderBy(p => p.Name).ToList(),
                ConsoleKey.O => appliances.OrderBy(p => p.Id).ToList(),
                ConsoleKey.P => appliances.OrderBy(p => p.Power).ToList(),
                ConsoleKey.A => appliances.OrderBy(p => p.Consumes).ToList(),
                ConsoleKey.S => appliances.OrderBy(p => p.Brend.Name).ToList(),
                ConsoleKey.D => appliances.OrderBy(p => p.Brend.Country).ToList(),
                ConsoleKey.H => appliances.OrderBy(p => p.Brend.BrendRegistration).ToList(),
                _ => appliances
            };

        public static List<ElectricalAppliances> SortRoomDescending(this List<ElectricalAppliances> electricals, ConsoleKey consoleKey) =>
           consoleKey switch
           {
               ConsoleKey.N => electricals.OrderByDescending(p => p.Name).ToList(),
               ConsoleKey.O => electricals.OrderByDescending(p => p.Id).ToList(),
               ConsoleKey.P => electricals.OrderByDescending(p => p.Power).ToList(),
               ConsoleKey.A => electricals.OrderByDescending(p => p.Consumes).ToList(),
               ConsoleKey.S => electricals.OrderByDescending(p => p.Brend.Name).ToList(),
               ConsoleKey.D => electricals.OrderByDescending(p => p.Brend.Country).ToList(),
               ConsoleKey.H => electricals.OrderByDescending(p => p.Brend.BrendRegistration).ToList(),
               _ => electricals
           };

        public static List<ElectricalAppliances> FindApliance(this List<ElectricalAppliances> electricals, string firstChar, int atValue, int toValue)
        {
            return electricals.FindAll(p => p.Name[0].ToString().ToLower() == firstChar).FindAll(p => p.Consumes >= atValue && p.Consumes <= toValue).FindAll(p => p.Power >= atValue && p.Power <= toValue).ToList();
        }
    }
}
