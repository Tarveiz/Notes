using Microsoft.AspNetCore.Mvc;
using Notes.Domain.Interface;
using Notes.Domain.Response;
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
        public IActionResult GetNotes()
        {
            var response = _noteService.GetNotes();
            if (response.StatusCode == Domain.Enum.StatusCode.Success)
            {
                return View(response.Data);
            }
            return View("Error: ", $"{response.Description}");
        }
        [HttpGet]
        public async Task<IActionResult> GetNoteById(int id)
        {
            var response = await _noteService.GetNote(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Success)
            {
                return View(response.Data);
            }
            return View("Error: ", $"{response.Description}");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var response = await _noteService.DeleteNote(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Success)
            {
                return RedirectToAction("GetNotes");
            }
            return View("Error: ", $"{response.Description}");
        }
        [HttpGet]
        public async Task<IActionResult> CreateNote(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var response = await _noteService.GetNote(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Success)
            {
                NoteViewModel viewResponse = new NoteViewModel() 
                {
                    Id = response.Data.Id,
                    Name = response.Data.Name,
                    Description = response.Data.Description,
                    Date = response.Data.Date,
                };
                return View(viewResponse);
            }
            return View("Error: ", $"{response.Description}");
        }
        [HttpPost]
        public async Task<IActionResult> CreateNote(NoteViewModel viewModel)
        {
            //ModelState.Remove("Id");
            //ModelState.Remove("DateCreate");

            if (viewModel.Id == 0)
            {
                //byte[]? imageData = null;

                //using (var binaryReader = new BinaryReader(viewModel.Data.FormImage.OpenReadStream()))
                //{
                //    imageData = binaryReader.ReadBytes((int)viewModel.Data.Image.Length);
                //}
                //, imageData
                await _noteService.CreateNote(viewModel);



            }
            else
            {
                await _noteService.UpdateNote(viewModel.Id, viewModel);
            }
            return RedirectToAction("GetNotes");
        }
        public IActionResult Index()
        {
            return RedirectToAction("GetNotes");
        }
    }
}