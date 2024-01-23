namespace _02.ChatApp.Models.Messages
{
    public class ChatViewModel
    {
        public MessageViewModel CurrentMessage { get; set; } = null!;
        public List<MessageViewModel> Messages { get; set; } = null!;
    }
}
