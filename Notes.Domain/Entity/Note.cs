namespace Notes.Domain.Entity
{
    public class Note
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        //public byte[]? Image { get; set; }

    }
}
