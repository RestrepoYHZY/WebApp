using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Product
    {
        [Key]
        public int idProduct { get; set; }    

        public int idProvider { get; set; }
        
        public string product_name { get; set; }    

        public String description { get; set; } 

        public double price { get; set; }

        public int amount { get; set; }


    }
}
