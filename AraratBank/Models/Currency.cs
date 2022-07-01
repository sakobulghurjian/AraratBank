using System.ComponentModel.DataAnnotations;

namespace AraratBank.Models
{
    public class Currency
    {
        [Key]
        public string Id { get; set; }

        public string CurrencyType { get; set; }
    }
}
