namespace MoneyJournal.Models.EntityModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AccountBookDbContext : DbContext
    {
        public AccountBookDbContext()
            : base("name=AccountBookDbContext")
        {
        }

        public virtual DbSet<AccountBook> AccountBook { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
