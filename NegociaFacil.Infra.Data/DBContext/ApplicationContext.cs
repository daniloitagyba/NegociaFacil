using Microsoft.EntityFrameworkCore;
using NegociaFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Infra.Data.DBContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Credor> Credores { get; set; }
        public DbSet<Debito> Debitos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).GetTypeInfo().Assembly);
        }
    }
}
