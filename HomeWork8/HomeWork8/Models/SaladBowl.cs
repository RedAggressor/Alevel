namespace Models
{
    internal class SaladBowl
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Calories { get; set; }
        public List<Vegetables> VegetablesList { get; set; }

    }
}
