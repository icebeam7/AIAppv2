using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIApp.Models
{
    public class ImageRequest
    {
        public string prompt { get; set; }
        public string size { get; set; }
        public int n { get; set; }
        public string quality { get; set; }
        public string style { get; set; }
    }

}
