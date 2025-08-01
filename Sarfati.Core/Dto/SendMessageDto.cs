using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarfati.Core.Dto
{
    public class SendMessageDto
    {
        public long TaskChildId { get; set; }
        public string Message { get; set; }
    }
}
