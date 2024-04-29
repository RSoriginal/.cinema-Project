using Cinema.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Infrastructure.DBContext
{
    public sealed class ApplicationDbContext : IdentityDbContext<CinemaUser, CinemaRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<CinemaUser> CinemaUsers { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Proposition> propositions { get; set; } = null!;
        public DbSet<Seance> seances { get; set; } = null!;
        public DbSet<Ticket> tickets { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
