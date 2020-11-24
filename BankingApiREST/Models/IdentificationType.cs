namespace BankingApiREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banking.IdentificationType")]
    public partial class IdentificationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IdentificationType()
        {
            Customers = new HashSet<Customer>();
        }

        public int IdentificationTypeId { get; set; }

        [Required]
        [StringLength(30)]
        public string IdentificationName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<Customer> Customers { get; set; }
    }
}
