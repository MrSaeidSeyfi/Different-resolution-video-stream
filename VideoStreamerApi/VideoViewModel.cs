using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoStreamerApi
{
    public partial class VideoStreamerVM
    {
        public int ResolutionType { get; set; }
        public string File { get; set; }
        public string Extension { get; set; } 
    }
}