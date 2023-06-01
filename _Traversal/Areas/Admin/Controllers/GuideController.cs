using BusinessLayer.Abstract;
using BusinessLayer.Helpers.Abstracts;
using BusinessLayer.ValidationRule;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Admin.Controllers
{
    public class GuideController : BaseController
    {
        IGuideService _guideService;
        IFileOperationsAbstract _fileOpeartions;

     
        public GuideController(IGuideService guideService, IFileOperationsAbstract fileOpeartions) 
        {
            _guideService = guideService;
            _fileOpeartions = fileOpeartions;
        }

        public IActionResult Index()
        {
            var list = _guideService.TGetList();

            return View(list);
        }
       
        public IActionResult Add()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Add(Guide g)
        {

            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(g.FormImage.FileName);
            var imageName = Guid.NewGuid() + extension;
            var saveLocation = $"{resource}/wwwroot/guide-images/{imageName}";

            using (var stream = new FileStream(saveLocation, FileMode.Create))
            {
                await g.FormImage.CopyToAsync(stream);
                g.Image = "guide-images/" + imageName;
            }
          

            _guideService.TAdd(g);

            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            _guideService.ChangeStatus(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = _guideService.TGetById(id);
            return View(data);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(Guide g)
        {
            if(g.FormImage!=null)
            {
                var resource = Directory.GetCurrentDirectory();

                _fileOpeartions.DeleteFile($"{resource}/wwwroot/"+g.Image);   
                var extension = Path.GetExtension(g.FormImage.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = $"{resource}/wwwroot/guide-images/{imageName}";
                var stream = new FileStream(saveLocation, FileMode.Create);
                await g.FormImage.CopyToAsync(stream);
                g.Image = "guide-images/"+imageName;
            }
            _guideService.TUpdate(g);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var guide = _guideService.TGetById(id);
            if(guide!=null)
            {
                var path = Directory.GetCurrentDirectory() + "/wwwroot/" + guide.Image;

                _guideService.TDelete(guide);
                _fileOpeartions.DeleteFile(path);
            }
          

            return RedirectToAction("Index");
        }

        

    }
}
