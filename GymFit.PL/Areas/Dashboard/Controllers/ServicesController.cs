using AutoMapper;
using GymFit.DAL.Data;
using GymFit.DAL.Data.Models;
using GymFit.PL.Areas.Dashboard.ViewModels;
using GymFit.PL.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GymFit.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ServicesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(mapper.Map<IEnumerable<ServicesVm>>(context.services.ToList()));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceFormVM vm) {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            vm.ImageName = FileSettings.UploadFile(vm.Image, "images"); 
            var service = mapper.Map<Service>(vm);
            context.Add(service);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var service = context.services.Find(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(mapper.Map<ServiceFormVM>(service));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ServiceFormVM vm)
        {
            var service = context.services.Find(vm.Id);
            if (service == null)
            {
                return NotFound();
            }
            if(vm.Image == null)
            {
                vm.ImageName = service.ImageName;
                ModelState.Remove("Image");
            }
            else
            {
                FileSettings.DeleteFile(service.ImageName, "images");
                vm.ImageName = FileSettings.UploadFile(vm.Image, "images");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            mapper.Map(vm,service);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var service = context.services.Find(id);
            if(service == null)
            {
                return NotFound();
            }
            return View(mapper.Map<ServiceDetailsVM>(service));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var service = context.services.Find(id);
            if(service == null)
            {
                return NotFound();
            }
            return View(mapper.Map<ServicesVm>(service));
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var service = context.services.Find(id);
            if (service == null)
            {
                return RedirectToAction(nameof(Index));
            }
            FileSettings.DeleteFile(service.ImageName,"images");
            context.services.Remove(service);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
