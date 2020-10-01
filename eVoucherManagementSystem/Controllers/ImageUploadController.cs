using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eVoucherManagementSystem.Messages.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eVoucherManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        
        public ImageUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public class FileUploadModel
        {
            public IFormFile files { get; set; }
        }

        [HttpPost]
        public async Task<ImageResponse> SaveImage([FromForm] FileUploadModel uploadObj)
        {
            try
            {
                if (uploadObj.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.ContentRootPath + "\\wwwroot\\images\\"))
                    {
                        Directory.CreateDirectory(_environment.ContentRootPath + "\\wwwroot\\images\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.ContentRootPath + "\\wwwroot\\images\\" + uploadObj.files.FileName))
                    {
                        uploadObj.files.CopyTo(fileStream);
                        fileStream.Flush();
                        ImageResponse imageResponse = new ImageResponse
                        {
                            ImageURL = "/images/" + uploadObj.files.FileName

                        };
                    return imageResponse;
                    }
                }
                else{
                    List<string> Msg = new List<string>();
                    Msg.Add("Unsuccessfully Image Uploaded!");
                    ImageResponse imageResponse = new ImageResponse
                    {
                        Messages = Msg

                    };
                    return imageResponse;
                }
            }catch(Exception ex)
            {
                List<string> Msg = new List<string>();
                Msg.Add(ex.Message.ToString());
                ImageResponse imageResponse = new ImageResponse
                {
                    Messages = Msg

                };
                return imageResponse;
            }
            
        }
    }
}
