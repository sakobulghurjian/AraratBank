using System.ComponentModel.DataAnnotations;

namespace AraratBank.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        // for seller
        public int SoldPrice { get; set; }

        // for buyer
        public int PurchasedPrice { get; set; }

        public Status Status { get; set; }

        public string CurrencyId { get; set; }
    }
}
