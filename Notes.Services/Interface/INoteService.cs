using Notes.Domain.Entity;
using Notes.Domain.Interface;

namespace Notes.Services.Interface
{
    public interface INoteService
    {
        Task<IBaseResponse<IEnumerable<Note>>> GetNotes();
    }
}
