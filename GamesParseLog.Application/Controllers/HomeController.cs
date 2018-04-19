using GamesParseLog.Application.ViewsModels;
using GamesParseLog.Service.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GamesParseLog.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService _service;

        public HomeController(IService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            var files = _service.GetAllFilesProcessed();
            var filesViewModel = new List<FileViewModel>();
            foreach (var file in files)
            {
                filesViewModel.Add(new FileViewModel(file.FileName, file.DateFile));
            }

            return View(filesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFile()
        {
            var files = Request.Files;

            if (files.Count <= 0) return RedirectToAction("Error");

            var add = _service.AddFileLog(files);

            return add ? RedirectToAction("Index") : RedirectToAction("Error");
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}