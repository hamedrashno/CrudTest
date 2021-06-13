using HamedRashnoCrudTest.Data.Contexts.Interfaces;
using HamedRashnoCrudTest.Domain.Base;
using HamedRashnoCrudTest.Domain.Customer;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace HamedRashnoCrudTest.Data.Contexts
{
    public class SqlDataContext : DbContext, ISqlDataContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(Local);Initial Catalog=CrudTest;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerEntity>()
                .HasIndex(c => new { c.FirstName, c.LastName ,c.DateOfBirth})
                .IsUnique(true);

            modelBuilder.Entity<CustomerEntity>()
                .HasIndex(c => c.Email)
                .IsUnique(true);

        }

        public DbSet<CustomerEntity> Customers { get; set; }

        public SqlDataContext Context => (this);
        public DbSet<TEntity> EntitySet<TEntity>() where TEntity : BaseEntity
        {
            return Set<TEntity>();
        }
        public void SetModified<TEntity>(TEntity item) where TEntity : BaseEntity
        {
            //this operation also attach item in object state manager
            var entityInDb = EntitySet<TEntity>().Find(item.Id);
            Entry(entityInDb).CurrentValues.SetValues(item);
            Entry(entityInDb).State = EntityState.Modified;
        }
        public int Commit()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return 0;
        }
    }
}
