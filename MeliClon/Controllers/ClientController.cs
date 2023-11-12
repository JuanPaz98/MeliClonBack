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
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response response = new Response();
            try
            {
                using(RealSalesContext dbContext = new RealSalesContext())
                {
                    var clients = dbContext.Clients.ToList();
                    response.Success = 1;
                    response.Data= clients;
                    response.Message = "Success Response";
                }
            } catch (Exception ex)
            {
                response.Message= ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Add(ClientRequest oModel)
        {
            Response response = new Response();

            try
            {
                using(RealSalesContext dbContext = new RealSalesContext())
                {
                    Client oClient = new Client()
                    {
                        Name = oModel.Name
                    };
                    dbContext.Clients.Add(oClient);
                    dbContext.SaveChanges();
                    response.Success = 1;
                    response.Message = oClient.Name + " Was added Successfully";
                    response.Data = oClient;
                }
            } 
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public IActionResult Edit(ClientRequest oModel)
        {
            Response response = new Response();

            try
            {
                using (RealSalesContext dbContext = new RealSalesContext())
                {
                    Client oClient = dbContext.Clients.Find(oModel.Id);
                    oClient.Name = oModel.Name;
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
                    Client oClient = dbContext.Clients.Find(id);
                    dbContext.Clients.Remove(oClient);
                    dbContext.SaveChanges();
                    response.Success = 1;
                    response.Message = oClient.Id + " Was Deleted Successfully";
                    response.Data = oClient;
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
