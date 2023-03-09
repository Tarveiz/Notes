using Notes.Domain.Entity;
using Notes.Domain.Interface;
using Notes.Domain.ViewModel.Note;

namespace Notes.Services.Interface
{
    public interface INoteService
    {
        Task<IBaseResponse<IEnumerable<Note>>> GetNotes();
        Task<IBaseResponse<Note>> GetNote(string name);
        Task<IBaseResponse<Note>> GetNote(int id);
        Task<IBaseResponse<bool>> DeleteNote(int id);
        Task<IBaseResponse<bool>> UpdateNote(int id, NoteViewModel model);
        Task<IBaseResponse<NoteViewModel>> CreateNote(NoteViewModel model);
    }
}
