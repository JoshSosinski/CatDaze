﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatDaze.Models;
using CatDaze.ViewModels;

namespace CatDaze.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            var viewModel = new AdminViewModel();

            viewModel.Images = _dbContext.Images.Where(m => true);

            return View(viewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            if(id != null)
            {
                var findDetails = _dbContext.Images.FirstOrDefault(details => details.Id == id);

                if(findDetails != null)
                {
                    var model = new Image();
                    model = findDetails;

                    return View(model);
                }
            }

            return new HttpStatusCodeResult(400, "Image not found");            
        }
    }
}