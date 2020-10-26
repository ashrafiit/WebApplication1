using BLL_19102020.IRepository;
using BLL_19102020.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebApplication1.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed;
        private WFXCommonRepository _wfxcommonrepository;
        private WFXMasterRepository _wfxmasterRepository;
        private WFXUserRepository _userRepository;
        public IConfiguration _configuration;
        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IWFXCommonRepository WFXCommonRepository
        {
            get
            {
                if (_wfxcommonrepository is null)
                
                    _wfxcommonrepository = new WFXCommonRepository(_configuration);
                return _wfxcommonrepository;
            }
        }
        public IWFXMasterRepository WFXMasterRepository
        {
            get
            {
                if (_wfxmasterRepository is null)
                    _wfxmasterRepository = new WFXMasterRepository(_configuration);
                return _wfxmasterRepository;
            }
        }
        public IWFXUserRepository WFXUserRepository
        {
            get
            {
                if (_userRepository is null)
                    _userRepository = new WFXUserRepository(_configuration);
                return _userRepository;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        public virtual void Dispose(bool disposing)
        {

        }
    }
}
