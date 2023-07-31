using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        [HttpPost(Name = "LoadFiles")]
        public async Task<byte[]> Post()
        {
            try
            {

                var files = Request.Form.Files;
                foreach (var file in files)
                {
                    if (file.Length == 0) continue;

                    var filePath = Path.Combine("C:\\Users\\Flog\\Documents\\Hscool\\SongPlayer\\Server\\LocalStorage", file.FileName);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream)
;
                        stream.Close();
                    }
                }


                var reFile = Path.Combine("C:\\Users\\Flog\\Documents\\Hscool\\SongPlayer\\Server\\LocalStorage", files[0].FileName);
                return System.IO.File.ReadAllBytes(reFile);
            }
            catch (Exception ex)
            {
                return new byte[0];
            }
        }
        //[HttpGet]
        //public async Task<byte[]> GetSongById(int id)
        //{
        //    try
        //    {
        //        // var song = m_SongService.GetById(id)
        //        ;


        //        // var reFile = Path.Combine("C:\\Users\\OSE\\Documents\\HS", song.FileName);
        //        // return System.IO.File.ReadAllBytes(reFile);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new byte[0];
        //    }
        //}
    }
}

