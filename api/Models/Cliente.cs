using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
        
{
    public class Cliente
    {   
        //properties representacion de los campos de tabla sql cliente
        
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }    
        public String  surname { get; set; }
        public int document { get; set; }
        public string phone { get; set; }   
        public String mail { get; set; }
        public String password { get; set; }    
    }
}
