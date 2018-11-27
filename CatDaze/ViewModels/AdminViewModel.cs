using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CatDaze.Models;

namespace CatDaze.ViewModels
{
    public class AdminViewModel
    {
        public Image Image { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}