using contact_book_api.Models;
using Microsoft.EntityFrameworkCore;

namespace contact_book_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; } = null!;
        public DbSet<AgendaModel> Agendas { get; set; } = null!;
        public DbSet<ContactModel> Contacts { get; set; } = null!;
    }
}