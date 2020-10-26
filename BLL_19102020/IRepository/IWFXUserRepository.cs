using BLL_19102020.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_19102020.IRepository
{
   public interface IWFXUserRepository
    {
        User user(User user);
        Usergetdata usergetdata();

    }
}
