using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sp16_p3_g8Web.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(128)]
        [Required]
        public string MovieTitle { get; set; }

        [DisplayName("Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Date of Release")]
        [DataType(DataType.DateTime)]
        public DateTime ReleaseDate { get; set; }

        public bool ratings { get; set; }

        [DisplayName("Plot")]
        public string Plot { get; set; }

        public string ImageUrl { get; set; }

        /*public Movies()
        {
            this.CreatedDate = DateTime.UtcNow;
            this.LastModifiedDate = DateTime.UtcNow;
        }*/
    }

}