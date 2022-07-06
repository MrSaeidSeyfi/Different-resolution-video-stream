using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace VideoStreamerApi
{
    public class ConvertVideo
    {
        public static string Convert(VideoResolution resolution, string file, string extension)
        {
            string input = string.Empty;
            string output = string.Empty;
            try
            {
                string ffmpegFilePath = "~/video/ffmpeg/ffmpeg.exe"; // path of ffmpeg.exe - please replace it for your options. 
                input = HttpContext.Current.Server.MapPath("~/video/" + file + extension);
                output = HttpContext.Current.Server.MapPath("~/video/temp/" + file + resolution + $"_{Guid.NewGuid()}" + extension);

                var processInfo = new ProcessStartInfo(HttpContext.Current.Server.MapPath(ffmpegFilePath),
                    " -i \"" + input + "\" -s \"" + resolution.GetDisplayName() + "\" \"" + output + "\"")
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                Process process = System.Diagnostics.Process.Start(processInfo);
                var result = process.StandardError.ReadToEnd();
                process.WaitForExit();
                process.Close();

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return output;

        }
    }



}