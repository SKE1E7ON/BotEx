namespace BotEx_Api.ModelDTO
{
    public class MenuRequest
    {
        public int MenuId { get; set; }
        public int IdResto { get; set; }
        public string Naming { get; set; } = null!;
        public string Cost { get; set; } = null!;
        public string Info { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Sale { get; set; } = null!;
    }
}
