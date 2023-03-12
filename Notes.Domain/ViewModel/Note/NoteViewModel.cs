using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Notes.Domain.ViewModel.Note
{
    public class NoteViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        //public IFormFile FormImage { get; set; }
        //public byte[]? Image { get; set; }
    }
}
