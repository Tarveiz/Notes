using Microsoft.EntityFrameworkCore;
using Notes.DAL.Interface;
using Notes.Domain.Entity;

namespace Notes.DAL.Repository
{
    public class NoteRepository : IBaseRepository<Note>
    {
        private readonly AppDbContext _context;
        public NoteRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Note entity)
        {
            await _context.Notes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Note entity)
        {
            _context.Notes.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Note> GetAll()
        {
            return _context.Notes;
        }

        //public async Task<Note> GetById(int id)
        //{
        //    return await _context.Notes.FirstOrDefaultAsync(x => x.Id == id);
        //}

        //public async Task<Note> GetByName(string? name)
        //{
        //    return await _context.Notes.FirstOrDefaultAsync(x => x.Name == name);
        //}

        public async Task<Note> Update(Note entity)
        {
            _context.Notes.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
