using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.DAL;
using WebApplication5.Models;

namespace WebApplication5.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SpeakersController : Controller
    {
        AppDbContext _appDbContext;
        IWebHostEnvironment _webHostEnvironment;
        public SpeakersController(AppDbContext appDbContext,IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
                
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Speakers.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Speakers speakers) 
        {
            if (!speakers.ImgFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Imgfile", "yanlis daxil edilib");
                return View();
            }
            string path = _webHostEnvironment.WebRootPath + @"\Upload\manage\";
            string filename= Guid.NewGuid() + speakers.ImgFile.FileName;
            using(FileStream filestream=new FileStream(path + filename , FileMode.Create))
            {
                speakers.ImgFile.CopyTo(filestream);
            }
            speakers.ImgUrl= filename; 
            _appDbContext.Speakers.Add(speakers);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");


        }
        public async Task<IActionResult> Delete(int id)
        {
            var _deleteitem=await _appDbContext.Speakers.FirstOrDefaultAsync(x => x.Id == id);
            if(_deleteitem != null)
            {
                _appDbContext.Remove(_deleteitem);
                await _appDbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");   
           
        }
        [HttpGet]
        public IActionResult Update(int id)         
        {
            var _item= _appDbContext.Speakers.FirstOrDefault(x => x.Id == id);
            return View(_item);


        }
        [HttpPost]
        public IActionResult Update(Speakers speakers)
        {
            if (!ModelState.IsValid)
            {
                return View(speakers);
            }
            if(speakers.ImgFile!= null)
            {
                string path = _webHostEnvironment.WebRootPath + @"\Upload\manage\";
                string filename = Guid.NewGuid() + speakers.ImgFile.FileName;
                using (FileStream filestream = new FileStream(path + filename, FileMode.Create))
                {
                    speakers.ImgFile.CopyTo(filestream);
                }

                speakers.ImgUrl=filename;
            }
            _appDbContext.Speakers.Update(speakers);
            _appDbContext.SaveChanges();


            return RedirectToAction("Index");


        }
    }
}
