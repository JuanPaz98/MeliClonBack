using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MeliClon.Models;
using MeliClon.Models.Response;
using MeliClon.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace MeliClon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response response = new Response();
            try
            {
                using (RealSalesContext dbContext = new RealSalesContext())
                {
                    var products = dbContext.Products.ToList();
                    response.Success = 1;
                    response.Data = products;
                    response.Message = "Success Response";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleProduct(int id)
        {
            Response response = new Response();
            try
            {
                using (RealSalesContext dbContext = new RealSalesContext())
                {
                    var product = dbContext.Products.Find(id);
                    response.Success = 1;
                    response.Data = product;
                    response.Message = "Success Response";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Add(ClientRequest oModel)
        {
            Response response = new Response();

            try
            {
                using (RealSalesContext dbContext = new RealSalesContext())
                {
                    Product oProduct = new Product();
                    dbContext.Products.Add(oProduct);
                    dbContext.SaveChanges();
                    response.Success = 1;
                    response.Message = oProduct.Title + " Was added Successfully";
                    response.Data = oProduct;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public IActionResult Edit(ProductRequest oModel)
        {
            Response response = new Response();

            try
            {
                using (RealSalesContext dbContext = new RealSalesContext())
                {
                    Product oClient = dbContext.Products.Find(oModel.Id);
                    oClient.Title = oModel.Title;
                    oClient.Description = oModel.Description;
                    oClient.UnitPrice = oModel.UnitPrice;
                    oClient.Category = oModel.Category;
                    oClient.Cost = oModel.Cost;
                    oClient.Count = oModel.Count;


                    dbContext.Entry(oClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbContext.SaveChanges();
                    response.Success = 1;
                    response.Message = oClient.Id + " Was Edited Successfully";
                    response.Data = oClient;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Response response = new Response();

            try
            {
                using (RealSalesContext dbContext = new RealSalesContext())
                {
                    Product oProduct = dbContext.Products.Find(id);
                    dbContext.Products.Remove(oProduct);
                    dbContext.SaveChanges();
                    response.Success = 1;
                    response.Message = oProduct.Id + " Was Deleted Successfully";
                    response.Data = oProduct;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
