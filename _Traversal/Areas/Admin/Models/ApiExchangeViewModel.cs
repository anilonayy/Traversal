namespace _Traversal.Areas.Admin.Models
{
    public class ApiExchangeViewModel
    {
        public ER[] exchange_rates { get; set; }

        public string base_currency_date { get; set; }
        public string base_currency { get; set; }

    }
    public class ER
    {
        public string exchange_rate_buy { get; set; }
        public string currency { get; set; }
    }
}
