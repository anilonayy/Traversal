namespace _Traversal.Areas.Admin.Models.ViewModels
{
    public class AccountCreateViewModel
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        public decimal Amount { get; set; }

        public decimal SenderNewBalance { get; set; }

        public decimal ReceiverNewBalance { get; set; }
    }
}
