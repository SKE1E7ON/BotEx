namespace BotEx_Api.Model
{
    public partial class BotExContext : ProjectContext
    {
        public static ProjectContext Context { get; set; } = new ProjectContext();
    }
}
