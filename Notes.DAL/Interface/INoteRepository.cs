using Notes.Domain.Entity;

namespace Notes.DAL.Interface
{
    public interface INoteRepository : IBaseRepository<Note>
    {
        Task<Note> GetByName(string name);
        Task<Note> GetById(int id);
    }
}
