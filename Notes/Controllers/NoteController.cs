using Microsoft.AspNetCore.Mvc;
using Notes.Domain.ViewModel.Note;
using Notes.Models;
using Notes.Services.Interface;
using System.Diagnostics;

namespace Notes.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }
        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            var response = await _noteService.GetNotes();
            if (response.StatusCode == Domain.Enum.StatusCode.Success)
            {
                return View(response.Data.ToList());
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<IActionResult> GetNoteById(int id)
        {
            var response = await _noteService.GetNote(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Success)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<IActionResult> GetNoteByName(string name)
        {
            var response = await _noteService.GetNote(name);
            if (response.StatusCode == Domain.Enum.StatusCode.Success)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var response = await _noteService.DeleteNote(id);
            if(response.StatusCode == Domain.Enum.StatusCode.Success)
            {
                return RedirectToAction("GetNotes");
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateNote(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var response = await _noteService.GetNote(id);
            if(response.StatusCode == Domain.Enum.StatusCode.Success)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNote(NoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Id == 0)
                {
                    await _noteService.CreateNote(model);
                }
                else
                {
                    await _noteService.UpdateNote(model.Id, model);
                }
            }
            return RedirectToAction("GetNotes");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}