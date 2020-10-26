using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL_19102020.IRepository;
using BLL_19102020.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonsController : ControllerBase
    {
        private readonly IWFXCommonRepository _commonrepository;
        public CommonsController(IUnitOfWork unitOfWork)
        {
            _commonrepository = unitOfWork.WFXCommonRepository;
        }
        [HttpGet]
        [Route("GetData")]
        public IActionResult GetData()
        {
            var getdata=_commonrepository.customers();
            return Ok(getdata);
        }
        [HttpPost]
        [Route("PostData")]
        public IActionResult PostData(Customer customer)
        {
            _commonrepository.postdata(customer);
            return Ok(customer);
        }
    }
}
    
