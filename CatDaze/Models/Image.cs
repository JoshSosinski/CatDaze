using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CatDaze.Models
{
    public class Image
    {
        public int Id { get; set; }

        [DisplayName("Name of Image"), Required, MaxLength(100)]
        public string ImageName { get; set; }

        [DisplayName("Caption for Image"), Required, MaxLength(255)]
        public string ImageCaption { get; set; }

        [MaxLength(500)]   
        public string ImagePath { get; set; }

        [MaxLength(64)]
        public string LastUpdatedBy { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}