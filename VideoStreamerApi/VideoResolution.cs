using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoStreamerApi
{
    public enum VideoResolution
    {
        [Display(Name = "256x144")] q148p = 1,
        [Display(Name = "426x240")] q240p = 2,
        [Display(Name = "480x360")] q360p = 3,
        [Display(Name ="852x480")] q480p = 4,
        [Display(Name = "1280x720")] q720p = 5

    }
}