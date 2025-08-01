using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarfati.Core.Handlers
{
    public class GetChatHistoryResponse
    {
        public List<ChatMessageDto> Messages { get; set; } = new();
    }

    public class ChatMessageDto
    {
        public long Id { get; set; }
        public Guid SenderId { get; set; }
        public string SenderName { get; set; }
        public bool IsParent { get; set; }     
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsMine { get; set; }
    }
}
