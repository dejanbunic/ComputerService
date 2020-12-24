namespace ComputerService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hcibaza.person")]
    public partial class person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public person()
        {
            service_sheet = new HashSet<service_sheet>();
        }

        [Key]
        public int idperson { get; set; }

        [Required]
        [StringLength(512)]
        public string name { get; set; }

        [StringLength(45)]
        public string phone_number { get; set; }

        [Column("e-mail")]
        [StringLength(45)]
        public string e_mail { get; set; }

        public sbyte delete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<service_sheet> service_sheet { get; set; }
    }
}
