namespace ComputerService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hcibaza.user")]
    public partial class user
    {
        [Key]
        [Column(Order = 0)]
        public int iduser { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int account_idaccount { get; set; }

        public virtual account account { get; set; }
    }
}
