using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Provider
    {
        [Key]
        public int idProvider { get; set; }

        public string provider_name { get; set; }   

        public string nit { get; set; }

        public string address { get; set; }

        public string phone { get; set; }


    }
}
