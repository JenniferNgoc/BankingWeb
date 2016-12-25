namespace Banking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserTransaction")]
    public partial class UserTransaction
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string TransactionNo { get; set; }

        public int? UserId { get; set; }

        public int? TransactionType { get; set; }

        public decimal? StartBalance { get; set; }

        public decimal? EndBalance { get; set; }

        public decimal? Amount { get; set; }

        public virtual Account Account { get; set; }
    }
}
