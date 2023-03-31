namespace MojeAplikace.Models
{
    public class sachista
    {
        public int Id { get; set; }
        public int Elo { get; set; }
        public string? Name { get; set; }
        public bool PripravenHrat { get; set; }
        public DateTime ZacatekHrani { get; set; }
    }
}
