using GetNowServer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GetNowServer.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UploadController : Controller
    {
        private MyDbContext _context;

        public UploadController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        public ActionResult CompanyLogo()
        {
            var myFile = Request.Form.Files[0];
            var objectId = ObjectIdFromFile(myFile);
            if (objectId > 0)
            {
                string fileName;
                int newImageInfoId = Upload(myFile, out fileName);
                if (newImageInfoId > 0)
                {
                    var company = _context.Companies.FirstOrDefault(x => x.Id == objectId);
                    company.Logo = newImageInfoId;
                    _context.SaveChanges();
                    return Ok(fileName);
                }
            }
            Response.StatusCode = 400;
            return new EmptyResult();
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        public ActionResult ProductImage()
        {
            var myFile = Request.Form.Files[0];
            var objectId = ObjectIdFromFile(myFile);
            if (objectId > 0)
            {
                string fileName;
                int newImageInfoId = Upload(myFile, out fileName);
                if (newImageInfoId > 0)
                {
                    var company = _context.Products.FirstOrDefault(x => x.Id == objectId);
                    company.Image = newImageInfoId;
                    _context.SaveChanges();
                    return Ok(fileName);
                }
            }
            Response.StatusCode = 400;
            return new EmptyResult();
        }

        private int ObjectIdFromFile(IFormFile myFile)
        {
            var fileName = myFile.Name.Replace("myFile", "");
            int ret;
            if (int.TryParse(fileName, out ret))
                return ret;

            return -1;
        }

        public int Upload(IFormFile myFile, out string fileName)
        {
            // Learn more on the functionality of the dxFileUploader widget at:
            // http://js.devexpress.com/Documentation/Guide/UI_Widgets/UI_Widgets_-_Deep_Dive/dxFileUploader/
            try
            {
                var uuid = _context.StringObjects.FromSqlRaw("select uuid() as id").FirstOrDefault().Id;
                fileName = uuid + Path.GetExtension(myFile.FileName);

                var path = Path.Combine(Common.HostingEnvironment.WebRootPath, "data_images");
                // Uncomment to save the file
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                path = Path.Combine(path, fileName);
                using (var fileStream = System.IO.File.Create(path))
                {
                    myFile.CopyTo(fileStream);
                }

                int imageInfoId;
                try
                {
                    imageInfoId = _context.ImageInfos.Max(x => x.Id) + 1;
                }
                catch
                {
                    imageInfoId = 1;
                }
                var newImageInfo = new ImageInfo() { Id = imageInfoId, FileName = fileName };
                _context.ImageInfos.Add(newImageInfo);
                _context.SaveChanges();
                return imageInfoId;
            }
            catch
            {
                fileName = null;
            }
            return -1;
        }


        [HttpPost]
        public string Delete(string dataId)
        {
            var path = Path.Combine(Common.HostingEnvironment.WebRootPath, "images/ItemType");
            path = Path.Combine(path, dataId + ".png");
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            return "OK";
        }
    }
}
