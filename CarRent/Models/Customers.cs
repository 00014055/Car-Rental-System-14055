using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    public class Customers
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "filling in this field is required")]
        public string customer_name { get; set; }

        [Required(ErrorMessage = "filling in this field is required")]
        public string customer_email { get; set;}

        [Required(ErrorMessage = "filling in this field is required")]
        public string customer_phone { get; set;}
    }
}
