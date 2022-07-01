using System.ComponentModel.DataAnnotations;

namespace AraratBank.Models
{
    public class API
    {
        [Key]
        public int Id { get; set; }

        public APIMethods Method { get; set; }

        public DateTime Date { get; set; }

        public string URL { get; set; }
    }
}
