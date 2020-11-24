namespace BankingApiREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banking.Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Movements = new HashSet<Movement>();
        }

        [Key]
        public int AcoountId { get; set; }

        [Required]
        [StringLength(5)]
        public string AccounCode { get; set; }

        public int BankId { get; set; }

        public int CustomerId { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        public  Bank Bank { get; set; }

        public  Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<Movement> Movements { get; set; }
    }
}
