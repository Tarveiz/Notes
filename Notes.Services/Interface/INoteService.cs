using Notes.Domain.Entity;
using Notes.Domain.Interface;
using Notes.Domain.ViewModel.Note;

namespace Notes.Services.Interface
{
    public interface INoteService
    {
        IBaseResponse<List<Note>> GetNotes();
        Task<IBaseResponse<NoteViewModel>> GetNote(int id);
        //Task<IBaseResponse<Note>> GetNote(int id);
        Task<IBaseResponse<bool>> DeleteNote(int id);
        Task<IBaseResponse<Note>> UpdateNote(int id, NoteViewModel model);
        Task<IBaseResponse<Note>> CreateNote(NoteViewModel model, byte[] images);
    }
}
