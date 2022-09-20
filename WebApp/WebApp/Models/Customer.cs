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
        public string  surname { get; set; }
        public string document { get; set; }
        public string phoneNumber { get; set; }   
        public string mail { get; set; }
       
    }
}
