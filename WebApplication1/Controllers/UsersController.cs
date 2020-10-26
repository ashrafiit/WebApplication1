using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL_19102020.IRepository;
using BLL_19102020.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IWFXUserRepository _wfxuserrepository;
        public UsersController(IUnitOfWork unitOfWork)
        {
            _wfxuserrepository = unitOfWork.WFXUserRepository;
        }
        [HttpGet]
        [Route("GetData")]
        public IActionResult GetData()
        {
            var getdata = _wfxuserrepository.usergetdata();
            return Ok(getdata);
        }
        [HttpPost]
        [Route("PostData")]
        public IActionResult PostData(User us)
        {
            _wfxuserrepository.user(us);
            return Ok(us);
        }
    }
}