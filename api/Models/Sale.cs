using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Sale
    {
        [Key]
        public int idSale { get; set; }
        public int idCustomer { get; set; }
        public DateTime date { get; set; }
        public String location { get; set; }
      
    }
}
