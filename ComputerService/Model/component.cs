namespace ComputerService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hcibaza.component")]
    public partial class component
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public component()
        {
            service_sheet = new HashSet<service_sheet>();
        }

        [Key]
        public int idcomponent { get; set; }

        [Required]
        [StringLength(128)]
        public string type { get; set; }

        [StringLength(128)]
        public string manufacturer { get; set; }

        [StringLength(128)]
        public string seria { get; set; }

        public decimal price { get; set; }

        public sbyte delete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<service_sheet> service_sheet { get; set; }
    }
}
