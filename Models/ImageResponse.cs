using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIApp.Models
{
    public class ImageResponse
    {
        public Data[] data { get; set; }
    }

    public class Data
    {
        public string url { get; set; }
        public string revised_prompt { get; set; }
    }

}
