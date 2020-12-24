namespace ComputerService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hcibaza.administrator")]
    public partial class administrator
    {
        [Key]
        [Column(Order = 0)]
        public int idadministrator { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int account_idaccount { get; set; }

        public virtual account account { get; set; }
    }
}
