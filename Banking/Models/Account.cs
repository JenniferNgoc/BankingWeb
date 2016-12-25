namespace Banking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public Account()
        {
            UserTransactions = new HashSet<UserTransaction>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string AccountNumber { get; set; }

        [StringLength(50)]
        public string AccountName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public decimal? Balance { get; set; }

        public virtual ICollection<UserTransaction> UserTransactions { get; set; }
    }
}
