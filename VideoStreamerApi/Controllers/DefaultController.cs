 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace VideoStreamerApi.Controllers
{
    [RoutePrefix("api/App")]
    public class DefaultController : ApiController
    {
        [HttpGet, Route("GetSelectedResolutionStream")]
        public HttpResponseMessage Get([FromUri] VideoStreamerVM video)
        {
            video.File = "v1";
            video.Extension = ".mp4";
            var tempVideoPath = ConvertVideo.Convert((VideoResolution)video.ResolutionType, video.File, video.Extension);
            HttpResponseMessage response = Request.CreateResponse();
            var videoStream = new VideoStream(tempVideoPath);

            response.Content = new PushStreamContent((stream, httpContent, context) =>
            {
                videoStream.WriteToStream(stream, httpContent, context);
            }, "text/plain");
            response.Content = new PushStreamContent(videoStream.WriteToStream, new MediaTypeHeaderValue("video/mp4"));
            return response;

        }
    }
}
