using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CatDaze.Models
{
    public class Image
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string ImageName { get; set; }
        [MaxLength(255)]
        public string ImageCaption { get; set; }
        [MaxLength(500)]
        public string ImageLocation { get; set; }
        [MaxLength(64)]
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}