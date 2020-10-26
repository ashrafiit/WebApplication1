using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_19102020.IRepository
{
   public interface IUnitOfWork : IDisposable
    {
        IWFXCommonRepository WFXCommonRepository { get; }
        IWFXMasterRepository WFXMasterRepository { get; }
        IWFXUserRepository WFXUserRepository { get; }
    }
}
