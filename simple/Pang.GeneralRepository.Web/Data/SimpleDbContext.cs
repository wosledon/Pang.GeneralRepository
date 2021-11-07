using Microsoft.EntityFrameworkCore;
using Pang.GeneralRepository.Core.Core;
using Pang.GeneralRepository.Core.Entity;
using Pang.GeneralRepository.Core.Extensions;

namespace Pang.GeneralRepository.Web.Data
{
    public class SimpleDbContext : GRCDbContext
    {
        public SimpleDbContext(DbContextOptions<SimpleDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityTypes<EntityBase>();
            base.OnModelCreating(modelBuilder);
        }
    }
}