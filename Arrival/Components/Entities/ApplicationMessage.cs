namespace Entities
{
    public class ApplicationMessage : BaseEntity
    {
        public int Id { get; set; }
        public string MessageText { get; set; }

        public ApplicationMessage(int id, string messageText)
        {
            Id = id;
            MessageText = messageText;
        }

        public ApplicationMessage()
        {
        }
    }
}
