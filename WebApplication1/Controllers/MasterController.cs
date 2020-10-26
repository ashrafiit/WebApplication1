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
    public class MasterController : ControllerBase
    {
        private readonly IWFXMasterRepository _masterRepository;
        public MasterController(IUnitOfWork unitOfWork)
        {
            _masterRepository = unitOfWork.WFXMasterRepository;
        }
        [HttpPost]
        [Route("masterpostdata")]
        public IActionResult masterpostdata(ViewModelClass vm)
        {
            var postdata = _masterRepository.postviewmodel(vm);
            return Ok(postdata);
        }
        [HttpGet]
        [Route("Getmasterdata")]
        public IActionResult Getmasterdata()
        {
            var getdata = _masterRepository.dataTable();
            return Ok(getdata);
        }
    }
}