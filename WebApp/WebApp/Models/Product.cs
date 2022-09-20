using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Product
    {
        [Key]
        public int idProduct { get; set; }    

        public int idProvider { get; set; }
        
        public string product_name { get; set; }    

        public string description { get; set; } 

        public decimal price { get; set; }

        public int amount { get; set; }

        public Provider Provider { get; set; }
    }
}
