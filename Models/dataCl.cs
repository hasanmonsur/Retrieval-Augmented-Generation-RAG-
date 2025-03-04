namespace RagApi.Models
{
    public class DataCl
    {
        public string query { get; set; }
    }

    public class ChatGptResponse
    {
        public Choice[] Choices { get; set; }
    }

    public class Choice
    {
        public Message Message { get; set; }
    }

    public class Message
    {
        public string Content { get; set; }
    }
}
