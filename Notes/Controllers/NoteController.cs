using Microsoft.AspNetCore.Mvc;
using Notes.Models;
using Notes.Services.Interface;
using System.Diagnostics;

namespace Notes.Controllers
{
    public class NoteController : Controller
    {
        private readonly ILogger<NoteController> _logger;
        private readonly INoteService _noteService;

        public NoteController(ILogger<NoteController> logger, INoteService noteService)
        {
            _noteService = noteService;
            _logger = logger;
        }
        public async Task<IActionResult> GetNotes()
        {
            var response = await _noteService.GetNotes();
            
            return View(response.Data);
            //Notes.Domain.Response.BaseResponse<System.Collections.Generic.IEnumerable<Notes.Domain.Entity.Note>>}
        }
        public IActionResult Index()
        {
            return View();
        }
        // Domain.Interface.IBaseRepository<IEnumerable<Domain.Entity.Note>>
        //	Notes.dll!Notes.Controllers.NoteController.GetNotes() Строка 21	C#


    }
}