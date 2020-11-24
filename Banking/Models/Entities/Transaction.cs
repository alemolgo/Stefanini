using Banking.Models.Enums;

namespace Banking.Models.Entities
{
    public class Transaction
    {
        public TransactionType transactionType { get; set; }
        public decimal amount { get; set; }
    }
  
}