using BLL_19102020.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL_19102020.IRepository
{
    public interface IWFXCommonRepository
    {
        void postdata(Customer customer);
        DataTable customers();
    }
}
