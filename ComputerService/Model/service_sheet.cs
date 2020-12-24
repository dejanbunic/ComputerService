namespace ComputerService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hcibaza.service_sheet")]
    public partial class service_sheet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public service_sheet()
        {
            components = new HashSet<component>();
            services = new HashSet<service>();
        }

        [Key]
        public int idservice_sheet { get; set; }

        public DateTime date { get; set; }

        public decimal price { get; set; }

        [Required]
        [StringLength(1024)]
        public string description { get; set; }

        public int product_idproduct { get; set; }

        public int person_idperson { get; set; }

        [Required]
        [StringLength(45)]
        public string status { get; set; }

        public sbyte delete { get; set; }

        public virtual person person { get; set; }

        public virtual product product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<component> components { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<service> services { get; set; }
    }
}
