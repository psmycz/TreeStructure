using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace StrukturaDrzewiasta.Core.Domain
{
    [DataContract(IsReference = true)]
    public class Category
    {
        public Category()
        {
            this.Subcategories = new HashSet<Category>();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> Subcategories { get; set; }
        
    }
}
