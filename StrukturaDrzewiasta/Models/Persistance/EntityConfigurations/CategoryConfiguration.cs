using StrukturaDrzewiasta.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace StrukturaDrzewiasta.Persistance.EntityConfigurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);

            HasMany(c => c.Subcategories)
                .WithOptional(c => c.ParentCategory)
                .HasForeignKey(c => c.ParentCategoryId);
        }
    }
}