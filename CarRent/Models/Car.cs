using CarRent.Data;
namespace CarRent.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Owner_id { get; set; }
    }


}