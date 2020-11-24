using Banking.Models.Enums;

namespace Banking.Models.Entities
{
    public class Account
    {
        public int acoountId { get; set; }
        public string accounCode { get; set; }
        public Bank bankId { get; set; }
        public int customerId { get; set; }
        public decimal balance { get; set; }

    }
}