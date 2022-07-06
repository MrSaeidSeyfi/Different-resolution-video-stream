using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace VideoStreamerApi
{
    public class VideoStream
    {  
        private readonly string _address; 
        public VideoStream(string address)
        {
            //_filename = HttpContext.Current.Server.MapPath(filename); 
            _address = address;
        }

        public async void WriteToStream(Stream outputStream, HttpContent content, TransportContext context)
        { 
            try
            {
                //var buffer = new byte[1000];
                var buffer = new byte[65536];

                using (var video = File.Open(_address, FileMode.Open, FileAccess.Read))
                {
                    var length = (int)video.Length;
                    var bytesRead = 1;

                    while (length > 0 && bytesRead > 0)
                    {
                        bytesRead = video.Read(buffer, 0, Math.Min(length, buffer.Length));
                        await outputStream.WriteAsync(buffer, 0, bytesRead);
                        length -= bytesRead;
                    }
                }
            }
            catch (HttpException ex)
            {
                return;
            }
            finally
            {
                outputStream.Close();
            }
        }

    }
}