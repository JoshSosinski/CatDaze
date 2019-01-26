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
    [Authorize(Roles = RoleName.CanManageSite)]
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
                var viewModel = new AdminViewModel()
                {

                    Image = findImage
                    //ImageName = findImage.ImageName,
                    //ImageCaption = findImage.ImageCaption
                };

                return View(viewModel);
            }

            return new HttpStatusCodeResult(404, "Bad Request");
        }

        [HttpPost]
        public ActionResult Edit(AdminViewModel adminViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AdminViewModel
                {
                    Image = adminViewModel.Image
                };

                return View("Edit", viewModel);
            }

            var findImage = _dbContext.Images.FirstOrDefault(x => x.Id == adminViewModel.Image.Id);

            if (findImage != null)
            {

                findImage.ImageCaption = adminViewModel.Image.ImageCaption;
                findImage.ImageName = adminViewModel.Image.ImageName;
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

            if (!ModelState.IsValid || file == null)
            {
                var model = new Image
                {
                    Id = image.Id,
                    ImageCaption = image.ImageCaption,
                    ImageName = image.ImageName,
                };

                return View("Create", image);
            }

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var picture = image.ImageName + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                var path = Path.Combine(Server.MapPath(@"~\Content\Pictures"), picture);

                file.SaveAs(path);
    
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
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(500, "Bad Request");
            }

            var findPost = _dbContext.Images.FirstOrDefault(p => p.Id == id);

            if (findPost != null)
            {
                var viewModel = new Image()
                {
                    Id = findPost.Id,
                    ImageName = findPost.ImageName,
                    ImageCaption = findPost.ImageCaption
                };

                return View(viewModel);
            }

            return new HttpStatusCodeResult(500, "Error with receiving the post from database. Please contact the site administrator");
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(500, "Bad Request");
            }

            var findPost = _dbContext.Images.FirstOrDefault(p => p.Id == id);

            if (findPost != null)
            {
                _dbContext.Images.Remove(findPost);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", "Admin");
            }

            return new HttpStatusCodeResult(500, "Error with deleting post from database. Please contact the site administrator");
        }
    }
}