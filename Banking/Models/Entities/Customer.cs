using System.Collections.Generic;

namespace Banking.Models.Entities
{
    public class Customer
    {
        public int customerId { get; set; }
        public int identificationNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<Account> accountList { get; set; }
        //Mejorar
        public string bankAName { get; set; }
        public string bankBName { get; set; }
        public string bankCName { get; set; }
        public decimal bankABalance { get; set; }
        public decimal bankBBalance { get; set; }
        public decimal bankCBalance { get; set; }
    }

}