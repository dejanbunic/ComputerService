namespace ComputerService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hcibaza.product")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            service_sheet = new HashSet<service_sheet>();
        }

        [Key]
        public int idproduct { get; set; }

        [StringLength(128)]
        public string product_number { get; set; }

        [StringLength(128)]
        public string manufacturer { get; set; }

        [StringLength(128)]
        public string seria { get; set; }

        [Required]
        [StringLength(128)]
        public string type { get; set; }

        public sbyte delete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<service_sheet> service_sheet { get; set; }
    }
}
