namespace BankingApiREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banking.MovementType")]
    public partial class MovementType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MovementType()
        {
            Movements = new HashSet<Movement>();
        }

        public int MovementTypeId { get; set; }

        [Required]
        [StringLength(30)]
        public string MovementName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<Movement> Movements { get; set; }
    }
}
