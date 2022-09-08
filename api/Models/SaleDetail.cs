using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SaleDetail
    {
        [Key]
        public int idDetail { get; set; } 

        public int idProduct { get; set; }

        public int idSale { get; set; }

        public int amountSale { get; set; }

        public double total_price { get; set; }
    }
}
