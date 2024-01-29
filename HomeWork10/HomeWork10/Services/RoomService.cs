using HomeWork10.Models;
using HomeWork10.Services.Abstractions;
using System.Runtime.CompilerServices;

namespace HomeWork10.Services
{
    internal class RoomService : IRoomService
    {
        private readonly IRosetteService _serviceRosette;
        private readonly Room _room;

        public RoomService(IRosetteService rosetteService)
        { 
            _serviceRosette = rosetteService;
            _room = new Room(); 
        }
       
        public void TurnOnOffApliance(ElectricalAppliances electrical)                              
        {
            Console.WriteLine($"Connect to rosette {electrical.Id} : {electrical.GetType().Name} y/n?");
           
            _room.Appliances.Add(_serviceRosette.СonnecDisconectDevice(electrical, (Console.ReadKey().Key == ConsoleKey.Y)));
        }

        private double GetTotalElectricityCost()
        {
            return _room.Appliances.Where(p=>p.TornOn == true)
                                   .Select(p=>p.Consumes)
                                   .Sum();
        }

        public void ShowFullInfo()
        {
            List<ElectricalAppliances> appliances = GetRoom().Appliances;

            foreach (var item in appliances)
            {
                Console.WriteLine($"Id:{item.Id}, Name: {item.Name}, Power: {item.Power}, Consumens: {item.Consumes}, turnOn: {item.TornOn}," +
                    $"Brend: Name:{item.Brend.Name}; country: {item.Brend.Country}; country brend registration: {item.Brend.BrendRegistration}");
            }

            Console.WriteLine("Total electrysiti Consumens: " + GetTotalElectricityCost());
        }

        public Room GetRoom()
        {
            return _room;
        }
    }
}
