using System.ComponentModel.DataAnnotations;    // [Required], [StringLength]
using System.ComponentModel.DataAnnotations.Schema; // [Column]

namespace Packt.Shared
{
    public class Product
    {
        public int ProductId { get; set; }  // primary key

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; } = null!;

        /// <summary>
        /// We can reename a column by defining a property with 
        /// a different name, like Cost, and then decorating the
        /// property with the [olumn] attribute and specifying its
        /// column name, like UnitPrice.
        /// </summary>
        [Column("UnitPrice", TypeName = "money")]
        public decimal? Cost { get; set; }  // property name != column name

        [Column("UnitsInStock")]
        public short? Stock { get; set; }

        public bool Discontinued { get; set; }

        // these two properties define the foreign key relationship
        // to the Categories table
        public int CategoryId { get; set; }

        /// <summary>
        /// It's marked as virtual to allows EF Core to inherit
        /// and override the properties to provide extra features,
        /// such as lazy loading.
        /// </summary>
        public virtual Category Category { get; set; } = null!;
    }
}
