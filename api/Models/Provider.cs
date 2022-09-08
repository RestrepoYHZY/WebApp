using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Provider
    {
        [Key]
        public int idProvider { get; set; }

        public string provider_name { get; set; }   

        public String nit { get; set; }

        public String address { get; set; }

        public int phone { get; set; }


    }
}
