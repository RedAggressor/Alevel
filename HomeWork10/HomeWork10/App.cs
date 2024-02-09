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
            bool skip = true;

            while (skip)
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
                            skip = false;
                            break;
                        }
                }
            }

            _roomService.ShowInfoAboutApliance();

            Room room = _roomService.GetRoom();

            List<ElectricalAppliances> emptyAppliances = new List<ElectricalAppliances>();

            room = ChageRoom(room, emptyAppliances);

            _roomService.ShowInfoAboutApliance();

            room = ChageRoom(room, emptyAppliances);

            _roomService.ShowInfoAboutApliance();

            room.Appliances = FindApliances(room);

            _roomService.ShowInfoAboutApliance();
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
            while (!int.TryParse(Console.ReadLine(), out number));

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

        private void SetTypeHousehold(out HouseholdType typeHousehold)
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

        private HouseholdType ChooseTypeHousehold(ConsoleKey consoleKey) =>
            consoleKey switch
            {
                ConsoleKey.B => HouseholdType.Microwave,
                ConsoleKey.W => HouseholdType.VacuumСleaner,
                ConsoleKey.G => HouseholdType.ElectricKettle,
                ConsoleKey.S => HouseholdType.Refrigerator,
                ConsoleKey.Y => HouseholdType.WashingMachine
            };

        private Household Createhousehold()
        {
            SetName(out string name);

            SetConsoments(out int consumens);

            SetColor(out Color color);

            SetTypeHousehold(out HouseholdType typeHousehold);

            Household household = new Household()
            {
                Name = name,
                Consumes = consumens,
                Color = color,
                HouseholdType = typeHousehold

            };

            string idHousehold = _householdService.AddHousehold(household);

            return _householdService.GetHouseholds(idHousehold);
        }

        private Instruments CreateInnstrument()
        {
            SetName(out string name);

            SetConsoments(out int consumens);

            SetTypeInstruments(out InstrumentsType typeInstruments);

            SetWeight(out int weight);

            Instruments instruments = new Instruments()
            {
                Name = name,
                Consumes = consumens,
                InstrumentsType = typeInstruments,
                Weight = weight
            };

            string idInstruments = _instrumentsService.AddInstruments(instruments);

            return _instrumentsService.GetInstruments(idInstruments);
        }

        private void SetTypeInstruments(out InstrumentsType typeInstruments)
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

        private InstrumentsType ChooseTypeInstruments(ConsoleKey consoleKey) =>
            consoleKey switch
            {
                ConsoleKey.B => InstrumentsType.WeldingMachine,
                ConsoleKey.W => InstrumentsType.CircularSaw,
                ConsoleKey.G => InstrumentsType.Screwdriver,
                ConsoleKey.S => InstrumentsType.Drill,
                ConsoleKey.Y => InstrumentsType.Jigsaw
            };

        private void AddToRoom(ElectricalAppliances electricalAppliances)
        {
            _roomService.SwitchApliances(electricalAppliances);
        }
    }
}
