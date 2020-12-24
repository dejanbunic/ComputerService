namespace ComputerService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hcibaza.service")]
    public partial class service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public service()
        {
            service_sheet = new HashSet<service_sheet>();
        }

        [Key]
        public int idservice { get; set; }

        [Required]
        [StringLength(45)]
        public string name { get; set; }

        public decimal price { get; set; }

        [Required]
        [StringLength(128)]
        public string type { get; set; }

        public sbyte delete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<service_sheet> service_sheet { get; set; }
    }
}
