using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatDaze.ViewModels;
using CatDaze.Models;

namespace CatDaze.Controllers
{
    public class AdminController : Controller
    {
        //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            var images = _dbContext.Images.Where(x => true);

            var viewModel = new AdminViewModel
            {
                Images = images
            };

            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404, "Bad Request");
            }

            var findImage = _dbContext.Images.FirstOrDefault(x => x.Id == id);

            if (findImage != null)
            {
                var model = new Image()
                {
                    ImageName = findImage.ImageName,
                    ImageCaption = findImage.ImageCaption
                };

                return View(model);
            }

            return new HttpStatusCodeResult(404, "Bad Request");
        }

        public ActionResult Update(Image imageModel)
        {
            //if(!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("error", "There is an error with this form");

            //    return View(imageModel);
            //}

                var findImage = _dbContext.Images.FirstOrDefault(x => x.Id == imageModel.Id);

                if (findImage != null)
                {

                    findImage.ImageCaption = imageModel.ImageCaption;
                    findImage.ImageName = imageModel.ImageName;
                    findImage.LastUpdatedBy = "Josh";
                    findImage.LastUpdatedDate = DateTime.UtcNow;

                    _dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }

            return new HttpStatusCodeResult(404, "Bad Request");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateImage(Image image, HttpPostedFileBase file)
        {
            //Only Temporary
            image.LastUpdatedBy = "Josh";
            image.LastUpdatedDate = DateTime.UtcNow;

            if(!ModelState.IsValid)
            {
                return View(image);
            }



            return new HttpStatusCodeResult(404, "Bad Request");
        }
    }
}