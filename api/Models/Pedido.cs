using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public int clientCode { get; set; }
        public DateTime date { get; set; }
        public String location { get; set; }
      
    }
}
