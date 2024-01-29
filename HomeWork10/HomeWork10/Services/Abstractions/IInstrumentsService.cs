using HomeWork10.Models.Enums;
using HomeWork10.Models;
using System.Drawing;

namespace HomeWork10.Services.Abstractions
{
    internal interface IInstrumentsService
    {
        public string AddInstruments(string name, int consumes, Color color, TypeInstruments typeAppliance, int weight);
        public Instruments GetInstruments(string id);
    }
}
