using _Traversal.Areas.Admin.Models.ViewModels;
using BusinessLayer.Helpers.Concrete.Uploader;
using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Helpers.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _Traversal.Areas.Admin.Controllers
{

    public class DestinationController : BaseController
    {
        private readonly IDestinationService manager;
        private readonly IGuideService _guideManager;
        private readonly IMapper _mapper;
        private readonly IFileOperationsAbstract fo;

        public DestinationController(IMapper mapper, IFileOperationsAbstract _fo, IDestinationService _manager, IGuideService guideManager)
        {
            _mapper = mapper;
            fo = _fo;
            manager = _manager;
            _guideManager = guideManager;
        }


        public IActionResult Index()
        {
            var data = manager.TGetList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var Model = new DestinationAddFormViewModel();
            Model.Guides = _guideManager.TGetList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.GuideId.ToString()
            }).ToList();

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DestinationAddFormViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                vm.Guides = _guideManager.TGetList().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.GuideId.ToString(),
                    Selected = x.GuideId == vm.GuideId
                }).ToList();

                return View(vm);

            }



            var resource = Directory.GetCurrentDirectory();

            var extension = Path.GetExtension(vm.FileCoverImage.FileName);
            var imageName = Guid.NewGuid() + extension;
            var saveLocation = $"{resource}/wwwroot/destination-images/{imageName}";
            var stream = new FileStream(saveLocation, FileMode.Create);
            await vm.FileCoverImage.CopyToAsync(stream);
            vm.CoverImage = "/destination-images/" + imageName;

            var extension2 = Path.GetExtension(vm.FileImage1.FileName);
            var imageName2 = Guid.NewGuid() + extension2;
            var saveLocation2 = $"{resource}/wwwroot/destination-images/{imageName2}";
            var stream2 = new FileStream(saveLocation2, FileMode.Create);
            await vm.FileImage1.CopyToAsync(stream2);
            vm.Image1 = "/destination-images/" + imageName2;


            var extension3 = Path.GetExtension(vm.FileImage2.FileName);
            var imageName3 = Guid.NewGuid() + extension3;
            var saveLocation3 = $"{resource}/wwwroot/destination-images/{imageName3}";
            var stream3 = new FileStream(saveLocation3, FileMode.Create);
            await vm.FileImage2.CopyToAsync(stream3);
            vm.Image2 = "/destination-images/" + imageName3;



            var value = _mapper.Map<Destination>(vm);
            manager.TAdd(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var item = manager.TGetById(id);
            var resource = Directory.GetCurrentDirectory();

            var r1 = fo.DeleteFile($"{resource}/wwwroot/destination-images/{item.CoverImage}");
            var r2 = fo.DeleteFile($"{resource}/wwwroot/destination-images/{item.Image1}");
            var r3 = fo.DeleteFile($"{resource}/wwwroot/destination-images/{item.Image2}");

            manager.TDelete(item);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = manager.TGetById(id);
            var vm = _mapper.Map<DestinationUpdateFormViewModel>(data);

            vm.Guides = _guideManager.TGetList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.GuideId.ToString(),
                Selected = x.GuideId == vm.GuideId
            }).ToList();


            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DestinationUpdateFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Guides = _guideManager.TGetList().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.GuideId.ToString(),
                    Selected = x.GuideId == vm.GuideId
                }).ToList();
                return View(vm);
            }


            var resource = Directory.GetCurrentDirectory();

            if (vm.FileCoverImage != null)
            {
                bool result = fo.DeleteFile($"{resource}/wwwroot/destination-images/{vm.CoverImage}");

                var extension = Path.GetExtension(vm.FileCoverImage.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = $"{resource}/wwwroot/destination-images/{imageName}";
                var stream = new FileStream(saveLocation, FileMode.Create);
                await vm.FileCoverImage.CopyToAsync(stream);
                vm.CoverImage = "/destination-images/" + imageName;
            }
            if (vm.FileImage1 != null)
            {
                bool result2 = fo.DeleteFile($"{resource}/wwwroot/destination-images/{vm.Image1}");
                var extension2 = Path.GetExtension(vm.FileImage1.FileName);
                var imageName2 = Guid.NewGuid() + extension2;
                var saveLocation2 = $"{resource}/wwwroot/destination-images/{imageName2}";
                var stream2 = new FileStream(saveLocation2, FileMode.Create);
                await vm.FileImage1.CopyToAsync(stream2);
                vm.Image1 = "/destination-images/" + imageName2;
            }
            if (vm.FileImage2 != null)
            {
                bool result3 = fo.DeleteFile($"{resource}/wwwroot/destination-images/{vm.Image2}");

                var extension3 = Path.GetExtension(vm.FileImage2.FileName);
                var imageName3 = Guid.NewGuid() + extension3;
                var saveLocation3 = $"{resource}/wwwroot/destination-images/{imageName3}";
                var stream3 = new FileStream(saveLocation3, FileMode.Create);
                await vm.FileImage2.CopyToAsync(stream3);
                vm.Image2 = "/destination-images/" + imageName3;
            }

            var model = _mapper.Map<Destination>(vm);
            manager.TUpdate(model);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var data = manager.TGetById(id);
            return View(data);
        }
    }
}
