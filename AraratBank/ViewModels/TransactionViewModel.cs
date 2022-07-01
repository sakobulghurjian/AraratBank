namespace AraratBank.ViewModels
{
    public class TransactionViewModel
    {
        public DateTime Date { get; set; }

        // for seller
        public int SoldPrice { get; set; }

        // for buyer
        public int PurchasedPrice { get; set; }

        public string Status { get; set; }

        public string CurrencyType { get; set; }
    }
}
