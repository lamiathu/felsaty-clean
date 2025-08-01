using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarfati.Core.Handlers
{
    public class GetChatHistoryRequest : IRequest<GetChatHistoryResponse>
    {
        public long TaskChildId { get; set; }
        public string UserId { get; set; }
    }
}
