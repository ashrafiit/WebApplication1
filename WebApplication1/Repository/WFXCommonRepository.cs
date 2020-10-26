using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BLL_19102020.IRepository;
using BLL_19102020.Model;
using BLL_19102020.Model.Constant;
using DLL_19102020.DAL_utl;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication1.Repository
{
    public class WFXCommonRepository : IWFXCommonRepository
    {
        private IConfiguration _configuration;
        private Response resposne;
        public WFXCommonRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataTable customers()
        {
           
            DAL_CommonUtility utility = new DAL_CommonUtility(_configuration);
            var constr = utility.Connectionstring();
            SqlConnection con = new SqlConnection(constr);
            string query = "select * from Customer";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
          
            return dt;
        }
        public void postdata(Customer customer)
        {
            DAL_CommonUtility utility = new DAL_CommonUtility(_configuration);
            var constr = utility.Connectionstring();
            SqlConnection con = new SqlConnection(constr);
            string query="insert into Customer values('"+customer.Cname+"','"+customer.Cmobile+"')";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.CommandType = System.Data.CommandType.Text;
            con.Open();
            cmd.Parameters.AddWithValue("@Cname", customer.Cname);
            cmd.Parameters.AddWithValue("@Cmobile", customer.Cmobile);
           
            cmd.ExecuteNonQuery();
            resposne = new Response();
            if (resposne != null)
                resposne.Success = "record inserted";
            else
                resposne.Fail = "Not inserted";
            con.Close();
        }
    }
}
