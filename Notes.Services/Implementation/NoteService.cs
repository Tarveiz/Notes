using Notes.DAL.Interface;
using Notes.Domain.Entity;
using Notes.Domain.Response;
using Notes.Services.Interface;
using Notes.Domain.Enum;
using Notes.Domain.Interface;
using Notes.Domain.ViewModel.Note;
using Microsoft.EntityFrameworkCore;

namespace Notes.Services.Implementation
{
    public class NoteService : INoteService
    {
        private readonly IBaseRepository<Note> _noteRepository;
        public NoteService(IBaseRepository<Note> repository)
        {
            _noteRepository = repository;
        }
        public async Task<IBaseResponse<NoteViewModel>> GetNote(int id)
        {
            try
            {
                var note = await _noteRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (note == null)
                {
                    return new BaseResponse<NoteViewModel>()
                    {
                        Description = "Запись не найдена",
                        StatusCode = StatusCode.NotesNotFound
                    };
                }
                var data = new NoteViewModel()
                {
                    Name = note.Name,
                    Description = note.Description,
                    Date = note.Date,
                    //Image = note.Image
                };
                return new BaseResponse<NoteViewModel> {
                    StatusCode = StatusCode.Success,
                    Data = data
                };
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
        public async Task<IBaseResponse<NoteViewModel>> GetNote(string name)
        {
            try
            {
                var note = await _noteRepository.GetAll().FirstOrDefaultAsync(x => x.Name == name);
                if (note == null)
                {
                    return new BaseResponse<NoteViewModel>()
                    {
                        Description = "Запись не найдена",
                        StatusCode = StatusCode.NotesNotFound
                    };
                }
                var data = new NoteViewModel()
                {
                    Name = note.Name,
                    Description = note.Description,
                    Date = note.Date,
                    //Image = note.Image

                };
                return new BaseResponse<NoteViewModel>
                {
                    StatusCode = StatusCode.Success,
                    Data = data
                };
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
        public  IBaseResponse<List<Note>> GetNotes()
        {
            try
            {
                var notes =  _noteRepository.GetAll().ToList();
                if (notes == null)
                {
                    return new BaseResponse<List<Note>>()
                    {
                        Description = "Не найдено ни одной записи",
                        StatusCode = StatusCode.Success
                    };
                }
                if(notes.Count == 0)
                {
                    return new BaseResponse<List<Note>>()
                    {
                        StatusCode = StatusCode.Success,
                        Description = "Не найдено ни одной записи",
                        Data = new List<Note>()
                        {
                            new Note()
                            {
                                Name = "Фантомная заметка",
                                Description = "Заметка с текстом (по заданию)",
                                Date = DateTime.Now
                            }
                        }
                    };

                }

                return new BaseResponse<List<Note>>()
                {
                    Data = notes,
                    StatusCode = StatusCode.Success
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Note>>()
                {
                    Description = $"{this.GetType()} : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<Note>> UpdateNote(int id, NoteViewModel model)
        {
            try
            {
                var note = await _noteRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (note == null)
                {
                    return new BaseResponse<Note>()
                    {
                        Description = "Запись, которую нужно обновить, не была найдена",
                        StatusCode = StatusCode.Success
                    };
                }
                note.Name = model.Name;
                note.Description = model.Description;
                note.Date = DateTime.Now;
                await _noteRepository.Update(note);


                return new BaseResponse<Note>
                {
                    Data = note,
                    StatusCode=StatusCode.Success
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Note>()
                {
                    Description = $"{this.GetType()} : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<bool>> DeleteNote(int id)
        {
            try
            {
                var note = await _noteRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (note == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "",
                        StatusCode = StatusCode.Success,
                        Data = false
                    };
                }

                await _noteRepository.Delete(note);
                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.Success
                };
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
        public async Task<IBaseResponse<Note>> CreateNote(NoteViewModel model)
        {
            //, byte[] images
            try
            {
                var note = new Note()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Date = DateTime.Now,
                    //Image = model.Image
                };
                await _noteRepository.Create(note);
                return new BaseResponse<Note>()
                {
                    StatusCode = StatusCode.Success,
                    Data = note
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Note>()
                {
                    Description = $"{this.GetType()} : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
           
        }
    }
}
