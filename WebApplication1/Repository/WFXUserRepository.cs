using BLL_19102020.IRepository;
using BLL_19102020.Model;
using DLL_19102020.DAL_utl;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public class WFXUserRepository : IWFXUserRepository
    {

        private readonly IConfiguration _configuration;
        public WFXUserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public User user(User user)
        {
            DAL_CommonUtility utility = new DAL_CommonUtility(_configuration);
            var constr = utility.Connectionstring();
            SqlConnection con = new SqlConnection(constr);
            string query = "insert into user_info values('" + user.name + "','" +user.website + "','"+user.froms+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            con.Open();
            cmd.Parameters.AddWithValue("@name", user.name);
            cmd.Parameters.AddWithValue("@website", user.website);
            cmd.Parameters.AddWithValue("@froms", user.froms);
            cmd.ExecuteNonQuery();
            con.Close();
            return user;
        }

        public Usergetdata usergetdata()
        {
            Usergetdata userget = new Usergetdata();
            DAL_CommonUtility utility = new DAL_CommonUtility(_configuration);
            var constr = utility.Connectionstring();
            SqlConnection con = new SqlConnection(constr);
            //string query = "select * from user_info";
            string query = "select ua.uid,ua.name,ua.website,ua.froms from user_info ua,user_info ub where ua.uid = ub.uid;";
          //  string query = "select * from user_info where uid IN(1,2)" +
            //select * from user_info where uid IN(3)  
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while(rd.Read())
            {
                userget.people1 = new List<User>()
                {
                    new User()
                    {
                     uid=Convert.ToInt32(rd["uid"]),
                    name = Convert.ToString(rd["name"]),
                    website=Convert.ToString(rd["website"]),
                    froms=Convert.ToString(rd["froms"])

                    },
                    new User()
                    {
                         uid=Convert.ToInt32(rd["uid"]),
                    name = Convert.ToString(rd["name"]),
                    website=Convert.ToString(rd["website"]),
                    froms=Convert.ToString(rd["froms"])
                    }
                   
                };
                
                userget.people2 = new List<User>()
                {
                    new User()
                    {
                     uid=Convert.ToInt32(rd["uid"]),
                    name = Convert.ToString(rd["name"]),
                    website=Convert.ToString(rd["website"]),
                    froms=Convert.ToString(rd["froms"])
                    }
                };
            }
            con.Close();
            return userget;
            
        }
    }
}
