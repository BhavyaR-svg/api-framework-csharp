using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFramework.Models.Response
{
    public class PostResponse
    {
        public string title { get; set; } = null!;
        public string body { get; set; } = null!;
        public int userId { get; set; }
        public int id { get; set; }
    }
}
