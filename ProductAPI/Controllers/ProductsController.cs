using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Method that gets all the products from the database
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await _db.Products.ToListAsync());
        }


        //Method that gets a single product from the database
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
                return BadRequest("Product not found");
            return Ok(product);
        }


        //Method that post products to the database
        [HttpPost]
        public async Task<ActionResult<List<Product>>> PostProducts(Product prod)
        {
            _db.Products.Add(prod);
            await _db.SaveChangesAsync();
            return Ok(await _db.Products.ToListAsync());
        }


        //Method that updates a products based on the id in the database
        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProducts(Product request)
        {
            var dbProd = await _db.Products.FindAsync(request.Id);
            if (dbProd == null)
                return BadRequest("Product not found");

            dbProd.ProductName = request.ProductName;
            dbProd.ProductDescription = request.ProductDescription;
            dbProd.ProductPrice = request.ProductPrice;

            await _db.SaveChangesAsync();

            return Ok(await _db.Products.ToListAsync());
        }


        //Method that deletes a products based on the id from the database
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProducts(int id)
        {
            var dbProd = await _db.Products.FindAsync(id);
            if (dbProd == null)
                return BadRequest("Product not found");
            _db.Products.Remove(dbProd);
            _db.SaveChanges();
            return Ok(dbProd);
        }

    }
}
