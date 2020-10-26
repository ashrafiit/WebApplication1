using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL_19102020.DAL_utl
{
    public class DAL_CommonUtility
    {
        private readonly IConfiguration _configuration;
        public DAL_CommonUtility(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public  string Connectionstring()
        {
           

                string ss = _configuration.GetConnectionString("wfx_plm_18102020");
                return ss;

            
        }
    }
}

