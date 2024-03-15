using CarRent.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;

namespace CarRent.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }


        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customers? customer { get; set; }
    }


}