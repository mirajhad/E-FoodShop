using Mango.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using static Mango.Web.Utility.SD;
using ContentType = Mango.Web.Utility.SD.ContentType;

namespace Mango.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
        public ContentType ContentType { get; set; } = ContentType.Json;
    }
}
