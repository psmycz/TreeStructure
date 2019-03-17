using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace StrukturaDrzewiasta.ViewModels
{
    public class CategoryVM
    {
        [Required]
        [StringLength(30, MinimumLength = 3,ErrorMessage = "Name must contain from 3 to 30 characters")]
        public string Name { get; set; }

        public int ParentId { get; set; }

        public int CurrentCategoryId { get; set; }

        public SelectList ParentArtibutes;

    }
}