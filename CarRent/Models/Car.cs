using CarRent.Data;
//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;

namespace CarRent.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "filling in this field is required")]
        public string Brand { get; set; }
    //14055 
        [Required(ErrorMessage = "filling in this field is required")]
        public string Model { get; set; }

        [Required(ErrorMessage = "filling in this field is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "filling in this field is required")]
        public string Color { get; set; }

        [Required(ErrorMessage = "filling in this field is required")]
        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customers? customer { get; set; }
    }


}
