namespace BankingApiREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banking.Movement")]
    public partial class Movement
    {
        public int MovementId { get; set; }

        public int MovementTypeId { get; set; }

        public int SourceAccountId { get; set; }

        public int TargetAccountId { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Column(TypeName = "money")]
        public decimal GMF { get; set; }

        public DateTime MovementDay { get; set; }

        public  Account Account { get; set; }

        public  MovementType MovementType { get; set; }
    }
}
