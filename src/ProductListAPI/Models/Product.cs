
namespace ProductListAPI.Models
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product 
    {
        /// <summary>
        /// The ID of the product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product name.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Current Inventory
        /// </summary>
        public int CurrentInventory{ get; set; }

        /// <summary>
        /// The Product's unit. 
        /// </summary>
        public string Unit { get; set; }

    }
}