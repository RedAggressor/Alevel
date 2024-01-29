using HomeWork10.Models;
using HomeWork10.Models.Enums;
using HomeWork10.Services.Abstractions;
using System.Drawing;

namespace HomeWork10
{
    internal class App
    {
        private readonly IHouseholdService _householdService;
        private readonly IRoomService _roomService;
        private readonly IInstrumentsService _instrumentsService;
        
        public App(IHouseholdService householdRepository, IRoomService roomService, IInstrumentsService instrumentsService)
        { 
            _householdService = householdRepository;
            _roomService = roomService;
            _instrumentsService = instrumentsService;
        }
        public void Start()
        {
            bool noSkipe = true;

            while (noSkipe)
            {
                ConsoleKey consoleKey = chooseOneOfAplince();
                switch (consoleKey)
                { 
                    case ConsoleKey.H:
                        {
                            Household household = Createhousehold();
                            AddToRoom(household);
                            break;
                        }
                    case ConsoleKey.I:
                        {
                            Instruments instruments = CreateInnstrument();
                            AddToRoom(instruments);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Exite to Constructor...");
                            noSkipe = false;
                            break;
                        }
                }
            }
                
            _roomService.ShowFullInfo();

            Room room = _roomService.GetRoom();

            List<ElectricalAppliances> emptyAppliances = new List<ElectricalAppliances>();

            room = ChageRoom(room, emptyAppliances);

            _roomService.ShowFullInfo();

            room = ChageRoom(room, emptyAppliances);

            _roomService.ShowFullInfo();

             room.Appliances = FindApliances(room);
            
            _roomService.ShowFullInfo();
        }

        private List<ElectricalAppliances> FindApliances(Room room)
        {
            Console.WriteLine("enter first char what need filter: ");

            string firstChar = Console.ReadKey().Key.ToString().ToLower();

            SetValue(out int atValue);

            SetValue(out int toValue);

            room.Appliances.FindApliance(firstChar, atValue, toValue);

            return room.Appliances;
        }
        private void SetValue(out int number)
        {
            do
            {
                Console.WriteLine("enter at value and to value:");
            }
            while (!int.TryParse(Console.ReadLine(), out number));

        }

        private Room ChageRoom(Room room, List<ElectricalAppliances> emptyAppliances)
        {
            emptyAppliances = ChoseTypeSort(room.Appliances);

            room.Appliances = emptyAppliances;

            return room;
        }

        private List<ElectricalAppliances> ChoseTypeSort(List<ElectricalAppliances> appliances)
        {
            TypeOfSorting();

            ConsoleKey consoleKey = Console.ReadKey().Key;

            ConsoleKey consoleKeySwitch;

            switch (consoleKey)
            {
                case ConsoleKey.A:

                    ShowOption();

                    consoleKeySwitch = Console.ReadKey().Key;

                    return appliances.SortRoomDescending(consoleKeySwitch);

                case ConsoleKey.B:

                    ShowOption();

                    consoleKeySwitch = Console.ReadKey().Key;

                    return appliances.SortRoom(consoleKeySwitch);

                default:

                    return appliances;
            }
        }

        public void ShowOption()
        {
            Console.WriteLine(@"Choose params:
            N => Name
            O => Id
            P => Power
            A => Consumes
            S => Brend.Name
            D => Brend.Country
            H => Brend.BrendRegistration
            _ => don`t, to next step...");
        }

        private static void TypeOfSorting()
        {
            Console.WriteLine(@"Choose sort: 
            A - sort in descending order,
            B - sort by growth,
            _=> exit sort, next step...");
        }

        private ConsoleKey chooseOneOfAplince()
        {
            Console.WriteLine(@"Choose one of apliance:
                                H = houshold,
                                I = instruments,
                                _ => skip constructor");

            return Console.ReadKey().Key;
        }
        
        private void SetConsoments(out int number)
        {
            do
            {
                Console.WriteLine("enter value consuments your apliance:");
            }
            while (!int.TryParse(Console.ReadLine(),out number));
        
        }

        private void SetName(out string name)
        {
            Console.WriteLine("enter name your apliance: ");

            name = Console.ReadLine().ToString();
        }

        private void SetColor(out Color color)
        {
            Console.WriteLine(@"choose color for your apliance:
                                B => Black,
                                W => White,
                                G => Gold,
                                S => Silver,
                                Y => Yellow,
                                R => Gray,
                                _ => Indigo");

            ConsoleKey key = Console.ReadKey().Key;

            color = ChooseColor(key);
        }

        private Color ChooseColor(ConsoleKey consoleKey) =>
            consoleKey switch
            {
                ConsoleKey.B => Color.Black,
                ConsoleKey.W => Color.White,
                ConsoleKey.G => Color.Gold,
                ConsoleKey.S => Color.Silver,
                ConsoleKey.Y => Color.Yellow,
                ConsoleKey.R => Color.Gray,
                _ => Color.Indigo
            };

        private void SetTypeHousehold(out TypeHousehold typeHousehold)
        {
            ConsoleKey consoleKey;
            do
            {
                Console.WriteLine(@"Set you type of apliance:
                            B => Microwave,
                            W => VacuumСleaner,
                            G => ElectricKettle,
                            S => Refrigerator,
                            Y => WashingMachine");

                consoleKey = Console.ReadKey().Key;
            }
            while (CheckButton(consoleKey));

            typeHousehold = ChooseTypeHousehold(consoleKey);
        }
        private bool CheckButton(ConsoleKey consoleKey) =>
            consoleKey switch
            {
                ConsoleKey.B => false,
                ConsoleKey.W => false,
                ConsoleKey.G => false,
                ConsoleKey.S => false,
                ConsoleKey.Y => false,
                _ => true
            };
        private TypeHousehold ChooseTypeHousehold(ConsoleKey consoleKey) =>
            consoleKey switch
            {
                ConsoleKey.B => TypeHousehold.Microwave,
                ConsoleKey.W => TypeHousehold.VacuumСleaner,
                ConsoleKey.G => TypeHousehold.ElectricKettle,
                ConsoleKey.S => TypeHousehold.Refrigerator,
                ConsoleKey.Y => TypeHousehold.WashingMachine
            };
       
        private Household Createhousehold()
        {
            SetName(out string name);

            SetConsoments(out int consumens);

            SetColor(out Color color);

            SetTypeHousehold(out TypeHousehold typeHousehold);

            string idHousehold = _householdService.AddHousehold(name, consumens, color, typeHousehold);

            return _householdService.GetHouseholds(idHousehold);
        }

        private Instruments CreateInnstrument()
        {
            SetName(out string name);

            SetConsoments(out int consumens);

            SetColor(out Color color);

            SetTypeInstruments(out TypeInstruments typeInstruments);

            SetWeight(out int weight);

            string idInstruments = _instrumentsService.AddInstruments(name, consumens, color, typeInstruments, weight);

            return _instrumentsService.GetInstruments(idInstruments);
        }
        private void SetTypeInstruments(out TypeInstruments typeInstruments)
        {
            ConsoleKey consoleKey;
            do
            {
                Console.WriteLine(@"Set you type of apliance:
                            B => WeldingMachine,
                            W => CircularSaw,
                            G => Screwdriver,
                            S => Drill,
                            Y => Jigsaw");

                consoleKey = Console.ReadKey().Key;
            }
            while (CheckButton(consoleKey));

            typeInstruments = ChooseTypeInstruments(consoleKey);
        }

        private void SetWeight(out int number)
        {
            do
            {
                Console.WriteLine("enter value weight your apliance:");
            }
            while (!int.TryParse(Console.ReadLine(), out number));

        }

        private TypeInstruments ChooseTypeInstruments(ConsoleKey consoleKey) =>
            consoleKey switch
            {
                ConsoleKey.B => TypeInstruments.WeldingMachine,
                ConsoleKey.W => TypeInstruments.CircularSaw,
                ConsoleKey.G => TypeInstruments.Screwdriver,
                ConsoleKey.S => TypeInstruments.Drill,
                ConsoleKey.Y => TypeInstruments.Jigsaw
            };

        private void AddToRoom(ElectricalAppliances electricalAppliances)
        {
            _roomService.TurnOnOffApliance(electricalAppliances);
        }
    }
}
