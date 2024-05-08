using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.OrderAPI.Models.Dto
{
    public class StripeRequestDto
    {
        public string StripeSessionUrl { get; set; }
        public string StripeSessionId { get; set; }
        public string ApproveUrl { get; set; }
        public string CancelUrl { get; set; }
        public OrderHeaderDto OrderHeader { get; set; }
    }
}
