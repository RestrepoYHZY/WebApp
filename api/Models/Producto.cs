using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }    

        public int provider_code { get; set; }

        public string product_name { get; set; }    

        public String description { get; set; } 

        public double price { get; set; }   


    }
}
