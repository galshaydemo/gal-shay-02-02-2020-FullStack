namespace RealComm.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=RmDatabase")
        {
        }
        public virtual DbSet<Weather> Weather { get; set; }
        public virtual DbSet<Favorite> Favorite { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorite>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
