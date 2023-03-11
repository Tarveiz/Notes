using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Notes.Domain.Entity;

namespace Notes.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //TODO: отловить ошибку невозможности присоединения к БД с последующей записью/обработкой данных в локальном репозитории в формате JSON
            Database.EnsureCreated();
            
        }

        public DbSet<Note> Notes { get; set; }
        
    }
}
