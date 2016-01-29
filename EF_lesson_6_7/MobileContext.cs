using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_6_7
{
    public class MobileContext : DbContext
    {
        public MobileContext():base("EF_lesson_6_7")
        { }

        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // переопределение добавления
            modelBuilder.Entity<Phone>()
                .MapToStoredProcedures(b => b.Insert(sp => sp.HasName("InsertPhone")
                    .Parameter(pm => pm.Name, "Model")
                    .Parameter(pm => pm.Price, "Price")
                    .Result(rs => rs.Id, "Id")));

            // переопределение обновления
            modelBuilder.Entity<Phone>()
                .MapToStoredProcedures(b => b.Update(sp => sp.HasName("UpdatePhone")
                    .Parameter(pm => pm.Name, "Model")
                    .Parameter(pm => pm.Price, "Price")
                    .Parameter(pm => pm.Id, "Id")));

            // переопределение удаления
            modelBuilder.Entity<Phone>()
                .MapToStoredProcedures(b => b.Delete(sp => sp.HasName("DeletePhone")
                    .Parameter(pm => pm.Id, "Id")));

            base.OnModelCreating(modelBuilder);
        }
    }
}
