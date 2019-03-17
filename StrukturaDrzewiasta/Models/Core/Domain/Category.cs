using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StrukturaDrzewiasta.Core.Domain
{
    public class Category
    {
        public Category()
        {
            this.Subcategories = new HashSet<Category>();
        }

        public int Id { get; set; }
    
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> Subcategories { get; set; }
        
    }
}
