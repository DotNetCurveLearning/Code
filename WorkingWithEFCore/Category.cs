using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.Shared
{
    public class Category
    {
        // these properties map to columns in the database
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string? Description { get; set; }

        /// <summary>
        // Defines a navigation property for related rows.
        // It's marked as virtual to allows EF Core to inherit
        // and override the properties to provide extra features,
        // such as// defines a navigation property for related rows.
        // It's marked as virtual to allows EF Core to inherit
        // and override the properties to provide extra features,
        // such as lazy loading.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        /// <summary>
        /// To enable developers to add products to a Category
        /// we must initialize the navigation property to an
        /// empty collection.
        /// </summary>
        public Category()
        {
            Products = new HashSet<Product>();
        }
    }
}
