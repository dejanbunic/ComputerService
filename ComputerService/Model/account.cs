namespace ComputerService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hcibaza.account")]
    public partial class account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public account()
        {
            administrators = new HashSet<administrator>();
            users = new HashSet<user>();
        }

        [Key]
        public int idaccount { get; set; }

        [Required]
        [StringLength(512)]
        public string username { get; set; }

        [Required]
        [StringLength(512)]
        public string password { get; set; }

        [Required]
        [StringLength(512)]
        public string skin { get; set; }

        public sbyte delete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<administrator> administrators { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
    }
}
