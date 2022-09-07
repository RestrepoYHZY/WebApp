using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Detalle_venta
    {
        [Key]
        public int Id { get; set; } 

        public int product_code { get; set; }

        public int order_code { get; set; }

        public int amount { get; set; }

        public double total_price { get; set; }
    }
}
