using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        public string provider_name { get; set; }   

        public String nit { get; set; }

        public String address { get; set; }

        public int phone { get; set; }


    }
}
