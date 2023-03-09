using Notes.DAL.Interface;
using Notes.Domain.Entity;
using Notes.Domain.Response;
using Notes.Services.Interface;
using Notes.Domain.Enum;
using Notes.Domain.Interface;
using Notes.Domain.ViewModel.Note;

namespace Notes.Services.Implementation
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        public NoteService(INoteRepository repository)
        {
            _noteRepository = repository;
        }
        public async Task<IBaseResponse<Note>> GetNote(int id)
        {
            var baseResponse = new BaseResponse<Note>();
            try
            {
                var note = await _noteRepository.GetById(id);
                if (note == null)
                {
                    baseResponse.Description = "Такая запись не найдена";
                    baseResponse.StatusCode = StatusCode.NotesNotFound;
                    return baseResponse;
                }
                baseResponse.Data = note;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Note>()
                {
                    Description = $"{this.GetType()} : {ex.Message}"
                };
            }
        }
        public async Task<IBaseResponse<Note>> GetNote(string name)
        {
            var baseResponse = new BaseResponse<Note>();
            try
            {
                var note = await _noteRepository.GetByName(name);
                if (note == null)
                {
                    baseResponse.Description = "Такая запись не найдена";
                    baseResponse.StatusCode = StatusCode.NotesNotFound;
                    return baseResponse;
                }
                baseResponse.Data = note;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Note>()
                {
                    Description = $"{this.GetType()} : {ex.Message}"
                };
            }
        }
        public async Task<IBaseResponse<IEnumerable<Note>>> GetNotes()
        {
            var baseResponse = new BaseResponse<IEnumerable<Note>>();
            try
            {
                var notes = await _noteRepository.Get();
                if(notes.Count == 0)
                {
                    baseResponse.Description = "Не найдено ни одного элемента";
                    baseResponse.StatusCode = StatusCode.NotesNotFound;
                    return baseResponse;
                }
                baseResponse.Data = notes;
                baseResponse.StatusCode = StatusCode.Success;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Note>>()
                {
                    Description = $"{this.GetType()} : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<bool>> UpdateNote(int id, NoteViewModel model)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var note = await _noteRepository.GetById(id);
                if(note == null)
                {
                    baseResponse.Data = false;
                    baseResponse.Description = "Такой заметки не найдено";
                    baseResponse.StatusCode = StatusCode.NotesNotFound;
                    return baseResponse;
                }

                note.Name = model.Name;
                note.Description = model.Description;
                note.Date = DateTime.Now;

                baseResponse.Data = await _noteRepository.Update(note);
                baseResponse.StatusCode= StatusCode.Success;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"{this.GetType()} : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<bool>> DeleteNote(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var note = await _noteRepository.GetById(id);
                if(note == null)
                {
                    baseResponse.Data = false;
                    baseResponse.Description = "Такой заметки не найдено";
                    baseResponse.StatusCode= StatusCode.NotesNotFound;
                    return baseResponse;
                }
                baseResponse.Data = await _noteRepository.Delete(note);
                baseResponse.StatusCode = StatusCode.Success;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"{this.GetType()} : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<NoteViewModel>> CreateNote(NoteViewModel model)
        {
            var response = new BaseResponse<NoteViewModel>();
            try
            {
                var note = new Note()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Date = DateTime.Now
                };
                await _noteRepository.Create(note);
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<NoteViewModel>()
                {
                    Description = $"{this.GetType()} : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
           
        }
    }
}
