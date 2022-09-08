//importamos DataAnnotations
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
        
{
    public class Customer
    {   
        //properties representacion de los campos de tabla sql cliente
        
        [Key]
        public int idCustomer { get; set; } 
        public string name { get; set; }    
        public String  surname { get; set; }
        public int document { get; set; }
        public string phoneNumber { get; set; }   
        public String mail { get; set; }
        public String password { get; set; }    
    }
}
