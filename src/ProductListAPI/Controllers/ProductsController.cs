using ProductListAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Net.Http;
using System;
using System.Collections;
using System.Diagnostics;
using Microsoft.SqlServer.Server;

namespace ProductListAPI.Controllers
{
    /// <summary>
    /// Products Controller
    /// </summary>
    public class ProductsController : ApiController
    {
        private const string FILENAME = "products.json";
        private GenericStorage _storage;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductsController()
        {
            _storage = new GenericStorage();
        }

        private IEnumerable<Product> GetInventory()
        {
            var inventory = _storage.Get(FILENAME);

            if (inventory == null)
            {
                //Populate with some dummy data to begin with
                inventory = GetDefaultProducts();
                _storage.Save(
                    inventory, 
                    FILENAME);
            }

            return inventory;
        }

        private IEnumerable<Product> GetDefaultProducts()
        {
            var numProductsToInitialize = 10;
            Random rand = new Random();
            Product[] products = new Product[numProductsToInitialize];
            for (var i = 0; i < numProductsToInitialize; i++)
            {
                products[i] = new Product
                {
                    Id = i,
                    Name = String.Format("Widget {0}", i.ToString()),
                    CurrentInventory = rand.Next(0, 300),
                    Unit = "Units"
                };
            }

            return products;

        }
        /// <summary>
        /// Gets the list of products
        /// </summary>
        /// <returns>The Product inventory</returns>
        /// <remarks>
        /// This operation returns the list of products along with their current stock
        /// </remarks>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK,
            Type = typeof(IEnumerable<Product>))]
        [Route("~/products")]
        [SwaggerOperation("GetAllProducts")]
        public IEnumerable<Product> Get()
        {
            return GetInventory();
        }

        /// <summary>
        /// Gets a specific product
        /// </summary>
        /// <param name="id">Identifier for the product</param>
        /// <returns>The requested product</returns>
        /// <remarks>
        /// This operation returns the specific product based on the ID along with it's current stock
        /// </remarks>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK,
            Description = "OK",
            Type = typeof(Product))]
        [SwaggerResponse(HttpStatusCode.NotFound,
            Description = "Product not found",
            Type = typeof(Product))]
        [SwaggerOperation("GetProductById")]
        [Route("~/products/{id}")]
        public Product Get([FromUri] int id)
        {
            var inventory = GetInventory();
            return inventory.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Update a specific product
        /// </summary>
        /// <param name="product">Product to update inluding ID</param>
        /// <param name="ProductId">Product Id to update </param>
        /// <returns>True if update successful</returns>
        /// <remarks>
        /// This operation updates the specific product based on the ID along with it's current stock
        /// </remarks>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK,
            Description = "OK",
            Type = typeof(bool))]
        [SwaggerResponse(HttpStatusCode.NotFound,
            Description = "Product not found",
            Type = typeof(bool))]
        [SwaggerOperation("UpdateProduct")]
        [Route("~/products/{ProductId}")]
        public HttpResponseMessage Update([FromBody] Product product, [FromUri] int ProductId)
        {
            var inventory = GetInventory();

            //var productList = inventory.ToList();
            var curProduct = inventory.FirstOrDefault(x => x.Id == ProductId);
            if (curProduct == null || curProduct.Id != ProductId)
            {
                return Request.CreateResponse<bool>(HttpStatusCode.NotFound, false);
            }
            else
            {
                Delete(ProductId);
                Post(product);
                return Request.CreateResponse<bool>(HttpStatusCode.OK, true);
            }
            

        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="product">The new product</param>
        /// <returns>The saved product</returns>
        /// <remarks>
        /// This operation creates a new product along with it's current stock
        /// </remarks>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.Created,
            Description = "Created",
            Type = typeof(Product))]
        [Route("~/products")]
        [SwaggerOperation("CreateProduct")]
        public Product Post([FromBody] Product product)
        {
            var products = GetInventory();
            var productList = products.ToList();
            productList.Add(product);
             _storage.Save(productList, FILENAME);
            return product;
        }

        /// <summary>
        /// Deletes a product
        /// </summary>
        /// <param name="id">Identifier of the product to be deleted</param>
        /// <returns>True if the product was deleted</returns>
        /// <remarks>
        /// This operation deletes the product from the inventory
        /// </remarks>
        [HttpDelete]
        [SwaggerResponse(HttpStatusCode.OK,
            Description = "OK",
            Type = typeof(bool))]
        [SwaggerResponse(HttpStatusCode.NotFound,
            Description = "Product not found",
            Type = typeof(bool))]
        [Route("~/products/{id}")]
        [SwaggerOperation("DeleteProductById")]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            var products = GetInventory();
            var productList = products.ToList();

            if (!productList.Any(x => x.Id == id))
            {
                return Request.CreateResponse<bool>(HttpStatusCode.NotFound, false);
            }
            else
            {
                productList.RemoveAll(x => x.Id == id);
                _storage.Save(productList, FILENAME);
                return Request.CreateResponse<bool>(HttpStatusCode.OK, true);
            }
        }

        /// <summary>
        /// Deletes all products
        /// </summary>
        /// <returns>True if the product was deleted</returns>
        /// <remarks>
        /// This operation deletes all the products from the inventory
        /// </remarks>
        [HttpDelete]
        [SwaggerResponse(HttpStatusCode.OK,
            Description = "OK",
            Type = typeof(bool))]
        [Route("~/products")]
        [SwaggerOperation("DeleteAllProducts")]
        public HttpResponseMessage Delete()
        {

            _storage.Delete(FILENAME);
            return Request.CreateResponse<bool>(HttpStatusCode.OK, true);

        }

    }
}