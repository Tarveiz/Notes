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
            return View(response);
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}