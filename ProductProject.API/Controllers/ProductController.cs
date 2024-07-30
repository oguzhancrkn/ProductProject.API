using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductProject.API.Core;
using System.Net.WebSockets;

namespace ProductProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {   
        private static List<ProductEntity> products = new List<ProductEntity> { 
            new ProductEntity{ Id = 1,Name="Cep Telefonu", Price="2000" },
            new ProductEntity{ Id = 2,Name="Bilgisayar", Price="3000" },
            new ProductEntity{ Id = 3,Name="ŞArj Aleti", Price="500" },

            };
        [HttpGet]
        public async Task <ActionResult<List<ProductEntity>>> Get()
        {
          
            return Ok(products);
        }

        //id si şu olan veriyi getirmek için yazılır aynı anda 2 get işlemi olamadıgından dolayı neyi alacagımızı belirtiriz

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductEntity>> Get(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
                return BadRequest("Ürün ID Bulunamadı");
            return Ok(product);
        }

        //ekleme yapılınca
        [HttpPost]
        public async Task<ActionResult<List<ProductEntity>>> AddProduct(ProductEntity product) 
        {
            products.Add(product);
            return Ok(products);
        }

        //Güncelleme
        [HttpPut]
        public async Task<ActionResult<List<ProductEntity>>> UpdateProduct(ProductEntity request)
        {
            var product = products.Find(x=>x.Id == request.Id);
            if (product == null)
                return BadRequest("Bu ID Değiştirilecek Ürün Buılunamadı");
                product.Name = request.Name;
                product.Price = request.Price;
            return Ok(products);
        }

        //Silme
        [HttpDelete]
        public async Task<ActionResult<List<ProductEntity>>> DeleteProduct(int id)
        {
            var product = products.Find(x=>x.Id == id);
            if(product == null)
                return NotFound("Silinecek Ürün Bulunamadı");
            products.Remove(product);
            return Ok(products);

        }

    }
}
