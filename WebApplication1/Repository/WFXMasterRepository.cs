using BLL_19102020.IRepository;
using BLL_19102020.Model;
using DLL_19102020.DAL_utl;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public class WFXMasterRepository : IWFXMasterRepository
    {
        private readonly IConfiguration _configuration;
        public WFXMasterRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ViewModelClass dataTable()
        {
            ViewModelClass vmss = new ViewModelClass();
             DataTable dt = new DataTable();
            DAL_CommonUtility utility = new DAL_CommonUtility(_configuration);
            var constr = utility.Connectionstring();
            SqlConnection con = new SqlConnection(constr);
            string query = "select familydetail.FId,familydetail.FirstName,familydetail.LastName,familydetail.Fathername,familydetail.Accountno,familydetail.Aadharcard,familydetail.Ifsccode,familydetail.Pancard,familydetail.Branchname,location.LId,location.City,location.State,location.Country,location.Mobile,location.Pincode,restuarent.Res_Id,restuarent.Name,rtime.Time_id,rtime.Opening_hr,rtime.Closing_hr from location inner join familydetail on familydetail.FId = location.LId inner join restuarent on restuarent.Res_Id = location.LId inner join rtime on rtime.Time_id = restuarent.Res_Id";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while(rd.Read())
            {
                
                vmss.faimlyDetails = new FaimlyDetails()
                {
                    FId = Convert.ToInt32(rd["FId"]),
                    FirstName = Convert.ToString(rd["FirstName"]),
                    LastName = Convert.ToString(rd["LastName"]),
                    Fathername = Convert.ToString(rd["Fathername"]),
                    Aadharcard = Convert.ToInt32(rd["Aadharcard"]),
                    Pancard = Convert.ToString(rd["Pancard"]),
                    Accountno = Convert.ToInt32(rd["Accountno"]),
                    Branchname = Convert.ToString(rd["Branchname"]),
                    Ifsccode = Convert.ToString(rd["Ifsccode"])
                };
                vmss.locations = new List<Location>()

                {
                    new Location()
                    {
                    LId = Convert.ToInt32(rd["LId"]),
                    City = Convert.ToString(rd["City"]),
                    State = Convert.ToString(rd["State"]),
                    Country = Convert.ToString(rd["Country"]),
                    Mobile = Convert.ToInt32(rd["Mobile"]),
                    Pincode=Convert.ToInt32(rd["Pincode"])
                    }
                  
                };
               
                vmss.restaurent = new Restaurent()
                {
                    Res_Id = Convert.ToInt32(rd["Res_Id"]),
                    Name = Convert.ToString(rd["Name"])
                };
              
                vmss.restaurent_Time = new Restaurent_time()
                {
                    Time_id=Convert.ToInt32(rd["Time_id"]),
                    Opening_hr = Convert.ToString(rd["Opening_hr"]),
                    Closing_hr = Convert.ToString(rd["Closing_hr"])
                };

            
            }
           
            con.Close();
            return vmss;
        }

        public ViewModelClass postviewmodel(ViewModelClass viewModelClass)
        {
            DAL_CommonUtility utility = new DAL_CommonUtility(_configuration);
            var constr = utility.Connectionstring();
            SqlConnection con = new SqlConnection(constr);
            string query = "insert into restuarent values('" + viewModelClass.restaurent.Name + "')" +
                "insert into familydetail values('" + viewModelClass.faimlyDetails.FirstName + "','"+viewModelClass.faimlyDetails.LastName+"','"+viewModelClass.faimlyDetails.Fathername+"','"+viewModelClass.faimlyDetails.Aadharcard+"','"+viewModelClass.faimlyDetails.Pancard+"','"+viewModelClass.faimlyDetails.Accountno+"','"+viewModelClass.faimlyDetails.Branchname+"','"+viewModelClass.faimlyDetails.Ifsccode+"')" 
                + "insert into location values('" + viewModelClass.location.City + "','"+viewModelClass.location.State+"','"+viewModelClass.location.Country+"','"+viewModelClass.location.Mobile+"','"+viewModelClass.location.Pincode+"')" +
                "insert into rtime values('" + viewModelClass.restaurent_Time.Opening_hr
                + "','"+viewModelClass.restaurent_Time.Closing_hr+"')";
                ;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = System.Data.CommandType.Text;
            con.Open();
            cmd.Parameters.AddWithValue("@Name", viewModelClass.restaurent.Name);
            cmd.Parameters.AddWithValue("@FirstName", viewModelClass.faimlyDetails.FirstName);
            cmd.Parameters.AddWithValue("@LastName", viewModelClass.faimlyDetails.LastName);
            cmd.Parameters.AddWithValue("@Aadharcard", viewModelClass.faimlyDetails.Aadharcard);
            cmd.Parameters.AddWithValue("@Pancard", viewModelClass.faimlyDetails.Pancard);
            cmd.Parameters.AddWithValue("@Fathername", viewModelClass.faimlyDetails.Fathername);
            cmd.Parameters.AddWithValue("@Accountno", viewModelClass.faimlyDetails.Accountno);
            cmd.Parameters.AddWithValue("@Branchname", viewModelClass.faimlyDetails.Branchname);
            cmd.Parameters.AddWithValue("@Ifsccode", viewModelClass.faimlyDetails.Ifsccode);
            cmd.Parameters.AddWithValue("@City", viewModelClass.location.City);
            cmd.Parameters.AddWithValue("@State", viewModelClass.location.State);
            cmd.Parameters.AddWithValue("@Country", viewModelClass.location.Country);
            cmd.Parameters.AddWithValue("@Mobile", viewModelClass.location.Mobile);
            cmd.Parameters.AddWithValue("@Pincode", viewModelClass.location.Pincode);
            cmd.Parameters.AddWithValue("@Opening_hr", viewModelClass.restaurent_Time.Opening_hr); 
            cmd.Parameters.AddWithValue("@Closing_hr", viewModelClass.restaurent_Time.Closing_hr);
            cmd.ExecuteNonQuery();
            con.Close();
            return viewModelClass;
        }
    }
}
