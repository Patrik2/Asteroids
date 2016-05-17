using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Asteroids.Models
{
    public class Asteroid : IAsteroid
    {
        public int ID { get; set; }
        //[RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage ="Please, insert only a-z A-Z characters")]
        [RegularExpression("^[0-9a-zA-Z ]+$", ErrorMessage = "Please, insert only a-z A-Z characters")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:#.####}")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public double Profit { get; set; }
        [DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:#.####}")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public double Value { get; set; }
        //public ImageAsteroid PhotoOfAsteroid { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string FileDateBase64
        {
            get
            {
                return (FileData != null) ? Convert.ToBase64String(FileData, 0, FileData.Length) : String.Empty;
            }
        }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Asteroid ast = obj as Asteroid;
            if (ast == null)
                return false;
            return (this.FileDateBase64 == ast.FileDateBase64 && this.FileName == ast.FileName && this.ID == ast.ID && this.Name == ast.Name && this.Profit == ast.Profit && this.Value == ast.Value);
        }

    }
}