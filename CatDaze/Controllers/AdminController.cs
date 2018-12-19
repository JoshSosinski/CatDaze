using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using CatDaze.ViewModels;
using CatDaze.Models;
using System.Web.Security;

namespace CatDaze.Controllers
{
    [Authorize(Roles = "CanManageSite")]
    public class AdminController : Controller
    {   
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
                findImage.LastUpdatedBy = User.Identity.Name;
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
        public ActionResult Create(Image image, HttpPostedFileBase file)
        {
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var picture = image.ImageName + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                var path = Path.Combine(Server.MapPath(@"~\Content\Pictures"), picture);

                file.SaveAs(path);

                //Only Temporary
                image.ImagePath = @"~\Content\Pictures\" + picture;
                image.LastUpdatedBy = User.Identity.Name;
                image.LastUpdatedDate = DateTime.UtcNow;

                _dbContext.Images.Add(image);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View(image);
            }


            //if (!ModelState.IsValid)
            //{
            //    var modelStateErrors = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors);

            //    return RedirectToAction("Create", image);
            //}
            //else
            //{
            //    _dbContext.Images.Add(image);
            //    _dbContext.SaveChanges();

            //    return RedirectToAction("Index", "Admin");
            //}

        }
    }
}